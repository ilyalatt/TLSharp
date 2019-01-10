using System;
using LanguageExt;
using static LanguageExt.Prelude;

namespace TLSharp
{
    public abstract class TlException : Exception
    {
        internal TlException(Some<string> message, Option<Exception> innerException) : base(
            message,
            innerException.IfNoneUnsafe(() => null)
        ) { }
    }
}

namespace TLSharp.Rpc
{
    public abstract class TlRpcException : TlException
    {
        internal TlRpcException(Some<string> message, Option<Exception> innerException) : base(
            message,
            innerException
        ) { }
    }

    public class TlRpcDeserializeException : TlRpcException
    {
        internal TlRpcDeserializeException(Some<string> message) : base(message, None) { }

        static string TypeNumber(uint n) => "0x" + n.ToString("x8");

        internal static TlRpcDeserializeException UnexpectedTypeNumber(uint actual, uint[] expected) => new TlRpcDeserializeException(
            $"Unexpected type number, got ${TypeNumber(actual)}, "+
            $"expected {expected.Map(TypeNumber).Apply(xs => string.Join(" or ", xs))}."
        );

        internal static TlRpcDeserializeException UnexpectedBoolTypeNumber(uint actual) => new TlRpcDeserializeException(
            $"Unexpected 'Bool' type number ${TypeNumber(actual)}"
        );

        internal static TlRpcDeserializeException UnexpectedVectorTypeNumber(uint actual) => new TlRpcDeserializeException(
            $"Unexpected 'Vector' type number ${TypeNumber(actual)}"
        );
    }
}
