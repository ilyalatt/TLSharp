using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class ImportAuthorization : Record<ImportAuthorization>, ITlFunc<T.Auth.Authorization>
    {
        public int Id { get; }
        public Arr<byte> Bytes { get; }
        
        public ImportAuthorization(
            int id,
            Some<Arr<byte>> bytes
        ) {
            Id = id;
            Bytes = bytes;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe3ef9613);
            Write(Id, bw, WriteInt);
            Write(Bytes, bw, WriteBytes);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}