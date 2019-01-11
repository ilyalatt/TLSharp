using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ReadHistory : ITlFunc<bool>, IEquatable<ReadHistory>, IComparable<ReadHistory>, IComparable
    {
        public T.InputChannel Channel { get; }
        public int MaxId { get; }
        
        public ReadHistory(
            Some<T.InputChannel> channel,
            int maxId
        ) {
            Channel = channel;
            MaxId = maxId;
        }
        
        
        (T.InputChannel, int) CmpTuple =>
            (Channel, MaxId);

        public bool Equals(ReadHistory other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReadHistory x && Equals(x);
        public static bool operator ==(ReadHistory x, ReadHistory y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReadHistory x, ReadHistory y) => !(x == y);

        public int CompareTo(ReadHistory other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReadHistory x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReadHistory x, ReadHistory y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReadHistory x, ReadHistory y) => x.CompareTo(y) < 0;
        public static bool operator >(ReadHistory x, ReadHistory y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReadHistory x, ReadHistory y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, MaxId: {MaxId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xcc104937);
            Write(Channel, bw, WriteSerializable);
            Write(MaxId, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}