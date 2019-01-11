using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReadMessageContents : ITlFunc<T.Messages.AffectedMessages>, IEquatable<ReadMessageContents>, IComparable<ReadMessageContents>, IComparable
    {
        public Arr<int> Id { get; }
        
        public ReadMessageContents(
            Some<Arr<int>> id
        ) {
            Id = id;
        }
        
        
        Arr<int> CmpTuple =>
            Id;

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

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x36a73f77);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        T.Messages.AffectedMessages ITlFunc<T.Messages.AffectedMessages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedMessages.Deserialize);
    }
}