using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Help
{
    public sealed class DeepLinkInfo : ITlType, IEquatable<DeepLinkInfo>, IComparable<DeepLinkInfo>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x66afa166;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x6a4ee832;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool UpdateApp;
            public readonly string Message;
            public readonly Option<Arr<T.MessageEntity>> Entities;
            
            public Tag(
                bool updateApp,
                Some<string> message,
                Option<Arr<T.MessageEntity>> entities
            ) {
                UpdateApp = updateApp;
                Message = message;
                Entities = entities;
            }
            
            (bool, string, Option<Arr<T.MessageEntity>>) CmpTuple =>
                (UpdateApp, Message, Entities);

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

            public override string ToString() => $"(UpdateApp: {UpdateApp}, Message: {Message}, Entities: {Entities})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, UpdateApp) | MaskBit(1, Entities), bw, WriteInt);
                Write(Message, bw, WriteString);
                Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var updateApp = Read(br, ReadOption(flags, 0));
                var message = Read(br, ReadString);
                var entities = Read(br, ReadOption(flags, 1, ReadVector(T.MessageEntity.Deserialize)));
                return new Tag(updateApp, message, entities);
            }
        }

        readonly ITlTypeTag _tag;
        DeepLinkInfo(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator DeepLinkInfo(EmptyTag tag) => new DeepLinkInfo(tag);
        public static explicit operator DeepLinkInfo(Tag tag) => new DeepLinkInfo(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static DeepLinkInfo Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (DeepLinkInfo) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (DeepLinkInfo) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(DeepLinkInfo other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is DeepLinkInfo x && Equals(x);
        public static bool operator ==(DeepLinkInfo x, DeepLinkInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeepLinkInfo x, DeepLinkInfo y) => !(x == y);

        public int CompareTo(DeepLinkInfo other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is DeepLinkInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeepLinkInfo x, DeepLinkInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeepLinkInfo x, DeepLinkInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(DeepLinkInfo x, DeepLinkInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeepLinkInfo x, DeepLinkInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"DeepLinkInfo.{_tag.GetType().Name}{_tag}";
    }
}