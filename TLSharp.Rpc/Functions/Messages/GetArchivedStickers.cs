using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetArchivedStickers : ITlFunc<T.Messages.ArchivedStickers>, IEquatable<GetArchivedStickers>, IComparable<GetArchivedStickers>, IComparable
    {
        public bool Masks { get; }
        public long OffsetId { get; }
        public int Limit { get; }
        
        public GetArchivedStickers(
            bool masks,
            long offsetId,
            int limit
        ) {
            Masks = masks;
            OffsetId = offsetId;
            Limit = limit;
        }
        
        
        (bool, long, int) CmpTuple =>
            (Masks, OffsetId, Limit);

        public bool Equals(GetArchivedStickers other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetArchivedStickers x && Equals(x);
        public static bool operator ==(GetArchivedStickers x, GetArchivedStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetArchivedStickers x, GetArchivedStickers y) => !(x == y);

        public int CompareTo(GetArchivedStickers other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetArchivedStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetArchivedStickers x, GetArchivedStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetArchivedStickers x, GetArchivedStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(GetArchivedStickers x, GetArchivedStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetArchivedStickers x, GetArchivedStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Masks: {Masks}, OffsetId: {OffsetId}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x57f17692);
            Write(MaskBit(0, Masks), bw, WriteInt);
            Write(OffsetId, bw, WriteLong);
            Write(Limit, bw, WriteInt);
        }
        
        T.Messages.ArchivedStickers ITlFunc<T.Messages.ArchivedStickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.ArchivedStickers.Deserialize);
    }
}