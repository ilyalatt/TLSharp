using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ImportContacts : ITlFunc<T.Contacts.ImportedContacts>, IEquatable<ImportContacts>, IComparable<ImportContacts>, IComparable
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
        
        
        (Arr<T.InputContact>, bool) CmpTuple =>
            (Contacts, Replace);

        public bool Equals(ImportContacts other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ImportContacts x && Equals(x);
        public static bool operator ==(ImportContacts x, ImportContacts y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ImportContacts x, ImportContacts y) => !(x == y);

        public int CompareTo(ImportContacts other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ImportContacts x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ImportContacts x, ImportContacts y) => x.CompareTo(y) <= 0;
        public static bool operator <(ImportContacts x, ImportContacts y) => x.CompareTo(y) < 0;
        public static bool operator >(ImportContacts x, ImportContacts y) => x.CompareTo(y) > 0;
        public static bool operator >=(ImportContacts x, ImportContacts y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Contacts: {Contacts}, Replace: {Replace})";
        
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