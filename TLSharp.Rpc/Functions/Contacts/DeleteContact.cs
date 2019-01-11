using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class DeleteContact : ITlFunc<T.Contacts.Link>, IEquatable<DeleteContact>, IComparable<DeleteContact>, IComparable
    {
        public T.InputUser Id { get; }
        
        public DeleteContact(
            Some<T.InputUser> id
        ) {
            Id = id;
        }
        
        
        T.InputUser CmpTuple =>
            Id;

        public bool Equals(DeleteContact other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DeleteContact x && Equals(x);
        public static bool operator ==(DeleteContact x, DeleteContact y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeleteContact x, DeleteContact y) => !(x == y);

        public int CompareTo(DeleteContact other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DeleteContact x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeleteContact x, DeleteContact y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeleteContact x, DeleteContact y) => x.CompareTo(y) < 0;
        public static bool operator >(DeleteContact x, DeleteContact y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeleteContact x, DeleteContact y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8e953744);
            Write(Id, bw, WriteSerializable);
        }
        
        T.Contacts.Link ITlFunc<T.Contacts.Link>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.Link.Deserialize);
    }
}