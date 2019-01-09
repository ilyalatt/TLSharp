using System.Collections.Generic;
using System.Linq;
using static LanguageExt.Prelude;

namespace TLSharp.Rpc.Generator.TextModel
{
    static class TextAbbreviations
    {
        public static Text String(string s) => Text.CreateString(s);
        public static Text Concat(string separator, params Text[] xs) => Text.CreateScope(xs.ToArr(), separator);
        public static Text Concat(params Text[] xs) => Concat("", xs);
        public static Text Concat(string separator, IEnumerable<Text> xs) => Concat(separator, xs.ToArray());
        public static Text Concat(IEnumerable<Text> xs) => Concat("", xs);
        public static Text Concat(string separator, params IEnumerable<Text>[] xs) => Concat(separator, xs.Bind(identity));
        public static Text Concat(params IEnumerable<Text>[] xs) => Concat("", xs);
    }
}
