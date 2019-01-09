using System;
using LanguageExt;

namespace TLSharp.Rpc.Generator.TlScheme
{
    class TlSchemeParserException : Exception
    {
        public TlSchemeParserException(Some<string> message) : base(message) { }
    }
}