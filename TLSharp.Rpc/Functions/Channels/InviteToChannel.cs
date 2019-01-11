using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class InviteToChannel : ITlFunc<T.UpdatesType>, IEquatable<InviteToChannel>, IComparable<InviteToChannel>, IComparable
    {
        public T.InputChannel Channel { get; }
        public Arr<T.InputUser> Users { get; }
        
        public InviteToChannel(
            Some<T.InputChannel> channel,
            Some<Arr<T.InputUser>> users
        ) {
            Channel = channel;
            Users = users;
        }
        
        
        (T.InputChannel, Arr<T.InputUser>) CmpTuple =>
            (Channel, Users);

        public bool Equals(InviteToChannel other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is InviteToChannel x && Equals(x);
        public static bool operator ==(InviteToChannel x, InviteToChannel y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InviteToChannel x, InviteToChannel y) => !(x == y);

        public int CompareTo(InviteToChannel other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InviteToChannel x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InviteToChannel x, InviteToChannel y) => x.CompareTo(y) <= 0;
        public static bool operator <(InviteToChannel x, InviteToChannel y) => x.CompareTo(y) < 0;
        public static bool operator >(InviteToChannel x, InviteToChannel y) => x.CompareTo(y) > 0;
        public static bool operator >=(InviteToChannel x, InviteToChannel y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Users: {Users})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x199f3a6c);
            Write(Channel, bw, WriteSerializable);
            Write(Users, bw, WriteVector<T.InputUser>(WriteSerializable));
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}