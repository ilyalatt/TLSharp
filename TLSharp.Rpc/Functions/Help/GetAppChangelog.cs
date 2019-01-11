using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetAppChangelog : ITlFunc<T.UpdatesType>, IEquatable<GetAppChangelog>, IComparable<GetAppChangelog>, IComparable
    {
        public string PrevAppVersion { get; }
        
        public GetAppChangelog(
            Some<string> prevAppVersion
        ) {
            PrevAppVersion = prevAppVersion;
        }
        
        
        string CmpTuple =>
            PrevAppVersion;

        public bool Equals(GetAppChangelog other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetAppChangelog x && Equals(x);
        public static bool operator ==(GetAppChangelog x, GetAppChangelog y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAppChangelog x, GetAppChangelog y) => !(x == y);

        public int CompareTo(GetAppChangelog other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetAppChangelog x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAppChangelog x, GetAppChangelog y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAppChangelog x, GetAppChangelog y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAppChangelog x, GetAppChangelog y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAppChangelog x, GetAppChangelog y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PrevAppVersion: {PrevAppVersion})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9010ef6f);
            Write(PrevAppVersion, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}