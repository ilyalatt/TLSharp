using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Photos
{
    public sealed class GetUserPhotos : Record<GetUserPhotos>, ITlFunc<T.Photos.Photos>
    {
        public T.InputUser UserId { get; }
        public int Offset { get; }
        public long MaxId { get; }
        public int Limit { get; }
        
        public GetUserPhotos(
            Some<T.InputUser> userId,
            int offset,
            long maxId,
            int limit
        ) {
            UserId = userId;
            Offset = offset;
            MaxId = maxId;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x91cd32a8);
            Write(UserId, bw, WriteSerializable);
            Write(Offset, bw, WriteInt);
            Write(MaxId, bw, WriteLong);
            Write(Limit, bw, WriteInt);
        }
        
        T.Photos.Photos ITlFunc<T.Photos.Photos>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Photos.Photos.Deserialize);
    }
}