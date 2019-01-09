using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class SaveBigFilePart : Record<SaveBigFilePart>, ITlFunc<bool>
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