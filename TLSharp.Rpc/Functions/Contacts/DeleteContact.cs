using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class DeleteContact : Record<DeleteContact>, ITlFunc<T.Contacts.Link>
    {
        public T.InputUser Id { get; }
        
        public DeleteContact(
            Some<T.InputUser> id
        ) {
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8e953744);
            Write(Id, bw, WriteSerializable);
        }
        
        T.Contacts.Link ITlFunc<T.Contacts.Link>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.Link.Deserialize);
    }
}