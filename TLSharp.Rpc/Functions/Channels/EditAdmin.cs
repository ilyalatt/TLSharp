using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class EditAdmin : ITlFunc<T.UpdatesType>, IEquatable<EditAdmin>, IComparable<EditAdmin>, IComparable
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        public T.ChannelParticipantRole Role { get; }
        
        public EditAdmin(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId,
            Some<T.ChannelParticipantRole> role
        ) {
            Channel = channel;
            UserId = userId;
            Role = role;
        }
        
        
        (T.InputChannel, T.InputUser, T.ChannelParticipantRole) CmpTuple =>
            (Channel, UserId, Role);

        public bool Equals(EditAdmin other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is EditAdmin x && Equals(x);
        public static bool operator ==(EditAdmin x, EditAdmin y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditAdmin x, EditAdmin y) => !(x == y);

        public int CompareTo(EditAdmin other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is EditAdmin x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditAdmin x, EditAdmin y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditAdmin x, EditAdmin y) => x.CompareTo(y) < 0;
        public static bool operator >(EditAdmin x, EditAdmin y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditAdmin x, EditAdmin y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, UserId: {UserId}, Role: {Role})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xeb7611d0);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
            Write(Role, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}