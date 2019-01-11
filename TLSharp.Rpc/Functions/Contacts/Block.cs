using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class Block : ITlFunc<bool>, IEquatable<Block>, IComparable<Block>, IComparable
    {
        public T.InputUser Id { get; }
        
        public Block(
            Some<T.InputUser> id
        ) {
            Id = id;
        }
        
        
        T.InputUser CmpTuple =>
            Id;

        public bool Equals(Block other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is Block x && Equals(x);
        public static bool operator ==(Block x, Block y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Block x, Block y) => !(x == y);

        public int CompareTo(Block other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is Block x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Block x, Block y) => x.CompareTo(y) <= 0;
        public static bool operator <(Block x, Block y) => x.CompareTo(y) < 0;
        public static bool operator >(Block x, Block y) => x.CompareTo(y) > 0;
        public static bool operator >=(Block x, Block y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x332b49fc);
            Write(Id, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}