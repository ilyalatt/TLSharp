using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ImportContacts : Record<ImportContacts>, ITlFunc<T.Contacts.ImportedContacts>
    {
        public Arr<T.InputContact> Contacts { get; }
        public bool Replace { get; }
        
        public ImportContacts(
            Some<Arr<T.InputContact>> contacts,
            bool replace
        ) {
            Contacts = contacts;
            Replace = replace;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xda30b32d);
            Write(Contacts, bw, WriteVector<T.InputContact>(WriteSerializable));
            Write(Replace, bw, WriteBool);
        }
        
        T.Contacts.ImportedContacts ITlFunc<T.Contacts.ImportedContacts>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.ImportedContacts.Deserialize);
    }
}