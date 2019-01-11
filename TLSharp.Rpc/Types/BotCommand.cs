using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class BotCommand : ITlType, IEquatable<BotCommand>, IComparable<BotCommand>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xc27ac8c7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Command { get; }
            public string Description { get; }
            
            public Tag(
                Some<string> command,
                Some<string> description
            ) {
                Command = command;
                Description = description;
            }
            
            (string, string) CmpTuple =>
                (Command, Description);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Command: {Command}, Description: {Description})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Command, bw, WriteString);
                Write(Description, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var command = Read(br, ReadString);
                var description = Read(br, ReadString);
                return new Tag(command, description);
            }
        }

        readonly ITlTypeTag _tag;
        BotCommand(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator BotCommand(Tag tag) => new BotCommand(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static BotCommand Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (BotCommand) Tag.DeserializeTag(br);
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

        public bool Equals(BotCommand other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is BotCommand x && Equals(x);
        public static bool operator ==(BotCommand x, BotCommand y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(BotCommand x, BotCommand y) => !(x == y);

        public int CompareTo(BotCommand other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is BotCommand x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotCommand x, BotCommand y) => x.CompareTo(y) <= 0;
        public static bool operator <(BotCommand x, BotCommand y) => x.CompareTo(y) < 0;
        public static bool operator >(BotCommand x, BotCommand y) => x.CompareTo(y) > 0;
        public static bool operator >=(BotCommand x, BotCommand y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"BotCommand.{_tag.GetType().Name}{_tag}";
    }
}