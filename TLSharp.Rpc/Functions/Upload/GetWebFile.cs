using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class GetWebFile : Record<GetWebFile>, ITlFunc<T.Upload.WebFile>
    {
        public T.InputWebFileLocation Location { get; }
        public int Offset { get; }
        public int Limit { get; }
        
        public GetWebFile(
            Some<T.InputWebFileLocation> location,
            int offset,
            int limit
        ) {
            Location = location;
            Offset = offset;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x24e6818d);
            Write(Location, bw, WriteSerializable);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Upload.WebFile ITlFunc<T.Upload.WebFile>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Upload.WebFile.Deserialize);
    }
}