using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;
using LanguageExt.SomeHelp;
using TLSharp.Rpc.Generator.TextModel;
using TLSharp.Rpc.Generator.TlScheme;
using static LanguageExt.Prelude;
using static TLSharp.Rpc.Generator.TextModel.TextAbbreviations;
using static TLSharp.Rpc.Generator.TextModel.NestedTextAbbreviations;

namespace TLSharp.Rpc.Generator.Generation
{
    static class CsGen
    {
        static readonly System.Collections.Generic.HashSet<string> CsKeywords = new System.Collections.Generic.HashSet<string>() {
            "null",
            "out",
            "long",
            "private",
            "public",
            "static",
            "true",
            "params"
        };
        static string LowerFirst(string s) =>
            s[0].Apply(char.ToLower).Apply(fc => fc + s.Substring(1))
            .Apply(x => CsKeywords.Contains(x) ? "@" + x : x);

        static readonly NestedText Header = Scope(
            Line("using System;"),
            Line("using System.IO;"),
            Line("using BigMath;"),
            Line("using LanguageExt;"),
            Line("using static TLSharp.Rpc.TlMarshal;"),
            Line("using T = TLSharp.Rpc.Types;")
        );

        static string TypeNumber(int typeNumber) => $"0x{typeNumber:x8}";


        static string ConvertType(TlType type) => type.Match(
            primitive: x =>
            {
                switch (x.Type)
                {
                    case PrimitiveType.Bytes: return "Arr<byte>";
                    case PrimitiveType.Int128: return "Int128";
                    case PrimitiveType.Int256: return "Int256";
                    default: return x.Type.ToString().ToLower();
                }
            },
            vector: x => $"Arr<{ConvertType(x.Type)}>",
            typeRef: x => x.Name == "X" || x.Name == "!X" ? "TFunc" : $"T.{x.Name}"
        );

        static bool IsRefType(TlType type) => type.Match(
            primitive: x => x.Type == PrimitiveType.String || x.Type == PrimitiveType.Bytes,
            _: () => true
        );

        static string ConvertArgType(Arg arg) => arg.Kind.Match(
            required: x => ConvertType(arg.Type),
            optional: x => arg.Type == TlType.OfPrimitive(PrimitiveType.True) ? "bool" : $"Option<{ConvertType(arg.Type)}>",
            flags: _ => "int"
        );

        static bool IsRefArgType(Arg arg) => arg.Kind.Match(
            required: x => IsRefType(arg.Type),
            optional: x => false,
            flags: _ => false
        );

        static string ConvertArgTypeWithSome(Arg arg) => ConvertArgType(arg)
            .Apply(x => IsRefArgType(arg) ? $"Some<{x}>" : x);

        static NestedText GenSerializerDef(Arr<Arg> args, Option<int> typeNumber)
        {
            Text GenSerializer(TlType type) => type.Match(
                primitive: x => $"Write{x.Type}",
                typeRef: x => "WriteSerializable",
                vector: x => Concat(
                    $"WriteVector<{ConvertType(x.Type)}>(",
                    GenSerializer(x.Type),
                    ")"
                )
            );

            Option<Text> GenNonFlagArgSerializer(Arg arg) =>
                arg.Kind.Match(
                    _: () => throw new Exception("WTF"),
                    required: _ => GenSerializer(arg.Type).Apply(Some),
                    optional: x => arg.Type == TlType.OfPrimitive(PrimitiveType.True) ? None : Concat(
                        $"WriteOption<{ConvertType(arg.Type)}>(",
                        GenSerializer(arg.Type),
                        ")"
                    ).Apply(Some)
                ).Map(s =>
                    Concat($"Write({arg.Name}, bw, ", s, ");")
                );

            Text GenMaskSerializer(IEnumerable<(string, int)> maskArgs) =>
                maskArgs.ToArr()
                .Apply(Optional).Filter(xs => xs.Count > 0)
                .Map(xs => xs
                    .Map(x => $"MaskBit({x.Item2}, {x.Item1})").Map(String).Reduce((x, y) => Concat(x, " | ", y))
                )
                .IfNone("0")
                .Apply(mask => Concat("Write(", mask, ", bw, WriteInt);"));

            Option<Text> GenArgSerializer(Arg arg) => arg.Kind.Match(
                _: () => GenNonFlagArgSerializer(arg),
                flags: _ =>
                    args.Choose(x => x.Kind.Match(
                        _: () => None,
                        optional: optional => ($"{x.Name}", optional.Flag.Bit).Apply(Some)
                    )).Apply(GenMaskSerializer)
            );

            var body = args.Choose(GenArgSerializer).Map(Line).Scope().Apply(s => typeNumber
                .Map(TypeNumber).Map(x => Line($"WriteUint(bw, {x});")).Map(typeNumSer => Scope(typeNumSer, s))
                .IfNone(s)
            );
            var def = Scope(
                Line("void ITlSerializable.Serialize(BinaryWriter bw)"),
                Line("{"),
                Indent(1, body),
                Line("}")
            );
            return def;
        }

        static Text GenTypeDeserializer(TlType type) =>
            type.Match(
                primitive: x => Concat("Read", x.Type.ToString()),
                typeRef: x => Concat("T.", x.Name, ".Deserialize"),
                vector: x => Concat(
                    "ReadVector(",
                    GenTypeDeserializer(x.Type),
                    ")"
                )
            );

        static NestedText GenDeserializeDef(string tagName, Arr<Arg> args)
        {
            Text GenArgDeserializer(Arg arg) =>
                arg.Kind.Match(
                    required: _ => GenTypeDeserializer(arg.Type),
                    flags: _ => GenTypeDeserializer(arg.Type),
                    optional: x => Concat(
                        "ReadOption(",
                        Join(", ",
                            new Text[]
                            {
                                LowerFirst(x.Flag.ArgName),
                                x.Flag.Bit.ToString()
                            },
                            arg.Type == TlType.OfPrimitive(PrimitiveType.True) ? None : Some(GenTypeDeserializer(arg.Type))
                        ),
                        ")"
                    )
                ).Apply(s =>
                    Concat($"var {LowerFirst(arg.Name)} = Read(br, ", s, ");")
                );

            var argsWithoutFlags = args.Filter(x => x.Kind.Match(_: () => true, flags: _ => false));
            var body = Scope(
                args.Map(GenArgDeserializer).Map(Line).Scope(),
                Line(Concat(
                    $"return new {tagName}(",
                    argsWithoutFlags.Map(x => x.Name).Map(LowerFirst).Map(String).Apply(xs => Join(", ", xs)),
                    ");"
                ))
            );
            var def = Scope(
                Line($"internal static {tagName} DeserializeTag(BinaryReader br)"),
                Line("{"),
                Indent(1, body),
                Line("}")
            );
            return def;
        }

        // TODO: refactor it
        // add CsModel over TextModel

        static NestedText GetTagDef(Signature tag)
        {
            var tagName = tag.Name;
            var tagArgsWithoutFlags = tag.Args.Filter(x => x.Kind.Match(_: () => true, flags: _ => false)).ToArr();
            var tagArgs = tagArgsWithoutFlags
                .Map(x => (
                    name: x.Name,
                    type: ConvertArgType(x),
                    someType: ConvertArgTypeWithSome(x)
                )).ToArray();

            return Scope(
                Line($"public sealed class {tagName} : Record<{tagName}>, ITlTypeTag"),
                Line("{"),
                IndentedScope(1,
                    Scope(
                        Line($"internal const uint TypeNumber = {TypeNumber(tag.TypeNumber)};"),
                        Line("uint ITlTypeTag.TypeNumber => TypeNumber;"),
                        Line("")
                    ),
                    tagArgs.Map(arg => Line($"public {arg.type} {arg.name} {{ get; }}")).Scope(),
                    Scope(
                        Line(""),
                        Line($"public {tagName}("),
                        IndentedScope(1, $",{Environment.NewLine}",
                            tagArgs.Map(arg => Line($"{arg.someType} {LowerFirst(arg.name)}"))
                        ),
                        Line(") {"),
                        IndentedScope(1,
                            tagArgs.Map(arg => Line($"{arg.name} = {LowerFirst(arg.name)};"))
                        ),
                        Line("}"),
                        Line(""),
                        GenSerializerDef(tag.Args, typeNumber: None),
                        Line(""),
                        GenDeserializeDef(tag.Name, tag.Args)
                    )
                ),
                Line("}")
            );
        }

        static NestedText GenFuncDef(Signature func, string funcName)
        {
            var funcArgsWithoutFlags = func.Args.Filter(x => x.Kind.Match(_: () => true, flags: _ => false)).ToArr();
            var funcArgs = funcArgsWithoutFlags
                .Map(x => (
                    name: x.Name,
                    type: ConvertArgType(x),
                    someType: ConvertArgTypeWithSome(x)
                )).ToArray();

            // usually it is a higher-order function, i am too lazy to modify the scheme just for this case
            var isWrapper = func.Args.Exists(x => x.Type == TlType.OfTypeRef("X") || x.Type == TlType.OfTypeRef("!X"));
            var resType = isWrapper ? "TFuncRes" : ConvertType(func.ResultType);
            var classAccess = isWrapper ? "" : "public ";
            var classTemplates = isWrapper ? "<TFunc, TFuncRes>" : "";
            var classAnnotations = isWrapper
                ? $": ITlFunc<{resType}> where TFunc : ITlFunc<{resType}>"
                : $": Record<{funcName}>, ITlFunc<{resType}>";

            var resDes = isWrapper
                ? "Query.DeserializeResult(br);" // it is 'Query' all the time, i am too lazy
                : Concat("Read(br, ", GenTypeDeserializer(func.ResultType), ");");
            var resultDeserializer = Scope(
                Line($"{resType} ITlFunc<{resType}>.DeserializeResult(BinaryReader br) =>"),
                Indent(1, Line(resDes))
            );

            return Scope(
                Line($"{classAccess}sealed class {funcName}{classTemplates} {classAnnotations}"),
                Line("{"),
                IndentedScope(1,
                    funcArgs.Map(arg => Line($"public {arg.type} {arg.name} {{ get; }}")).Scope(),
                    Scope(
                        Line(""),
                        Line($"public {funcName}("),
                        IndentedScope(1, $",{Environment.NewLine}",
                            funcArgs.Map(arg => Line($"{arg.someType} {LowerFirst(arg.name)}"))
                        ),
                        Line(") {"),
                        IndentedScope(1,
                            funcArgs.Map(arg => Line($"{arg.name} = {LowerFirst(arg.name)};"))
                        ),
                        Line("}"),
                        Line(""),
                        GenSerializerDef(func.Args, typeNumber: func.TypeNumber),
                        Line(""),
                        resultDeserializer
                    )
                ),
                Line("}")
            );
        }

        static NestedText GenTypeDef(string nameSpace, string typeName, Arr<Signature> typeTags)
        {
            var tagsDefs = typeTags.Map(GetTagDef).Scope(Environment.NewLine + Environment.NewLine);

            var tagDef = Scope(
                Line("readonly ITlTypeTag _tag;"),
                Line($"{typeName}(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));")
            );

            var tagCreateDef = typeTags.Map(tag =>
                Line($"public static explicit operator {typeName}({tag.Name} tag) => new {typeName}(tag);")
            ).Scope();


            var serializedRef = Scope(
                Line("void ITlSerializable.Serialize(BinaryWriter bw)"),
                Line("{"),
                IndentedScope(1,
                    Line("WriteUint(bw, _tag.TypeNumber);"),
                    Line("_tag.Serialize(bw);")
                ),
                Line("}")
            );

            var staticDeserializerDef = Scope(
                Line($"internal static {typeName} Deserialize(BinaryReader br)"),
                Line("{"),
                IndentedScope(1,
                    Line("var typeNumber = ReadUint(br);"),
                    Line("switch (typeNumber)"),
                    Line("{"),
                    IndentedScope(1,
                        typeTags.Map(x => Line($"case {x.Name}.TypeNumber: return ({typeName}) {x.Name}.DeserializeTag(br);")).Scope(),
                        Line(Concat(
                            "default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { ",
                            typeTags.Map(x => $"{x.Name}.TypeNumber").Map(String).Apply(xs => Join(", ", xs)),
                            " });"
                        ))
                    ),
                    Line("}")
                ),
                Line("}")
            );

            var matchArgFns =
                typeTags.Map(tag => tag.Name).Map(tagName =>
                    $"Func<{tagName}, T> {LowerFirst(tagName)}"
                );

            var matchOptDef = Scope(
                Line($"{(typeTags.Count <= 1 ? "" : "public ")}T Match<T>("),
                IndentedScope(1, $",{Environment.NewLine}",
                    Line("Func<T> _").Singleton(),
                    matchArgFns.Map(x => Concat(x, " = null")).Map(Line)
                ),
                Line(") {"),
                IndentedScope(1,
                    Line("if (_ == null) throw new ArgumentNullException(nameof(_));"),
                    Line("switch (_tag)"),
                    Line("{"),
                    IndentedScope(1,
                        typeTags.Map(tag =>
                        {
                            var tagName = tag.Name;
                            var tagNameLower = LowerFirst(tagName);
                            return Line($"case {tagName} x when {tagNameLower} != null: return {tagNameLower}(x);");
                        }).Scope(),
                        Line("default: return _();")
                    ),
                    Line("}")
                ),
                Line("}")
            );

            var matchDef = Scope(
                Line("public T Match<T>("),
                IndentedScope(1, $",{Environment.NewLine}", matchArgFns.Map(Line)),
                Line(") => Match("),
                IndentedScope(1, $",{Environment.NewLine}",
                    Line(@"() => throw new Exception(""WTF"")").Singleton(),
                    typeTags.Map(tag =>
                    {
                        var tagName = tag.Name;
                        var tagNameLower = LowerFirst(tagName);
                        return Line($"{tagNameLower} ?? throw new ArgumentNullException(nameof({tagNameLower}))");
                    })
                ),
                Line(");")
            );

            var eqDef = Scope(
                Line($"public bool Equals({typeName} other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);"),
                Line($"public override bool Equals(object obj) => obj is {typeName} x && Equals(x);"),
                Line($"public static bool operator ==({typeName} a, {typeName} b) => a?.Equals(b) ?? ReferenceEquals(b, null);"),
                Line($"public static bool operator !=({typeName} a, {typeName} b) => !(a == b);")
            );

            var helpersDef = Scope(
                Line("int GetTagOrder()"),
                Line("{"),
                IndentedScope(1,
                    Line("switch (_tag)"),
                    Line("{"),
                    IndentedScope(1,
                        typeTags.Map((idx, x) => $"case {x.Name} _: return {idx};").Map(Line).Scope(),
                        Line("default: throw new Exception(\"WTF\");")
                    ),
                    Line("}")
                ),
                Line("}"),
                Line("(int, object) CmpPair => (GetTagOrder(), _tag);")
            );

            var cmpDef = Scope(
                Line($"public int CompareTo({typeName} other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));"),
                Line($"int IComparable.CompareTo(object other) => other is {typeName} x ? CompareTo(x) : throw new ArgumentException(\"bad type\", nameof(other));"),
                Scope(new[] { "<=", "<", ">", ">=" }
                    .Map(op => $"public static bool operator {op}({typeName} a, {typeName} b) => a.CompareTo(b) {op} 0;")
                    .Map(Line)
                )
            );

            var hashCodeDef = Line("public override int GetHashCode() => CmpPair.GetHashCode();");

            var bodyDef = Scope(Environment.NewLine + Environment.NewLine,
                tagsDefs,
                tagDef,
                tagCreateDef,
                serializedRef,
                staticDeserializerDef,
                matchOptDef,
                matchDef,
                eqDef,
                helpersDef,
                cmpDef,
                hashCodeDef
            );

            var def = Scope(
                Line($"public sealed class {typeName} : ITlType, IEquatable<{typeName}>, IComparable<{typeName}>, IComparable"),
                Line("{"),
                Indent(1, bodyDef),
                Line("}")
            );

            return def;
        }

        public static Func<NestedText, NestedText> WrapIntoNamespace(string nameSpace) => def =>Scope(
            Header,
            Line(""),
            Line($"namespace {nameSpace}"),
            Line("{"),
            Indent(1, def),
            Line("}")
        );

        public static IEnumerable<CsGenFile> GenTypes(Scheme scheme) => scheme.Types
            .GroupBy(x => x.ResultType)
            .Choose(x => x
                .Key.Match(_: () => None, typeRef: Some)
                .Map(custom => (name: custom.Name, tags: x.ToArr()))
            )
            .Map(type =>
            {
                var (rawNameSpace, name) = TlSchemeNormalizer.SplitName(type.name);
                var nameSpace = string.Join(".", new[] { "TLSharp.Rpc.Types", rawNameSpace }.Choose(identity));
                var def = GenTypeDef(nameSpace, name, type.tags).Apply(WrapIntoNamespace(nameSpace));
                var content = def.ToSome().Apply(xs => NestedTextStringifier.Stringify(xs));
                return new CsGenFile(nameSpace, name, content);
            });

        public static IEnumerable<CsGenFile> GenFunctions(Scheme scheme) => scheme.Functions
            .Map(func =>
            {
                var (rawNameSpace, name) = TlSchemeNormalizer.SplitName(func.Name);
                var nameSpace = string.Join(".", new[] { "TLSharp.Rpc.Functions", rawNameSpace }.Choose(identity));
                var def = GenFuncDef(func, name).Apply(WrapIntoNamespace(nameSpace));
                var content = def.ToSome().Apply(xs => NestedTextStringifier.Stringify(xs));
                return new CsGenFile(nameSpace, name, content);
            });

        public static CsGenFile GenSchemeInfo(Scheme scheme)
        {
            const string nameSpace = "TLSharp.Rpc";
            const string name = "SchemeInfo";
            var infoDef = Scope(
                Line($"static class {name}"),
                Line("{"),
                IndentedScope(1,
                    Line($"public const int LayerVersion = {scheme.LayerVersion};")
                ),
                Line("}")
            ).Apply(WrapIntoNamespace(nameSpace));
            var content = NestedTextStringifier.Stringify(infoDef);

            return new CsGenFile(nameSpace, name, content);
        }
    }
}
