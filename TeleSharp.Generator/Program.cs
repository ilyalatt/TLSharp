using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace TeleSharp.Generator
{
    class Program
    {
        static readonly List<string> Keywords = new List<string>(new[] { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while", "add", "alias", "ascending", "async", "await", "descending", "dynamic", "from", "get", "global", "group", "into", "join", "let", "orderby", "partial", "partial", "remove", "select", "set", "value", "var", "where", "where", "yield" });
        static readonly List<string> InterfacesList = new List<string>();
        static readonly List<string> ClassesList = new List<string>();

        static string DownloadLatestSchema()
        {
            const string url = "https://core.telegram.org/schema/json";
            return new WebClient().DownloadString(url);
        }

        static void Main()
        {
            var absStyle = File.ReadAllText("ConstructorAbs.tmp");
            var normalStyle = File.ReadAllText("Constructor.tmp");
            var methodStyle = File.ReadAllText("Method.tmp");

            var json = DownloadLatestSchema();
            var schema = JsonConvert.DeserializeObject<Schema>(json);

            foreach (var c in schema.Constructors)
            {
                InterfacesList.Add(c.Type);
                ClassesList.Add(c.Predicate);
            }

            foreach (var c in schema.Constructors)
            {
                var list = schema.Constructors.Where(x => x.Type == c.Type || x.Params.Exists(y => y.Type == c.Type));
                if (list.Count() > 1)
                {
                    var path = (GetNameSpace(c.Type).Replace("TeleSharp.TL", "TL/").Replace(".", "") + "/" + GetNameofClass(c.Type, true) + ".cs").Replace("//", "/");
                    var classFile = MakeFile(path);
                    using (var writer = new StreamWriter(classFile))
                    {
                        var nspace = (GetNameSpace(c.Type).Replace("TeleSharp.TL", "TL/").Replace(".", "")).Replace("//", "/").Replace("/", ".");
                        if (nspace.EndsWith("."))
                            nspace = nspace.Remove(nspace.Length - 1, 1);
                        var temp = absStyle.Replace("/* NAMESPACE */", "TeleSharp." + nspace);
                        temp = temp.Replace("/* NAME */", GetNameofClass(c.Type, true));
                        writer.Write(temp);
                        writer.Close();
                        classFile.Close();
                    }
                }
                else
                {
                    InterfacesList.Remove(list.First().Type);
                    list.First().Type = "himself";
                }
            }

            foreach (var c in schema.Constructors)
            {
                var path = (GetNameSpace(c.Predicate).Replace("TeleSharp.TL", "TL/").Replace(".", "") + "/" + GetNameofClass(c.Predicate, false) + ".cs").Replace("//", "/");
                var classFile = MakeFile(path);
                using (var writer = new StreamWriter(classFile))
                {
                    #region About Class
                    var nspace = (GetNameSpace(c.Predicate).Replace("TeleSharp.TL", "TL\\").Replace(".", "")).Replace("\\\\", "\\").Replace("\\", ".");
                    if (nspace.EndsWith("."))
                        nspace = nspace.Remove(nspace.Length - 1, 1);
                    var temp = normalStyle.Replace("/* NAMESPACE */", "TeleSharp." + nspace);
                    temp = (c.Type == "himself") ? temp.Replace("/* PARENT */", "TLObject") : temp.Replace("/* PARENT */", GetNameofClass(c.Type, true));
                    temp = temp.Replace("/*Constructor*/", c.Id.ToString());
                    temp = temp.Replace("/* NAME */", GetNameofClass(c.Predicate, false));
                    #endregion
                    #region Fields
                    var fields = "";
                    foreach (var tmp in c.Params)
                    {
                        fields += $"     public {CheckForFlagBase(tmp.Type, GetTypeName(tmp.Type))} {CheckForKeywordAndPascalCase(tmp.Name)} " + "{get;set;}" + Environment.NewLine;
                    }
                    temp = temp.Replace("/* PARAMS */", fields);
                    #endregion
                    #region ComputeFlagFunc
                    if (!c.Params.Any(x => x.Name == "Flags")) temp = temp.Replace("/* COMPUTE */", "");
                    else
                    {
                        var compute = "Flags = 0;" + Environment.NewLine;
                        foreach (var param in c.Params.Where(x => IsFlagBase(x.Type)))
                        {
                            if (IsTrueFlag(param.Type))
                            {
                                compute += $"Flags = {CheckForKeywordAndPascalCase(param.Name)} ? (Flags | {GetBitMask(param.Type)}) : (Flags & ~{GetBitMask(param.Type)});" + Environment.NewLine;
                            }
                            else
                            {
                                compute += $"Flags = {CheckForKeywordAndPascalCase(param.Name)} != null ? (Flags | {GetBitMask(param.Type)}) : (Flags & ~{GetBitMask(param.Type)});" + Environment.NewLine;
                            }
                        }
                        temp = temp.Replace("/* COMPUTE */", compute);
                    }
                    #endregion
                    #region SerializeFunc
                    var serialize = "";

                    if (c.Params.Any(x => x.Name == "Flags")) serialize += "ComputeFlags();" + Environment.NewLine + "bw.Write(Flags);" + Environment.NewLine;
                    foreach (var p in c.Params.Where(x => x.Name != "Flags"))
                    {
                        serialize += WriteWriteCode(p) + Environment.NewLine;
                    }
                    temp = temp.Replace("/* SERIALIZE */", serialize);
                    #endregion
                    #region DeSerializeFunc
                    var deserialize = "";

                    foreach (var p in c.Params)
                    {
                        deserialize += WriteReadCode(p) + Environment.NewLine;
                    }
                    temp = temp.Replace("/* DESERIALIZE */", deserialize);
                    #endregion
                    writer.Write(temp);
                    writer.Close();
                    classFile.Close();
                }
            }

            foreach (var c in schema.Methods)
            {
                var path = (GetNameSpace(c.MethodName).Replace("TeleSharp.TL", "TL/").Replace(".", "") + "/" + GetNameofClass(c.MethodName, false, true) + ".cs").Replace("//", "/");
                var classFile = MakeFile(path);
                using (var writer = new StreamWriter(classFile))
                {
                    #region About Class
                    var nspace = (GetNameSpace(c.MethodName).Replace("TeleSharp.TL", "TL\\").Replace(".", "")).Replace("\\\\", "\\").Replace("\\", ".");
                    if (nspace.EndsWith("."))
                        nspace = nspace.Remove(nspace.Length - 1, 1);
                    var temp = methodStyle.Replace("/* NAMESPACE */", "TeleSharp." + nspace);
                    temp = temp.Replace("/* PARENT */", "TLMethod");
                    temp = temp.Replace("/*Constructor*/", c.Id.ToString());
                    temp = temp.Replace("/* NAME */", GetNameofClass(c.MethodName, false, true));
                    #endregion
                    #region Fields
                    var fields = "";
                    foreach (var tmp in c.Params)
                    {
                        fields += $"        public {CheckForFlagBase(tmp.Type, GetTypeName(tmp.Type))} {CheckForKeywordAndPascalCase(tmp.Name)} " + "{get;set;}" + Environment.NewLine;
                    }
                    fields += $"        public {CheckForFlagBase(c.Type, GetTypeName(c.Type))} Response" + "{ get; set;}" + Environment.NewLine;
                    temp = temp.Replace("/* PARAMS */", fields);
                    #endregion
                    #region ComputeFlagFunc
                    if (!c.Params.Any(x => x.Name == "Flags")) temp = temp.Replace("/* COMPUTE */", "");
                    else
                    {
                        var compute = "Flags = 0;" + Environment.NewLine;
                        foreach (var param in c.Params.Where(x => IsFlagBase(x.Type)))
                        {
                            if (IsTrueFlag(param.Type))
                            {
                                compute += $"Flags = {CheckForKeywordAndPascalCase(param.Name)} ? (Flags | {GetBitMask(param.Type)}) : (Flags & ~{GetBitMask(param.Type)});" + Environment.NewLine;
                            }
                            else
                            {
                                compute += $"Flags = {CheckForKeywordAndPascalCase(param.Name)} != null ? (Flags | {GetBitMask(param.Type)}) : (Flags & ~{GetBitMask(param.Type)});" + Environment.NewLine;
                            }
                        }
                        temp = temp.Replace("/* COMPUTE */", compute);
                    }
                    #endregion
                    #region SerializeFunc
                    var serialize = "";

                    if (c.Params.Any(x => x.Name == "Flags")) serialize += "ComputeFlags();" + Environment.NewLine + "bw.Write(Flags);" + Environment.NewLine;
                    foreach (var p in c.Params.Where(x => x.Name != "Flags"))
                    {
                        serialize += WriteWriteCode(p) + Environment.NewLine;
                    }
                    temp = temp.Replace("/* SERIALIZE */", serialize);
                    #endregion
                    #region DeSerializeFunc
                    var deserialize = "";

                    foreach (var p in c.Params)
                    {
                        deserialize += WriteReadCode(p) + Environment.NewLine;
                    }
                    temp = temp.Replace("/* DESERIALIZE */", deserialize);
                    #endregion
                    #region DeSerializeRespFunc
                    var deserializeResp = "";
                    var p2 = new Param() { Name = "Response", Type = c.Type };
                    deserializeResp += WriteReadCode(p2) + Environment.NewLine;
                    temp = temp.Replace("/* DESERIALIZEResp */", deserializeResp);
                    #endregion
                    writer.Write(temp);
                    writer.Close();
                    classFile.Close();
                }
            }
        }

        public static string FormatName(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            if (input.IndexOf('.') != -1)
            {
                input = input.Replace(".", " ");
                var temp = "";
                foreach (var s in input.Split(' '))
                {
                    temp += FormatName(s) + " ";
                }
                input = temp.Trim();
            }
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public static string CheckForKeywordAndPascalCase(string name)
        {
            name = name.Replace("_", " ");
            name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
            name = name.Replace(" ", "");

            if (Keywords.Contains(name)) return "@" + name;
            return name;
        }

        public static string GetNameofClass(string type, bool isinterface = false, bool ismethod = false)
        {
            if (!ismethod)
            {
                if (type.IndexOf('.') != -1 && type.IndexOf('?') == -1)
                    return isinterface ? "TLAbs" + FormatName(type.Split('.')[1]) : "TL" + FormatName(type.Split('.')[1]);
                else if (type.IndexOf('.') != -1 && type.IndexOf('?') != -1)
                    return isinterface ? "TLAbs" + FormatName(type.Split('?')[1]) : "TL" + FormatName(type.Split('?')[1]);
                else
                    return isinterface ? "TLAbs" + FormatName(type) : "TL" + FormatName(type);
            }
            else
            {
                if (type.IndexOf('.') != -1 && type.IndexOf('?') == -1)
                    return "TLRequest" + FormatName(type.Split('.')[1]);
                else if (type.IndexOf('.') != -1 && type.IndexOf('?') != -1)
                    return "TLRequest" + FormatName(type.Split('?')[1]);
                else
                    return "TLRequest" + FormatName(type);
            }
        }

        private static bool IsFlagBase(string type)
        {
            return type.IndexOf("?") != -1;
        }

        private static int GetBitMask(string type)
        {
            return (int)Math.Pow((double)2, (double)int.Parse(type.Split('?')[0].Split('.')[1]));
        }

        private static bool IsTrueFlag(string type)
        {
            return type.Split('?')[1] == "true";
        }

        public static string GetNameSpace(string type)
        {
            if (type.IndexOf('.') != -1)
                return "TeleSharp.TL" + FormatName(type.Split('.')[0]);
            else
                return "TeleSharp.TL";
        }

        public static string CheckForFlagBase(string type, string result)
        {
            if (type.IndexOf('?') == -1)
                return result;
            else
            {
                var innerType = type.Split('?')[1];
                if (innerType == "true") return result;
                else if ((new[] { "bool", "int", "uint", "long", "double" }).Contains(result)) return result + "?";
                else return result;
            }
        }

        public static string GetTypeName(string type)
        {
            switch (type.ToLower())
            {
                case "#":
                case "int":
                    return "int";
                case "uint":
                    return "uint";
                case "long":
                    return "long";
                case "double":
                    return "double";
                case "string":
                    return "string";
                case "bytes":
                    return "byte[]";
                case "true":
                case "bool":
                    return "bool";
                case "!x":
                    return "TLObject";
                case "x":
                    return "TLObject";
            }

            if (type.StartsWith("Vector"))
                return "TLVector<" + GetTypeName(type.Replace("Vector<", "").Replace(">", "")) + ">";

            if (type.ToLower().Contains("inputcontact"))
                return "TLInputPhoneContact";


            if (type.IndexOf('.') != -1 && type.IndexOf('?') == -1)
            {

                if (InterfacesList.Any(x => x.ToLower() == (type).ToLower()))
                    return FormatName(type.Split('.')[0]) + "." + "TLAbs" + type.Split('.')[1];
                else if (ClassesList.Any(x => x.ToLower() == (type).ToLower()))
                    return FormatName(type.Split('.')[0]) + "." + "TL" + type.Split('.')[1];
                else
                    return FormatName(type.Split('.')[1]);
            }
            else if (type.IndexOf('?') == -1)
            {
                if (InterfacesList.Any(x => x.ToLower() == type.ToLower()))
                    return "TLAbs" + type;
                else if (ClassesList.Any(x => x.ToLower() == type.ToLower()))
                    return "TL" + type;
                else
                    return type;
            }
            else
            {
                return GetTypeName(type.Split('?')[1]);
            }
        }

        public static string LookTypeInLists(string src)
        {
            if (InterfacesList.Any(x => x.ToLower() == src.ToLower()))
                return "TLAbs" + FormatName(src);
            else if (ClassesList.Any(x => x.ToLower() == src.ToLower()))
                return "TL" + FormatName(src);
            else
                return src;
        }

        public static string WriteWriteCode(Param p, bool flag = false)
        {
            switch (p.Type.ToLower())
            {
                case "#":
                case "int":
                    return flag ? $"bw.Write({CheckForKeywordAndPascalCase(p.Name)}.Value);" : $"bw.Write({CheckForKeywordAndPascalCase(p.Name)});";
                case "long":
                    return flag ? $"bw.Write({CheckForKeywordAndPascalCase(p.Name)}.Value);" : $"bw.Write({CheckForKeywordAndPascalCase(p.Name)});";
                case "string":
                    return $"StringUtil.Serialize({CheckForKeywordAndPascalCase(p.Name)},bw);";
                case "bool":
                    return flag ? $"BoolUtil.Serialize({CheckForKeywordAndPascalCase(p.Name)}.Value,bw);" : $"BoolUtil.Serialize({CheckForKeywordAndPascalCase(p.Name)},bw);";
                case "true":
                    return $"BoolUtil.Serialize({CheckForKeywordAndPascalCase(p.Name)},bw);";
                case "bytes":
                    return $"BytesUtil.Serialize({CheckForKeywordAndPascalCase(p.Name)},bw);";
                case "double":
                    return flag ? $"bw.Write({CheckForKeywordAndPascalCase(p.Name)}.Value);" : $"bw.Write({CheckForKeywordAndPascalCase(p.Name)});";
                default:
                    if (!IsFlagBase(p.Type))
                        return $"ObjectUtils.SerializeObject({CheckForKeywordAndPascalCase(p.Name)},bw);";
                    else
                    {
                        if (IsTrueFlag(p.Type))
                            return $"";
                        else
                        {
                            var p2 = new Param() { Name = p.Name, Type = p.Type.Split('?')[1] };
                            return $"if ((Flags & {GetBitMask(p.Type).ToString()}) != 0)" + Environment.NewLine +
                                WriteWriteCode(p2, true);
                        }
                    }
            }
        }

        public static string WriteReadCode(Param p)
        {
            switch (p.Type.ToLower())
            {
                case "#":
                case "int":
                    return $"{CheckForKeywordAndPascalCase(p.Name)} = br.ReadInt32();";
                case "long":
                    return $"{CheckForKeywordAndPascalCase(p.Name)} = br.ReadInt64();";
                case "string":
                    return $"{CheckForKeywordAndPascalCase(p.Name)} = StringUtil.Deserialize(br);";
                case "bool":
                case "true":
                    return $"{CheckForKeywordAndPascalCase(p.Name)} = BoolUtil.Deserialize(br);";
                case "bytes":
                    return $"{CheckForKeywordAndPascalCase(p.Name)} = BytesUtil.Deserialize(br);";
                case "double":
                    return $"{CheckForKeywordAndPascalCase(p.Name)} = br.ReadDouble();";
                default:
                    if (!IsFlagBase(p.Type))
                    {
                        if (p.Type.ToLower().Contains("vector"))
                        {
                            return $"{CheckForKeywordAndPascalCase(p.Name)} = ({GetTypeName(p.Type)})ObjectUtils.DeserializeVector<{GetTypeName(p.Type).Replace("TLVector<", "").Replace(">", "")}>(br);";
                        }
                        else return $"{CheckForKeywordAndPascalCase(p.Name)} = ({GetTypeName(p.Type)})ObjectUtils.DeserializeObject(br);";
                    }
                    else
                    {
                        if (IsTrueFlag(p.Type))
                            return $"{CheckForKeywordAndPascalCase(p.Name)} = (Flags & {GetBitMask(p.Type).ToString()}) != 0;";
                        else
                        {
                            var p2 = new Param() { Name = p.Name, Type = p.Type.Split('?')[1] };
                            return $"if ((Flags & {GetBitMask(p.Type).ToString()}) != 0)" + Environment.NewLine +
                                WriteReadCode(p2) + Environment.NewLine +
                            "else" + Environment.NewLine +
                                $"{CheckForKeywordAndPascalCase(p.Name)} = null;" + Environment.NewLine;
                        }
                    }
            }
        }

        public static FileStream MakeFile(string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (File.Exists(path)) File.Delete(path);
            return File.OpenWrite(path);
        }
    }
}
