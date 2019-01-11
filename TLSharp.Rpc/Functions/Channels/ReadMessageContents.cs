using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ReadMessageContents : ITlFunc<bool>, IEquatable<ReadMessageContents>, IComparable<ReadMessageContents>, IComparable
    {
        public T.InputChannel Channel { get; }
        public Arr<int> Id { get; }
        
        public ReadMessageContents(
            Some<T.InputChannel> channel,
            Some<Arr<int>> id
        ) {
            Channel = channel;
            Id = id;
        }
        
        
        (T.InputChannel, Arr<int>) CmpTuple =>
            (Channel, Id);

        public bool Equals(ReadMessageContents other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReadMessageContents x && Equals(x);
        public static bool operator ==(ReadMessageContents x, ReadMessageContents y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReadMessageContents x, ReadMessageContents y) => !(x == y);

        public int CompareTo(ReadMessageContents other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReadMessageContents x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReadMessageContents x, ReadMessageContents y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReadMessageContents x, ReadMessageContents y) => x.CompareTo(y) < 0;
        public static bool operator >(ReadMessageContents x, ReadMessageContents y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReadMessageContents x, ReadMessageContents y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xeab5dc38);
            Write(Channel, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}