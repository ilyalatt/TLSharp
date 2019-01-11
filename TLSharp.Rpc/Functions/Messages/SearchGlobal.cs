using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SearchGlobal : ITlFunc<T.Messages.Messages>, IEquatable<SearchGlobal>, IComparable<SearchGlobal>, IComparable
    {
        public string Q { get; }
        public int OffsetDate { get; }
        public T.InputPeer OffsetPeer { get; }
        public int OffsetId { get; }
        public int Limit { get; }
        
        public SearchGlobal(
            Some<string> q,
            int offsetDate,
            Some<T.InputPeer> offsetPeer,
            int offsetId,
            int limit
        ) {
            Q = q;
            OffsetDate = offsetDate;
            OffsetPeer = offsetPeer;
            OffsetId = offsetId;
            Limit = limit;
        }
        
        
        (string, int, T.InputPeer, int, int) CmpTuple =>
            (Q, OffsetDate, OffsetPeer, OffsetId, Limit);

        public bool Equals(SearchGlobal other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SearchGlobal x && Equals(x);
        public static bool operator ==(SearchGlobal x, SearchGlobal y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SearchGlobal x, SearchGlobal y) => !(x == y);

        public int CompareTo(SearchGlobal other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SearchGlobal x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SearchGlobal x, SearchGlobal y) => x.CompareTo(y) <= 0;
        public static bool operator <(SearchGlobal x, SearchGlobal y) => x.CompareTo(y) < 0;
        public static bool operator >(SearchGlobal x, SearchGlobal y) => x.CompareTo(y) > 0;
        public static bool operator >=(SearchGlobal x, SearchGlobal y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Q: {Q}, OffsetDate: {OffsetDate}, OffsetPeer: {OffsetPeer}, OffsetId: {OffsetId}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9e3cacb0);
            Write(Q, bw, WriteString);
            Write(OffsetDate, bw, WriteInt);
            Write(OffsetPeer, bw, WriteSerializable);
            Write(OffsetId, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}