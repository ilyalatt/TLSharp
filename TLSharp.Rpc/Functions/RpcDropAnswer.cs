using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class RpcDropAnswer : ITlFunc<T.RpcDropAnswer>, IEquatable<RpcDropAnswer>, IComparable<RpcDropAnswer>, IComparable
    {
        public long ReqMsgId { get; }
        
        public RpcDropAnswer(
            long reqMsgId
        ) {
            ReqMsgId = reqMsgId;
        }
        
        
        long CmpTuple =>
            ReqMsgId;

        public bool Equals(RpcDropAnswer other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is RpcDropAnswer x && Equals(x);
        public static bool operator ==(RpcDropAnswer x, RpcDropAnswer y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(RpcDropAnswer x, RpcDropAnswer y) => !(x == y);

        public int CompareTo(RpcDropAnswer other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is RpcDropAnswer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RpcDropAnswer x, RpcDropAnswer y) => x.CompareTo(y) <= 0;
        public static bool operator <(RpcDropAnswer x, RpcDropAnswer y) => x.CompareTo(y) < 0;
        public static bool operator >(RpcDropAnswer x, RpcDropAnswer y) => x.CompareTo(y) > 0;
        public static bool operator >=(RpcDropAnswer x, RpcDropAnswer y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ReqMsgId: {ReqMsgId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x58e4a740);
            Write(ReqMsgId, bw, WriteLong);
        }
        
        T.RpcDropAnswer ITlFunc<T.RpcDropAnswer>.DeserializeResult(BinaryReader br) =>
            Read(br, T.RpcDropAnswer.Deserialize);
    }
}