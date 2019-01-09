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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xc27ac8c7;
            
            public string Command { get; }
            public string Description { get; }
            
            public Tag(
                Some<string> command,
                Some<string> description
            ) {
                Command = command;
                Description = description;
            }
            
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
                case 0xc27ac8c7: return (BotCommand) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xc27ac8c7 });
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

        public bool Equals(BotCommand other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is BotCommand x && Equals(x);
        public static bool operator ==(BotCommand a, BotCommand b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(BotCommand a, BotCommand b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(BotCommand other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is BotCommand x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotCommand a, BotCommand b) => a.CompareTo(b) <= 0;
        public static bool operator <(BotCommand a, BotCommand b) => a.CompareTo(b) < 0;
        public static bool operator >(BotCommand a, BotCommand b) => a.CompareTo(b) > 0;
        public static bool operator >=(BotCommand a, BotCommand b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}