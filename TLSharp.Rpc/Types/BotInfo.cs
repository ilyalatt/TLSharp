using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class BotInfo : ITlType, IEquatable<BotInfo>, IComparable<BotInfo>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x98e81d3a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int UserId;
            public readonly string Description;
            public readonly Arr<T.BotCommand> Commands;
            
            public Tag(
                int userId,
                Some<string> description,
                Some<Arr<T.BotCommand>> commands
            ) {
                UserId = userId;
                Description = description;
                Commands = commands;
            }
            
            (int, string, Arr<T.BotCommand>) CmpTuple =>
                (UserId, Description, Commands);

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

            public override string ToString() => $"(UserId: {UserId}, Description: {Description}, Commands: {Commands})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(Description, bw, WriteString);
                Write(Commands, bw, WriteVector<T.BotCommand>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var description = Read(br, ReadString);
                var commands = Read(br, ReadVector(T.BotCommand.Deserialize));
                return new Tag(userId, description, commands);
            }
        }

        readonly ITlTypeTag _tag;
        BotInfo(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator BotInfo(Tag tag) => new BotInfo(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static BotInfo Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (BotInfo) Tag.DeserializeTag(br);
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

        public bool Equals(BotInfo other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is BotInfo x && Equals(x);
        public static bool operator ==(BotInfo x, BotInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(BotInfo x, BotInfo y) => !(x == y);

        public int CompareTo(BotInfo other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is BotInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotInfo x, BotInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(BotInfo x, BotInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(BotInfo x, BotInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(BotInfo x, BotInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"BotInfo.{_tag.GetType().Name}{_tag}";
    }
}