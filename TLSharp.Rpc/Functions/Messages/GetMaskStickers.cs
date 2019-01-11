using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetMaskStickers : ITlFunc<T.Messages.AllStickers>, IEquatable<GetMaskStickers>, IComparable<GetMaskStickers>, IComparable
    {
        public int Hash { get; }
        
        public GetMaskStickers(
            int hash
        ) {
            Hash = hash;
        }
        
        
        int CmpTuple =>
            Hash;

        public bool Equals(GetMaskStickers other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetMaskStickers x && Equals(x);
        public static bool operator ==(GetMaskStickers x, GetMaskStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetMaskStickers x, GetMaskStickers y) => !(x == y);

        public int CompareTo(GetMaskStickers other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetMaskStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetMaskStickers x, GetMaskStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetMaskStickers x, GetMaskStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(GetMaskStickers x, GetMaskStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetMaskStickers x, GetMaskStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x65b8c79f);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.AllStickers ITlFunc<T.Messages.AllStickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AllStickers.Deserialize);
    }
}