using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetDocumentByHash : Record<GetDocumentByHash>, ITlFunc<T.Document>
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