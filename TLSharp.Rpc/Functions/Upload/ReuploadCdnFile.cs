using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class ReuploadCdnFile : Record<ReuploadCdnFile>, ITlFunc<bool>
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
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2e7a2020);
            Write(FileToken, bw, WriteBytes);
            Write(RequestToken, bw, WriteBytes);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}