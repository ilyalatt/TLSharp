using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class DeleteHistory : ITlFunc<bool>, IEquatable<DeleteHistory>, IComparable<DeleteHistory>, IComparable
    {
        public T.InputChannel Channel { get; }
        public int MaxId { get; }
        
        public DeleteHistory(
            Some<T.InputChannel> channel,
            int maxId
        ) {
            Channel = channel;
            MaxId = maxId;
        }
        
        
        (T.InputChannel, int) CmpTuple =>
            (Channel, MaxId);

        public bool Equals(DeleteHistory other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DeleteHistory x && Equals(x);
        public static bool operator ==(DeleteHistory x, DeleteHistory y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeleteHistory x, DeleteHistory y) => !(x == y);

        public int CompareTo(DeleteHistory other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DeleteHistory x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeleteHistory x, DeleteHistory y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeleteHistory x, DeleteHistory y) => x.CompareTo(y) < 0;
        public static bool operator >(DeleteHistory x, DeleteHistory y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeleteHistory x, DeleteHistory y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, MaxId: {MaxId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xaf369d42);
            Write(Channel, bw, WriteSerializable);
            Write(MaxId, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}