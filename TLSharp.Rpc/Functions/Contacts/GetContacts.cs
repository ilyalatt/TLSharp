using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class GetContacts : Record<GetContacts>, ITlFunc<T.Contacts.Contacts>
    {
        public string Hash { get; }
        
        public GetContacts(
            Some<string> hash
        ) {
            Hash = hash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x22c6aa08);
            Write(Hash, bw, WriteString);
        }
        
        T.Contacts.Contacts ITlFunc<T.Contacts.Contacts>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.Contacts.Deserialize);
    }
}