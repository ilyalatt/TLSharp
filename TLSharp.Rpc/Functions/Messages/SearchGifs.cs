using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SearchGifs : ITlFunc<T.Messages.FoundGifs>, IEquatable<SearchGifs>, IComparable<SearchGifs>, IComparable
    {
        public string Q { get; }
        public int Offset { get; }
        
        public SearchGifs(
            Some<string> q,
            int offset
        ) {
            Q = q;
            Offset = offset;
        }
        
        
        (string, int) CmpTuple =>
            (Q, Offset);

        public bool Equals(SearchGifs other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SearchGifs x && Equals(x);
        public static bool operator ==(SearchGifs x, SearchGifs y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SearchGifs x, SearchGifs y) => !(x == y);

        public int CompareTo(SearchGifs other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SearchGifs x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SearchGifs x, SearchGifs y) => x.CompareTo(y) <= 0;
        public static bool operator <(SearchGifs x, SearchGifs y) => x.CompareTo(y) < 0;
        public static bool operator >(SearchGifs x, SearchGifs y) => x.CompareTo(y) > 0;
        public static bool operator >=(SearchGifs x, SearchGifs y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Q: {Q}, Offset: {Offset})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbf9a776b);
            Write(Q, bw, WriteString);
            Write(Offset, bw, WriteInt);
        }
        
        T.Messages.FoundGifs ITlFunc<T.Messages.FoundGifs>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.FoundGifs.Deserialize);
    }
}