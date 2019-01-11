using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChannelAdminRights : ITlType, IEquatable<ChannelAdminRights>, IComparable<ChannelAdminRights>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x5d7ceba5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool ChangeInfo;
            public readonly bool PostMessages;
            public readonly bool EditMessages;
            public readonly bool DeleteMessages;
            public readonly bool BanUsers;
            public readonly bool InviteUsers;
            public readonly bool InviteLink;
            public readonly bool PinMessages;
            public readonly bool AddAdmins;
            public readonly bool ManageCall;
            
            public Tag(
                bool changeInfo,
                bool postMessages,
                bool editMessages,
                bool deleteMessages,
                bool banUsers,
                bool inviteUsers,
                bool inviteLink,
                bool pinMessages,
                bool addAdmins,
                bool manageCall
            ) {
                ChangeInfo = changeInfo;
                PostMessages = postMessages;
                EditMessages = editMessages;
                DeleteMessages = deleteMessages;
                BanUsers = banUsers;
                InviteUsers = inviteUsers;
                InviteLink = inviteLink;
                PinMessages = pinMessages;
                AddAdmins = addAdmins;
                ManageCall = manageCall;
            }
            
            (bool, bool, bool, bool, bool, bool, bool, bool, bool, bool) CmpTuple =>
                (ChangeInfo, PostMessages, EditMessages, DeleteMessages, BanUsers, InviteUsers, InviteLink, PinMessages, AddAdmins, ManageCall);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChangeInfo: {ChangeInfo}, PostMessages: {PostMessages}, EditMessages: {EditMessages}, DeleteMessages: {DeleteMessages}, BanUsers: {BanUsers}, InviteUsers: {InviteUsers}, InviteLink: {InviteLink}, PinMessages: {PinMessages}, AddAdmins: {AddAdmins}, ManageCall: {ManageCall})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, ChangeInfo) | MaskBit(1, PostMessages) | MaskBit(2, EditMessages) | MaskBit(3, DeleteMessages) | MaskBit(4, BanUsers) | MaskBit(5, InviteUsers) | MaskBit(6, InviteLink) | MaskBit(7, PinMessages) | MaskBit(9, AddAdmins) | MaskBit(10, ManageCall), bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var changeInfo = Read(br, ReadOption(flags, 0));
                var postMessages = Read(br, ReadOption(flags, 1));
                var editMessages = Read(br, ReadOption(flags, 2));
                var deleteMessages = Read(br, ReadOption(flags, 3));
                var banUsers = Read(br, ReadOption(flags, 4));
                var inviteUsers = Read(br, ReadOption(flags, 5));
                var inviteLink = Read(br, ReadOption(flags, 6));
                var pinMessages = Read(br, ReadOption(flags, 7));
                var addAdmins = Read(br, ReadOption(flags, 9));
                var manageCall = Read(br, ReadOption(flags, 10));
                return new Tag(changeInfo, postMessages, editMessages, deleteMessages, banUsers, inviteUsers, inviteLink, pinMessages, addAdmins, manageCall);
            }
        }

        readonly ITlTypeTag _tag;
        ChannelAdminRights(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelAdminRights(Tag tag) => new ChannelAdminRights(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelAdminRights Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ChannelAdminRights) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ChannelAdminRights other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChannelAdminRights x && Equals(x);
        public static bool operator ==(ChannelAdminRights x, ChannelAdminRights y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelAdminRights x, ChannelAdminRights y) => !(x == y);

        public int CompareTo(ChannelAdminRights other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChannelAdminRights x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelAdminRights x, ChannelAdminRights y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelAdminRights x, ChannelAdminRights y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelAdminRights x, ChannelAdminRights y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelAdminRights x, ChannelAdminRights y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelAdminRights.{_tag.GetType().Name}{_tag}";
    }
}