using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class DeleteContacts : Record<DeleteContacts>, ITlFunc<bool>
    {
        public Arr<T.InputUser> Id { get; }
        
        public DeleteContacts(
            Some<Arr<T.InputUser>> id
        ) {
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x59ab389e);
            Write(Id, bw, WriteVector<T.InputUser>(WriteSerializable));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}