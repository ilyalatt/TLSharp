using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class SaveFilePart : Record<SaveFilePart>, ITlFunc<bool>
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