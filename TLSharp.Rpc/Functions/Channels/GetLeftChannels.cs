using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetLeftChannels : ITlFunc<T.Messages.Chats>, IEquatable<GetLeftChannels>, IComparable<GetLeftChannels>, IComparable
    {
        public int Offset { get; }
        
        public GetLeftChannels(
            int offset
        ) {
            Offset = offset;
        }
        
        
        int CmpTuple =>
            Offset;

        public bool Equals(GetLeftChannels other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetLeftChannels x && Equals(x);
        public static bool operator ==(GetLeftChannels x, GetLeftChannels y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetLeftChannels x, GetLeftChannels y) => !(x == y);

        public int CompareTo(GetLeftChannels other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetLeftChannels x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetLeftChannels x, GetLeftChannels y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetLeftChannels x, GetLeftChannels y) => x.CompareTo(y) < 0;
        public static bool operator >(GetLeftChannels x, GetLeftChannels y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetLeftChannels x, GetLeftChannels y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Offset: {Offset})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8341ecc0);
            Write(Offset, bw, WriteInt);
        }
        
        T.Messages.Chats ITlFunc<T.Messages.Chats>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Chats.Deserialize);
    }
}