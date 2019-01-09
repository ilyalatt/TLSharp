using System;

namespace TLSharp.Rpc.Generator.Generation
{
    class CsGenException : Exception
    {
        public CsGenException(string message) : base(message) { }
    }
}