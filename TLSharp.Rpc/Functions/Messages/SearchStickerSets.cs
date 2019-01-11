using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SearchStickerSets : ITlFunc<T.Messages.FoundStickerSets>, IEquatable<SearchStickerSets>, IComparable<SearchStickerSets>, IComparable
    {
        public bool ExcludeFeatured { get; }
        public string Q { get; }
        public int Hash { get; }
        
        public SearchStickerSets(
            bool excludeFeatured,
            Some<string> q,
            int hash
        ) {
            ExcludeFeatured = excludeFeatured;
            Q = q;
            Hash = hash;
        }
        
        
        (bool, string, int) CmpTuple =>
            (ExcludeFeatured, Q, Hash);

        public bool Equals(SearchStickerSets other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SearchStickerSets x && Equals(x);
        public static bool operator ==(SearchStickerSets x, SearchStickerSets y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SearchStickerSets x, SearchStickerSets y) => !(x == y);

        public int CompareTo(SearchStickerSets other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SearchStickerSets x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SearchStickerSets x, SearchStickerSets y) => x.CompareTo(y) <= 0;
        public static bool operator <(SearchStickerSets x, SearchStickerSets y) => x.CompareTo(y) < 0;
        public static bool operator >(SearchStickerSets x, SearchStickerSets y) => x.CompareTo(y) > 0;
        public static bool operator >=(SearchStickerSets x, SearchStickerSets y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ExcludeFeatured: {ExcludeFeatured}, Q: {Q}, Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc2b7d08b);
            Write(MaskBit(0, ExcludeFeatured), bw, WriteInt);
            Write(Q, bw, WriteString);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.FoundStickerSets ITlFunc<T.Messages.FoundStickerSets>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.FoundStickerSets.Deserialize);
    }
}