using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SaveGif : Record<SaveGif>, ITlFunc<bool>
    {
        public T.InputDocument Id { get; }
        public bool Unsave { get; }
        
        public SaveGif(
            Some<T.InputDocument> id,
            bool unsave
        ) {
            Id = id;
            Unsave = unsave;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x327a30cb);
            Write(Id, bw, WriteSerializable);
            Write(Unsave, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}