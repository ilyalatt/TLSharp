using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChannelAdminLogEventsFilter : ITlType, IEquatable<ChannelAdminLogEventsFilter>, IComparable<ChannelAdminLogEventsFilter>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xea107ae4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Join;
            public readonly bool Leave;
            public readonly bool Invite;
            public readonly bool Ban;
            public readonly bool Unban;
            public readonly bool Kick;
            public readonly bool Unkick;
            public readonly bool Promote;
            public readonly bool Demote;
            public readonly bool Info;
            public readonly bool Settings;
            public readonly bool Pinned;
            public readonly bool Edit;
            public readonly bool Delete;
            
            public Tag(
                bool join,
                bool leave,
                bool invite,
                bool ban,
                bool unban,
                bool kick,
                bool unkick,
                bool promote,
                bool demote,
                bool info,
                bool settings,
                bool pinned,
                bool edit,
                bool delete
            ) {
                Join = join;
                Leave = leave;
                Invite = invite;
                Ban = ban;
                Unban = unban;
                Kick = kick;
                Unkick = unkick;
                Promote = promote;
                Demote = demote;
                Info = info;
                Settings = settings;
                Pinned = pinned;
                Edit = edit;
                Delete = delete;
            }
            
            (bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool) CmpTuple =>
                (Join, Leave, Invite, Ban, Unban, Kick, Unkick, Promote, Demote, Info, Settings, Pinned, Edit, Delete);

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

            public override string ToString() => $"(Join: {Join}, Leave: {Leave}, Invite: {Invite}, Ban: {Ban}, Unban: {Unban}, Kick: {Kick}, Unkick: {Unkick}, Promote: {Promote}, Demote: {Demote}, Info: {Info}, Settings: {Settings}, Pinned: {Pinned}, Edit: {Edit}, Delete: {Delete})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Join) | MaskBit(1, Leave) | MaskBit(2, Invite) | MaskBit(3, Ban) | MaskBit(4, Unban) | MaskBit(5, Kick) | MaskBit(6, Unkick) | MaskBit(7, Promote) | MaskBit(8, Demote) | MaskBit(9, Info) | MaskBit(10, Settings) | MaskBit(11, Pinned) | MaskBit(12, Edit) | MaskBit(13, Delete), bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var join = Read(br, ReadOption(flags, 0));
                var leave = Read(br, ReadOption(flags, 1));
                var invite = Read(br, ReadOption(flags, 2));
                var ban = Read(br, ReadOption(flags, 3));
                var unban = Read(br, ReadOption(flags, 4));
                var kick = Read(br, ReadOption(flags, 5));
                var unkick = Read(br, ReadOption(flags, 6));
                var promote = Read(br, ReadOption(flags, 7));
                var demote = Read(br, ReadOption(flags, 8));
                var info = Read(br, ReadOption(flags, 9));
                var settings = Read(br, ReadOption(flags, 10));
                var pinned = Read(br, ReadOption(flags, 11));
                var edit = Read(br, ReadOption(flags, 12));
                var delete = Read(br, ReadOption(flags, 13));
                return new Tag(join, leave, invite, ban, unban, kick, unkick, promote, demote, info, settings, pinned, edit, delete);
            }
        }

        readonly ITlTypeTag _tag;
        ChannelAdminLogEventsFilter(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelAdminLogEventsFilter(Tag tag) => new ChannelAdminLogEventsFilter(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelAdminLogEventsFilter Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ChannelAdminLogEventsFilter) Tag.DeserializeTag(br);
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

        public bool Equals(ChannelAdminLogEventsFilter other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChannelAdminLogEventsFilter x && Equals(x);
        public static bool operator ==(ChannelAdminLogEventsFilter x, ChannelAdminLogEventsFilter y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelAdminLogEventsFilter x, ChannelAdminLogEventsFilter y) => !(x == y);

        public int CompareTo(ChannelAdminLogEventsFilter other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChannelAdminLogEventsFilter x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelAdminLogEventsFilter x, ChannelAdminLogEventsFilter y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelAdminLogEventsFilter x, ChannelAdminLogEventsFilter y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelAdminLogEventsFilter x, ChannelAdminLogEventsFilter y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelAdminLogEventsFilter x, ChannelAdminLogEventsFilter y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelAdminLogEventsFilter.{_tag.GetType().Name}{_tag}";
    }
}