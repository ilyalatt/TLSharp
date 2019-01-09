using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SaveRecentSticker : Record<SaveRecentSticker>, ITlFunc<bool>
    {
        public bool Attached { get; }
        public T.InputDocument Id { get; }
        public bool Unsave { get; }
        
        public SaveRecentSticker(
            bool attached,
            Some<T.InputDocument> id,
            bool unsave
        ) {
            Attached = attached;
            Id = id;
            Unsave = unsave;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x392718f8);
            Write(MaskBit(0, Attached), bw, WriteInt);
            Write(Id, bw, WriteSerializable);
            Write(Unsave, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}