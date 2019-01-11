using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetDeepLinkInfo : ITlFunc<T.Help.DeepLinkInfo>, IEquatable<GetDeepLinkInfo>, IComparable<GetDeepLinkInfo>, IComparable
    {
        public string Path { get; }
        
        public GetDeepLinkInfo(
            Some<string> path
        ) {
            Path = path;
        }
        
        
        string CmpTuple =>
            Path;

        public bool Equals(GetDeepLinkInfo other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetDeepLinkInfo x && Equals(x);
        public static bool operator ==(GetDeepLinkInfo x, GetDeepLinkInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetDeepLinkInfo x, GetDeepLinkInfo y) => !(x == y);

        public int CompareTo(GetDeepLinkInfo other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetDeepLinkInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetDeepLinkInfo x, GetDeepLinkInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetDeepLinkInfo x, GetDeepLinkInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(GetDeepLinkInfo x, GetDeepLinkInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetDeepLinkInfo x, GetDeepLinkInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Path: {Path})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3fedc75f);
            Write(Path, bw, WriteString);
        }
        
        T.Help.DeepLinkInfo ITlFunc<T.Help.DeepLinkInfo>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.DeepLinkInfo.Deserialize);
    }
}