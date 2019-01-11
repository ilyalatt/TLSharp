using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetStickers : ITlFunc<T.Messages.Stickers>, IEquatable<GetStickers>, IComparable<GetStickers>, IComparable
    {
        public string Emoticon { get; }
        public int Hash { get; }
        
        public GetStickers(
            Some<string> emoticon,
            int hash
        ) {
            Emoticon = emoticon;
            Hash = hash;
        }
        
        
        (string, int) CmpTuple =>
            (Emoticon, Hash);

        public bool Equals(GetStickers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetStickers x && Equals(x);
        public static bool operator ==(GetStickers x, GetStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetStickers x, GetStickers y) => !(x == y);

        public int CompareTo(GetStickers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetStickers x, GetStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetStickers x, GetStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(GetStickers x, GetStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetStickers x, GetStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Emoticon: {Emoticon}, Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x043d4f2c);
            Write(Emoticon, bw, WriteString);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.Stickers ITlFunc<T.Messages.Stickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Stickers.Deserialize);
    }
}