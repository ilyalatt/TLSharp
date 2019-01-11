using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class SaveBigFilePart : ITlFunc<bool>, IEquatable<SaveBigFilePart>, IComparable<SaveBigFilePart>, IComparable
    {
        public long FileId { get; }
        public int FilePart { get; }
        public int FileTotalParts { get; }
        public Arr<byte> Bytes { get; }
        
        public SaveBigFilePart(
            long fileId,
            int filePart,
            int fileTotalParts,
            Some<Arr<byte>> bytes
        ) {
            FileId = fileId;
            FilePart = filePart;
            FileTotalParts = fileTotalParts;
            Bytes = bytes;
        }
        
        
        (long, int, int, Arr<byte>) CmpTuple =>
            (FileId, FilePart, FileTotalParts, Bytes);

        public bool Equals(SaveBigFilePart other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SaveBigFilePart x && Equals(x);
        public static bool operator ==(SaveBigFilePart x, SaveBigFilePart y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SaveBigFilePart x, SaveBigFilePart y) => !(x == y);

        public int CompareTo(SaveBigFilePart other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SaveBigFilePart x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SaveBigFilePart x, SaveBigFilePart y) => x.CompareTo(y) <= 0;
        public static bool operator <(SaveBigFilePart x, SaveBigFilePart y) => x.CompareTo(y) < 0;
        public static bool operator >(SaveBigFilePart x, SaveBigFilePart y) => x.CompareTo(y) > 0;
        public static bool operator >=(SaveBigFilePart x, SaveBigFilePart y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(FileId: {FileId}, FilePart: {FilePart}, FileTotalParts: {FileTotalParts}, Bytes: {Bytes})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xde7b673d);
            Write(FileId, bw, WriteLong);
            Write(FilePart, bw, WriteInt);
            Write(FileTotalParts, bw, WriteInt);
            Write(Bytes, bw, WriteBytes);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}