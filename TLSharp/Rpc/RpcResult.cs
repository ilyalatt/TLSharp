using System;
using System.IO;

namespace TLSharp.Rpc
{
    struct RpcResult
    {
        public readonly long Id;
        public readonly BinaryReader Body;
        public readonly TlException Exception;

        public RpcResult(long id, BinaryReader body, TlException exception)
        {
            Id = id;
            Body = body;
            Exception = exception;
        }

        public static RpcResult OfSuccess(long msgId, BinaryReader msgBody) =>
            new RpcResult(msgId, msgBody, null);

        public static RpcResult OfFail(long msgId, TlException exception) =>
            new RpcResult(msgId, null, exception);

        public T Match<T>(Func<BinaryReader, T> success, Func<TlException, T> fail) =>
            Body != null ? success(Body)
            : Exception != null ? fail(Exception)
            : throw new Exception("WTF");
    }
}