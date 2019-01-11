using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class DestroySession : ITlFunc<T.DestroySessionRes>, IEquatable<DestroySession>, IComparable<DestroySession>, IComparable
    {
        public long SessionId { get; }
        
        public DestroySession(
            long sessionId
        ) {
            SessionId = sessionId;
        }
        
        
        long CmpTuple =>
            SessionId;

        public bool Equals(DestroySession other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is DestroySession x && Equals(x);
        public static bool operator ==(DestroySession x, DestroySession y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DestroySession x, DestroySession y) => !(x == y);

        public int CompareTo(DestroySession other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DestroySession x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DestroySession x, DestroySession y) => x.CompareTo(y) <= 0;
        public static bool operator <(DestroySession x, DestroySession y) => x.CompareTo(y) < 0;
        public static bool operator >(DestroySession x, DestroySession y) => x.CompareTo(y) > 0;
        public static bool operator >=(DestroySession x, DestroySession y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(SessionId: {SessionId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe7512126);
            Write(SessionId, bw, WriteLong);
        }
        
        T.DestroySessionRes ITlFunc<T.DestroySessionRes>.DeserializeResult(BinaryReader br) =>
            Read(br, T.DestroySessionRes.Deserialize);
    }
}