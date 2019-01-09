using System;
using LanguageExt;

namespace TLSharp.Rpc.Generator.TlScheme
{
    static class Exts
    {
        public static T GetOrThrow<T>(this Option<T> opt, Func<Exception> exception) =>
            opt.IfNone(() => throw exception());
    }
}
