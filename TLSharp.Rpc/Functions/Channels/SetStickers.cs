using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class SetStickers : ITlFunc<bool>, IEquatable<SetStickers>, IComparable<SetStickers>, IComparable
    {
        public T.InputChannel Channel { get; }
        public T.InputStickerSet Stickerset { get; }
        
        public SetStickers(
            Some<T.InputChannel> channel,
            Some<T.InputStickerSet> stickerset
        ) {
            Channel = channel;
            Stickerset = stickerset;
        }
        
        
        (T.InputChannel, T.InputStickerSet) CmpTuple =>
            (Channel, Stickerset);

        public bool Equals(SetStickers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SetStickers x && Equals(x);
        public static bool operator ==(SetStickers x, SetStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetStickers x, SetStickers y) => !(x == y);

        public int CompareTo(SetStickers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SetStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetStickers x, SetStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetStickers x, SetStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(SetStickers x, SetStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetStickers x, SetStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Stickerset: {Stickerset})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xea8ca4f9);
            Write(Channel, bw, WriteSerializable);
            Write(Stickerset, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}