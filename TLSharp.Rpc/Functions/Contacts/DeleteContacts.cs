using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class DeleteContacts : ITlFunc<bool>, IEquatable<DeleteContacts>, IComparable<DeleteContacts>, IComparable
    {
        public Arr<T.InputUser> Id { get; }
        
        public DeleteContacts(
            Some<Arr<T.InputUser>> id
        ) {
            Id = id;
        }
        
        
        Arr<T.InputUser> CmpTuple =>
            Id;

        public bool Equals(DeleteContacts other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DeleteContacts x && Equals(x);
        public static bool operator ==(DeleteContacts x, DeleteContacts y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeleteContacts x, DeleteContacts y) => !(x == y);

        public int CompareTo(DeleteContacts other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DeleteContacts x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeleteContacts x, DeleteContacts y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeleteContacts x, DeleteContacts y) => x.CompareTo(y) < 0;
        public static bool operator >(DeleteContacts x, DeleteContacts y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeleteContacts x, DeleteContacts y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x59ab389e);
            Write(Id, bw, WriteVector<T.InputUser>(WriteSerializable));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}