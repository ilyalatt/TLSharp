using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetWebPage : ITlFunc<T.WebPage>, IEquatable<GetWebPage>, IComparable<GetWebPage>, IComparable
    {
        public string Url { get; }
        public int Hash { get; }
        
        public GetWebPage(
            Some<string> url,
            int hash
        ) {
            Url = url;
            Hash = hash;
        }
        
        
        (string, int) CmpTuple =>
            (Url, Hash);

        public bool Equals(GetWebPage other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetWebPage x && Equals(x);
        public static bool operator ==(GetWebPage x, GetWebPage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetWebPage x, GetWebPage y) => !(x == y);

        public int CompareTo(GetWebPage other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetWebPage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetWebPage x, GetWebPage y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetWebPage x, GetWebPage y) => x.CompareTo(y) < 0;
        public static bool operator >(GetWebPage x, GetWebPage y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetWebPage x, GetWebPage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Url: {Url}, Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x32ca8f91);
            Write(Url, bw, WriteString);
            Write(Hash, bw, WriteInt);
        }
        
        T.WebPage ITlFunc<T.WebPage>.DeserializeResult(BinaryReader br) =>
            Read(br, T.WebPage.Deserialize);
    }
}