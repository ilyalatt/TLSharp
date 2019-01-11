using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetDialogs : ITlFunc<T.Messages.Dialogs>, IEquatable<GetDialogs>, IComparable<GetDialogs>, IComparable
    {
        public bool ExcludePinned { get; }
        public int OffsetDate { get; }
        public int OffsetId { get; }
        public T.InputPeer OffsetPeer { get; }
        public int Limit { get; }
        
        public GetDialogs(
            bool excludePinned,
            int offsetDate,
            int offsetId,
            Some<T.InputPeer> offsetPeer,
            int limit
        ) {
            ExcludePinned = excludePinned;
            OffsetDate = offsetDate;
            OffsetId = offsetId;
            OffsetPeer = offsetPeer;
            Limit = limit;
        }
        
        
        (bool, int, int, T.InputPeer, int) CmpTuple =>
            (ExcludePinned, OffsetDate, OffsetId, OffsetPeer, Limit);

        public bool Equals(GetDialogs other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetDialogs x && Equals(x);
        public static bool operator ==(GetDialogs x, GetDialogs y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetDialogs x, GetDialogs y) => !(x == y);

        public int CompareTo(GetDialogs other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetDialogs x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetDialogs x, GetDialogs y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetDialogs x, GetDialogs y) => x.CompareTo(y) < 0;
        public static bool operator >(GetDialogs x, GetDialogs y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetDialogs x, GetDialogs y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ExcludePinned: {ExcludePinned}, OffsetDate: {OffsetDate}, OffsetId: {OffsetId}, OffsetPeer: {OffsetPeer}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x191ba9c5);
            Write(MaskBit(0, ExcludePinned), bw, WriteInt);
            Write(OffsetDate, bw, WriteInt);
            Write(OffsetId, bw, WriteInt);
            Write(OffsetPeer, bw, WriteSerializable);
            Write(Limit, bw, WriteInt);
        }
        
        T.Messages.Dialogs ITlFunc<T.Messages.Dialogs>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Dialogs.Deserialize);
    }
}