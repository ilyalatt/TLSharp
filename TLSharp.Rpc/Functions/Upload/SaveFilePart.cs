using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class SaveFilePart : ITlFunc<bool>, IEquatable<SaveFilePart>, IComparable<SaveFilePart>, IComparable
    {
        public long FileId { get; }
        public int FilePart { get; }
        public Arr<byte> Bytes { get; }
        
        public SaveFilePart(
            long fileId,
            int filePart,
            Some<Arr<byte>> bytes
        ) {
            FileId = fileId;
            FilePart = filePart;
            Bytes = bytes;
        }
        
        
        (long, int, Arr<byte>) CmpTuple =>
            (FileId, FilePart, Bytes);

        public bool Equals(SaveFilePart other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SaveFilePart x && Equals(x);
        public static bool operator ==(SaveFilePart x, SaveFilePart y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SaveFilePart x, SaveFilePart y) => !(x == y);

        public int CompareTo(SaveFilePart other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SaveFilePart x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SaveFilePart x, SaveFilePart y) => x.CompareTo(y) <= 0;
        public static bool operator <(SaveFilePart x, SaveFilePart y) => x.CompareTo(y) < 0;
        public static bool operator >(SaveFilePart x, SaveFilePart y) => x.CompareTo(y) > 0;
        public static bool operator >=(SaveFilePart x, SaveFilePart y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(FileId: {FileId}, FilePart: {FilePart}, Bytes: {Bytes})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xb304a621);
            Write(FileId, bw, WriteLong);
            Write(FilePart, bw, WriteInt);
            Write(Bytes, bw, WriteBytes);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}