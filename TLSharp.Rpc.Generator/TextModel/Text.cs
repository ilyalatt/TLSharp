using System;
using LanguageExt;

namespace TLSharp.Rpc.Generator.TextModel
{
    class Text
    {
        public class String
        {
            public string Value { get; }

            public String(Some<string> value) => Value = value;
        }

        public class Scope
        {
            public Arr<Text> Values { get; }
            public string Separator { get; }

            public Scope(Some<Arr<Text>> values, Some<string> separator)
            {
                Values = values;
                Separator = separator;
            }
        }

        readonly object _tag;
        Text(object tag) => _tag = tag;

        public static Text CreateString(Some<string> value) => new Text(new String(value));
        public static Text CreateScope(Some<Arr<Text>> values, Some<string> separator) => new Text(new Scope(values, separator));


        public T Match<T>(
            Func<T> _,
            Func<String, T> str = null,
            Func<Scope, T> scope = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case String x when str != null: return str(x);
                case Scope x when scope != null: return scope(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<String, T> str,
            Func<Scope, T> scope
        ) => Match(
            _: () => throw new Exception("WTF"),
            str: str ?? throw new ArgumentNullException(nameof(str)),
            scope: scope ?? throw new ArgumentNullException(nameof(scope))
        );
    }
}