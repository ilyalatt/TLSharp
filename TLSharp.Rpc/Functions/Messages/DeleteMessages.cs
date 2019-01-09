using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class DeleteMessages : Record<DeleteMessages>, ITlFunc<T.Messages.AffectedMessages>
    {
        public bool Revoke { get; }
        public Arr<int> Id { get; }
        
        public DeleteMessages(
            bool revoke,
            Some<Arr<int>> id
        ) {
            Revoke = revoke;
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe58e95d2);
            Write(MaskBit(0, Revoke), bw, WriteInt);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        T.Messages.AffectedMessages ITlFunc<T.Messages.AffectedMessages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedMessages.Deserialize);
    }
}