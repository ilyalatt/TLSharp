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
        public T.ChannelAdminRights AdminRights { get; }
        
        public EditAdmin(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId,
            Some<T.ChannelAdminRights> adminRights
        ) {
            Channel = channel;
            UserId = userId;
            AdminRights = adminRights;
        }
        
        
        (T.InputChannel, T.InputUser, T.ChannelAdminRights) CmpTuple =>
            (Channel, UserId, AdminRights);

        public bool Equals(EditAdmin other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is EditAdmin x && Equals(x);
        public static bool operator ==(EditAdmin x, EditAdmin y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditAdmin x, EditAdmin y) => !(x == y);

        public int CompareTo(EditAdmin other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is EditAdmin x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditAdmin x, EditAdmin y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditAdmin x, EditAdmin y) => x.CompareTo(y) < 0;
        public static bool operator >(EditAdmin x, EditAdmin y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditAdmin x, EditAdmin y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, UserId: {UserId}, AdminRights: {AdminRights})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x20b88214);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
            Write(AdminRights, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}