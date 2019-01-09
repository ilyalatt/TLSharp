using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Photos
{
    public sealed class DeletePhotos : Record<DeletePhotos>, ITlFunc<Arr<long>>
    {
        public Arr<T.InputPhoto> Id { get; }
        
        public DeletePhotos(
            Some<Arr<T.InputPhoto>> id
        ) {
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x87cf7f2f);
            Write(Id, bw, WriteVector<T.InputPhoto>(WriteSerializable));
        }
        
        Arr<long> ITlFunc<Arr<long>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(ReadLong));
    }
}