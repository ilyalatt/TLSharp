using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class GetFile : Record<GetFile>, ITlFunc<T.Upload.File>
    {
        public T.InputFileLocation Location { get; }
        public int Offset { get; }
        public int Limit { get; }
        
        public GetFile(
            Some<T.InputFileLocation> location,
            int offset,
            int limit
        ) {
            Location = location;
            Offset = offset;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe3a6cfb5);
            Write(Location, bw, WriteSerializable);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Upload.File ITlFunc<T.Upload.File>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Upload.File.Deserialize);
    }
}