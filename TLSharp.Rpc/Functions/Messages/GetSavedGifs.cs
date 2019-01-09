using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetSavedGifs : Record<GetSavedGifs>, ITlFunc<T.Messages.SavedGifs>
    {
        public int Hash { get; }
        
        public GetSavedGifs(
            int hash
        ) {
            Hash = hash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x83bf3d52);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.SavedGifs ITlFunc<T.Messages.SavedGifs>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.SavedGifs.Deserialize);
    }
}