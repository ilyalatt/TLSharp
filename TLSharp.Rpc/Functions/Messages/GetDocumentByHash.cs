using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetDocumentByHash : ITlFunc<T.Document>, IEquatable<GetDocumentByHash>, IComparable<GetDocumentByHash>, IComparable
    {
        public Arr<byte> Sha256 { get; }
        public int Size { get; }
        public string MimeType { get; }
        
        public GetDocumentByHash(
            Some<Arr<byte>> sha256,
            int size,
            Some<string> mimeType
        ) {
            Sha256 = sha256;
            Size = size;
            MimeType = mimeType;
        }
        
        
        (Arr<byte>, int, string) CmpTuple =>
            (Sha256, Size, MimeType);

        public bool Equals(GetDocumentByHash other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetDocumentByHash x && Equals(x);
        public static bool operator ==(GetDocumentByHash x, GetDocumentByHash y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetDocumentByHash x, GetDocumentByHash y) => !(x == y);

        public int CompareTo(GetDocumentByHash other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetDocumentByHash x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetDocumentByHash x, GetDocumentByHash y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetDocumentByHash x, GetDocumentByHash y) => x.CompareTo(y) < 0;
        public static bool operator >(GetDocumentByHash x, GetDocumentByHash y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetDocumentByHash x, GetDocumentByHash y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Sha256: {Sha256}, Size: {Size}, MimeType: {MimeType})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x338e2464);
            Write(Sha256, bw, WriteBytes);
            Write(Size, bw, WriteInt);
            Write(MimeType, bw, WriteString);
        }
        
        T.Document ITlFunc<T.Document>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Document.Deserialize);
    }
}