using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetRecentMeUrls : ITlFunc<T.Help.RecentMeUrls>, IEquatable<GetRecentMeUrls>, IComparable<GetRecentMeUrls>, IComparable
    {
        public string Referer { get; }
        
        public GetRecentMeUrls(
            Some<string> referer
        ) {
            Referer = referer;
        }
        
        
        string CmpTuple =>
            Referer;

        public bool Equals(GetRecentMeUrls other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetRecentMeUrls x && Equals(x);
        public static bool operator ==(GetRecentMeUrls x, GetRecentMeUrls y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetRecentMeUrls x, GetRecentMeUrls y) => !(x == y);

        public int CompareTo(GetRecentMeUrls other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetRecentMeUrls x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetRecentMeUrls x, GetRecentMeUrls y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetRecentMeUrls x, GetRecentMeUrls y) => x.CompareTo(y) < 0;
        public static bool operator >(GetRecentMeUrls x, GetRecentMeUrls y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetRecentMeUrls x, GetRecentMeUrls y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Referer: {Referer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3dc0f114);
            Write(Referer, bw, WriteString);
        }
        
        T.Help.RecentMeUrls ITlFunc<T.Help.RecentMeUrls>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.RecentMeUrls.Deserialize);
    }
}