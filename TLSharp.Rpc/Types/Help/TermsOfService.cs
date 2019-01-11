using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Help
{
    public sealed class TermsOfService : ITlType, IEquatable<TermsOfService>, IComparable<TermsOfService>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x780a0310;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Popup;
            public readonly T.DataJson Id;
            public readonly string Text;
            public readonly Arr<T.MessageEntity> Entities;
            public readonly Option<int> MinAgeConfirm;
            
            public Tag(
                bool popup,
                Some<T.DataJson> id,
                Some<string> text,
                Some<Arr<T.MessageEntity>> entities,
                Option<int> minAgeConfirm
            ) {
                Popup = popup;
                Id = id;
                Text = text;
                Entities = entities;
                MinAgeConfirm = minAgeConfirm;
            }
            
            (bool, T.DataJson, string, Arr<T.MessageEntity>, Option<int>) CmpTuple =>
                (Popup, Id, Text, Entities, MinAgeConfirm);

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

            public override string ToString() => $"(Popup: {Popup}, Id: {Id}, Text: {Text}, Entities: {Entities}, MinAgeConfirm: {MinAgeConfirm})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Popup) | MaskBit(1, MinAgeConfirm), bw, WriteInt);
                Write(Id, bw, WriteSerializable);
                Write(Text, bw, WriteString);
                Write(Entities, bw, WriteVector<T.MessageEntity>(WriteSerializable));
                Write(MinAgeConfirm, bw, WriteOption<int>(WriteInt));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var popup = Read(br, ReadOption(flags, 0));
                var id = Read(br, T.DataJson.Deserialize);
                var text = Read(br, ReadString);
                var entities = Read(br, ReadVector(T.MessageEntity.Deserialize));
                var minAgeConfirm = Read(br, ReadOption(flags, 1, ReadInt));
                return new Tag(popup, id, text, entities, minAgeConfirm);
            }
        }

        readonly ITlTypeTag _tag;
        TermsOfService(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator TermsOfService(Tag tag) => new TermsOfService(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static TermsOfService Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (TermsOfService) Tag.DeserializeTag(br);
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

        public bool Equals(TermsOfService other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is TermsOfService x && Equals(x);
        public static bool operator ==(TermsOfService x, TermsOfService y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(TermsOfService x, TermsOfService y) => !(x == y);

        public int CompareTo(TermsOfService other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is TermsOfService x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TermsOfService x, TermsOfService y) => x.CompareTo(y) <= 0;
        public static bool operator <(TermsOfService x, TermsOfService y) => x.CompareTo(y) < 0;
        public static bool operator >(TermsOfService x, TermsOfService y) => x.CompareTo(y) > 0;
        public static bool operator >=(TermsOfService x, TermsOfService y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"TermsOfService.{_tag.GetType().Name}{_tag}";
    }
}