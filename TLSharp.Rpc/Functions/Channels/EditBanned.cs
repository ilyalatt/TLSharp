using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class EditBanned : ITlFunc<T.UpdatesType>, IEquatable<EditBanned>, IComparable<EditBanned>, IComparable
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        public T.ChannelBannedRights BannedRights { get; }
        
        public EditBanned(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId,
            Some<T.ChannelBannedRights> bannedRights
        ) {
            Channel = channel;
            UserId = userId;
            BannedRights = bannedRights;
        }
        
        
        (T.InputChannel, T.InputUser, T.ChannelBannedRights) CmpTuple =>
            (Channel, UserId, BannedRights);

        public bool Equals(EditBanned other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is EditBanned x && Equals(x);
        public static bool operator ==(EditBanned x, EditBanned y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditBanned x, EditBanned y) => !(x == y);

        public int CompareTo(EditBanned other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is EditBanned x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditBanned x, EditBanned y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditBanned x, EditBanned y) => x.CompareTo(y) < 0;
        public static bool operator >(EditBanned x, EditBanned y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditBanned x, EditBanned y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, UserId: {UserId}, BannedRights: {BannedRights})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbfd915cd);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
            Write(BannedRights, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}