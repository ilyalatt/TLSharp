using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class ReuploadCdnFile : ITlFunc<Arr<T.FileHash>>, IEquatable<ReuploadCdnFile>, IComparable<ReuploadCdnFile>, IComparable
    {
        public Arr<byte> FileToken { get; }
        public Arr<byte> RequestToken { get; }
        
        public ReuploadCdnFile(
            Some<Arr<byte>> fileToken,
            Some<Arr<byte>> requestToken
        ) {
            FileToken = fileToken;
            RequestToken = requestToken;
        }
        
        
        (Arr<byte>, Arr<byte>) CmpTuple =>
            (FileToken, RequestToken);

        public bool Equals(ReuploadCdnFile other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReuploadCdnFile x && Equals(x);
        public static bool operator ==(ReuploadCdnFile x, ReuploadCdnFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReuploadCdnFile x, ReuploadCdnFile y) => !(x == y);

        public int CompareTo(ReuploadCdnFile other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReuploadCdnFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReuploadCdnFile x, ReuploadCdnFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReuploadCdnFile x, ReuploadCdnFile y) => x.CompareTo(y) < 0;
        public static bool operator >(ReuploadCdnFile x, ReuploadCdnFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReuploadCdnFile x, ReuploadCdnFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(FileToken: {FileToken}, RequestToken: {RequestToken})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9b2754a8);
            Write(FileToken, bw, WriteBytes);
            Write(RequestToken, bw, WriteBytes);
        }
        
        Arr<T.FileHash> ITlFunc<Arr<T.FileHash>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.FileHash.Deserialize));
    }
}