using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChannelAdminLogEvent : ITlType, IEquatable<ChannelAdminLogEvent>, IComparable<ChannelAdminLogEvent>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x3b5a3e40;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly int Date;
            public readonly int UserId;
            public readonly T.ChannelAdminLogEventAction Action;
            
            public Tag(
                long id,
                int date,
                int userId,
                Some<T.ChannelAdminLogEventAction> action
            ) {
                Id = id;
                Date = date;
                UserId = userId;
                Action = action;
            }
            
            (long, int, int, T.ChannelAdminLogEventAction) CmpTuple =>
                (Id, Date, UserId, Action);

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

            public override string ToString() => $"(Id: {Id}, Date: {Date}, UserId: {UserId}, Action: {Action})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(Date, bw, WriteInt);
                Write(UserId, bw, WriteInt);
                Write(Action, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                var userId = Read(br, ReadInt);
                var action = Read(br, T.ChannelAdminLogEventAction.Deserialize);
                return new Tag(id, date, userId, action);
            }
        }

        readonly ITlTypeTag _tag;
        ChannelAdminLogEvent(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelAdminLogEvent(Tag tag) => new ChannelAdminLogEvent(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelAdminLogEvent Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ChannelAdminLogEvent) Tag.DeserializeTag(br);
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

        public bool Equals(ChannelAdminLogEvent other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChannelAdminLogEvent x && Equals(x);
        public static bool operator ==(ChannelAdminLogEvent x, ChannelAdminLogEvent y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelAdminLogEvent x, ChannelAdminLogEvent y) => !(x == y);

        public int CompareTo(ChannelAdminLogEvent other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChannelAdminLogEvent x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelAdminLogEvent x, ChannelAdminLogEvent y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelAdminLogEvent x, ChannelAdminLogEvent y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelAdminLogEvent x, ChannelAdminLogEvent y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelAdminLogEvent x, ChannelAdminLogEvent y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelAdminLogEvent.{_tag.GetType().Name}{_tag}";
    }
}