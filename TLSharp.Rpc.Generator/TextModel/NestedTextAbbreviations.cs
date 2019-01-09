using System;
using System.Collections.Generic;
using static LanguageExt.Prelude;

namespace TLSharp.Rpc.Generator.TextModel
{
    static class NestedTextAbbreviations
    {
        public static NestedText Line(Text text) => NestedText.CreateLine(text);
        public static NestedText Line(string s) => Line(TextAbbreviations.String(s));
        public static NestedText Indent(int offset, NestedText text) => NestedText.CreateIndent(offset, text);
        public static NestedText Scope(this IEnumerable<NestedText> xs, string separator = null) => NestedText.CreateScope(xs.ToArr(), separator ?? Environment.NewLine);
        public static NestedText Scope(string separator, params NestedText[] xs) => xs.Scope(separator);
        public static NestedText Scope(string separator, params IEnumerable<NestedText>[] xs) => xs.Bind(identity).Scope(separator);
        public static NestedText Scope(params NestedText[] xs) => Scope(null, xs);
        public static NestedText Scope(params IEnumerable<NestedText>[] xs) => Scope(null, xs);
        public static NestedText IndentedScope(int offset, string separator, params NestedText[] xs) => Indent(offset, Scope(separator, xs));
        public static NestedText IndentedScope(int offset, string separator, params IEnumerable<NestedText>[] xs) => Indent(offset, Scope(separator, xs));
        public static NestedText IndentedScope(int offset, params NestedText[] xs) => IndentedScope(offset, null, xs);
        public static NestedText IndentedScope(int offset, params IEnumerable<NestedText>[] xs) => IndentedScope(offset, null, xs);
        public static IEnumerable<T> Singleton<T>(this T value) => new[] { value };
    }
}
