using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class GetCdnFile : Record<GetCdnFile>, ITlFunc<T.Upload.CdnFile>
    {
        public Arr<byte> FileToken { get; }
        public int Offset { get; }
        public int Limit { get; }
        
        public GetCdnFile(
            Some<Arr<byte>> fileToken,
            int offset,
            int limit
        ) {
            FileToken = fileToken;
            Offset = offset;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2000bcc3);
            Write(FileToken, bw, WriteBytes);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Upload.CdnFile ITlFunc<T.Upload.CdnFile>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Upload.CdnFile.Deserialize);
    }
}