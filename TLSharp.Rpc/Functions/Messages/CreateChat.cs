using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class CreateChat : ITlFunc<T.UpdatesType>, IEquatable<CreateChat>, IComparable<CreateChat>, IComparable
    {
        public Arr<T.InputUser> Users { get; }
        public string Title { get; }
        
        public CreateChat(
            Some<Arr<T.InputUser>> users,
            Some<string> title
        ) {
            Users = users;
            Title = title;
        }
        
        
        (Arr<T.InputUser>, string) CmpTuple =>
            (Users, Title);

        public bool Equals(CreateChat other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is CreateChat x && Equals(x);
        public static bool operator ==(CreateChat x, CreateChat y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CreateChat x, CreateChat y) => !(x == y);

        public int CompareTo(CreateChat other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is CreateChat x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CreateChat x, CreateChat y) => x.CompareTo(y) <= 0;
        public static bool operator <(CreateChat x, CreateChat y) => x.CompareTo(y) < 0;
        public static bool operator >(CreateChat x, CreateChat y) => x.CompareTo(y) > 0;
        public static bool operator >=(CreateChat x, CreateChat y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Users: {Users}, Title: {Title})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x09cb126e);
            Write(Users, bw, WriteVector<T.InputUser>(WriteSerializable));
            Write(Title, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}