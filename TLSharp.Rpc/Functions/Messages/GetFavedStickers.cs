using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetFavedStickers : ITlFunc<T.Messages.FavedStickers>, IEquatable<GetFavedStickers>, IComparable<GetFavedStickers>, IComparable
    {
        public int Hash { get; }
        
        public GetFavedStickers(
            int hash
        ) {
            Hash = hash;
        }
        
        
        int CmpTuple =>
            Hash;

        public bool Equals(GetFavedStickers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetFavedStickers x && Equals(x);
        public static bool operator ==(GetFavedStickers x, GetFavedStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetFavedStickers x, GetFavedStickers y) => !(x == y);

        public int CompareTo(GetFavedStickers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetFavedStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetFavedStickers x, GetFavedStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetFavedStickers x, GetFavedStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(GetFavedStickers x, GetFavedStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetFavedStickers x, GetFavedStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x21ce0b0e);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.FavedStickers ITlFunc<T.Messages.FavedStickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.FavedStickers.Deserialize);
    }
}