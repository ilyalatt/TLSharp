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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x98e81d3a;
            
            public int UserId { get; }
            public string Description { get; }
            public Arr<T.BotCommand> Commands { get; }
            
            public Tag(
                int userId,
                Some<string> description,
                Some<Arr<T.BotCommand>> commands
            ) {
                UserId = userId;
                Description = description;
                Commands = commands;
            }
            
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
                case 0x98e81d3a: return (BotInfo) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x98e81d3a });
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

        public bool Equals(BotInfo other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is BotInfo x && Equals(x);
        public static bool operator ==(BotInfo a, BotInfo b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(BotInfo a, BotInfo b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(BotInfo other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is BotInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotInfo a, BotInfo b) => a.CompareTo(b) <= 0;
        public static bool operator <(BotInfo a, BotInfo b) => a.CompareTo(b) < 0;
        public static bool operator >(BotInfo a, BotInfo b) => a.CompareTo(b) > 0;
        public static bool operator >=(BotInfo a, BotInfo b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}