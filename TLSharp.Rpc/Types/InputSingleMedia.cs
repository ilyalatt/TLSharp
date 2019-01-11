using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputSingleMedia : ITlType, IEquatable<InputSingleMedia>, IComparable<InputSingleMedia>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x1cc6e91f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputMedia Media;
            public readonly long RandomId;
            public readonly string Message;
            public readonly Option<Arr<T.MessageEntity>> Entities;
            
            public Tag(
                Some<T.InputMedia> media,
                long randomId,
                Some<string> message,
                Option<Arr<T.MessageEntity>> entities
            ) {
                Media = media;
                RandomId = randomId;
                Message = message;
                Entities = entities;
            }
            
            (T.InputMedia, long, string, Option<Arr<T.MessageEntity>>) CmpTuple =>
                (Media, RandomId, Message, Entities);

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

            public override string ToString() => $"(Media: {Media}, RandomId: {RandomId}, Message: {Message}, Entities: {Entities})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Entities), bw, WriteInt);
                Write(Media, bw, WriteSerializable);
                Write(RandomId, bw, WriteLong);
                Write(Message, bw, WriteString);
                Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var media = Read(br, T.InputMedia.Deserialize);
                var randomId = Read(br, ReadLong);
                var message = Read(br, ReadString);
                var entities = Read(br, ReadOption(flags, 0, ReadVector(T.MessageEntity.Deserialize)));
                return new Tag(media, randomId, message, entities);
            }
        }

        readonly ITlTypeTag _tag;
        InputSingleMedia(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputSingleMedia(Tag tag) => new InputSingleMedia(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputSingleMedia Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputSingleMedia) Tag.DeserializeTag(br);
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

        public bool Equals(InputSingleMedia other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputSingleMedia x && Equals(x);
        public static bool operator ==(InputSingleMedia x, InputSingleMedia y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputSingleMedia x, InputSingleMedia y) => !(x == y);

        public int CompareTo(InputSingleMedia other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputSingleMedia x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputSingleMedia x, InputSingleMedia y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputSingleMedia x, InputSingleMedia y) => x.CompareTo(y) < 0;
        public static bool operator >(InputSingleMedia x, InputSingleMedia y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputSingleMedia x, InputSingleMedia y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputSingleMedia.{_tag.GetType().Name}{_tag}";
    }
}