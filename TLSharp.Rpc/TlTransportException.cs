using System;
using LanguageExt;

namespace TLSharp.Rpc
{
    public class TlTransportException : Exception
    {
        public TlTransportException(Some<string> message) : base(message) { }

        static string TypeNumber(uint n) => "0x" + n.ToString("x8");

        internal static TlTransportException UnexpectedTypeNumber(uint actual, uint[] expected) => new TlTransportException(
            $"Unexpected type number, got ${TypeNumber(actual)}, "+
            $"expected {expected.Map(TypeNumber).Apply(xs => string.Join(" or ", xs))}."
        );

        internal static TlTransportException UnexpectedBoolTypeNumber(uint actual) => new TlTransportException(
            $"Unexpected 'Bool' type number ${TypeNumber(actual)}"
        );

        internal static TlTransportException UnexpectedVectorTypeNumber(uint actual) => new TlTransportException(
            $"Unexpected 'Vector' type number ${TypeNumber(actual)}"
        );
    }
}
