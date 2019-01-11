using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Auth
{
    public sealed class SentCode : ITlType, IEquatable<SentCode>, IComparable<SentCode>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x38faab5f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool PhoneRegistered;
            public readonly T.Auth.SentCodeType Type;
            public readonly string PhoneCodeHash;
            public readonly Option<T.Auth.CodeType> NextType;
            public readonly Option<int> Timeout;
            public readonly Option<T.Help.TermsOfService> TermsOfService;
            
            public Tag(
                bool phoneRegistered,
                Some<T.Auth.SentCodeType> type,
                Some<string> phoneCodeHash,
                Option<T.Auth.CodeType> nextType,
                Option<int> timeout,
                Option<T.Help.TermsOfService> termsOfService
            ) {
                PhoneRegistered = phoneRegistered;
                Type = type;
                PhoneCodeHash = phoneCodeHash;
                NextType = nextType;
                Timeout = timeout;
                TermsOfService = termsOfService;
            }
            
            (bool, T.Auth.SentCodeType, string, Option<T.Auth.CodeType>, Option<int>, Option<T.Help.TermsOfService>) CmpTuple =>
                (PhoneRegistered, Type, PhoneCodeHash, NextType, Timeout, TermsOfService);

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

            public override string ToString() => $"(PhoneRegistered: {PhoneRegistered}, Type: {Type}, PhoneCodeHash: {PhoneCodeHash}, NextType: {NextType}, Timeout: {Timeout}, TermsOfService: {TermsOfService})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, PhoneRegistered) | MaskBit(1, NextType) | MaskBit(2, Timeout) | MaskBit(3, TermsOfService), bw, WriteInt);
                Write(Type, bw, WriteSerializable);
                Write(PhoneCodeHash, bw, WriteString);
                Write(NextType, bw, WriteOption<T.Auth.CodeType>(WriteSerializable));
                Write(Timeout, bw, WriteOption<int>(WriteInt));
                Write(TermsOfService, bw, WriteOption<T.Help.TermsOfService>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var phoneRegistered = Read(br, ReadOption(flags, 0));
                var type = Read(br, T.Auth.SentCodeType.Deserialize);
                var phoneCodeHash = Read(br, ReadString);
                var nextType = Read(br, ReadOption(flags, 1, T.Auth.CodeType.Deserialize));
                var timeout = Read(br, ReadOption(flags, 2, ReadInt));
                var termsOfService = Read(br, ReadOption(flags, 3, T.Help.TermsOfService.Deserialize));
                return new Tag(phoneRegistered, type, phoneCodeHash, nextType, timeout, termsOfService);
            }
        }

        readonly ITlTypeTag _tag;
        SentCode(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SentCode(Tag tag) => new SentCode(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SentCode Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (SentCode) Tag.DeserializeTag(br);
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

        public bool Equals(SentCode other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is SentCode x && Equals(x);
        public static bool operator ==(SentCode x, SentCode y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SentCode x, SentCode y) => !(x == y);

        public int CompareTo(SentCode other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is SentCode x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SentCode x, SentCode y) => x.CompareTo(y) <= 0;
        public static bool operator <(SentCode x, SentCode y) => x.CompareTo(y) < 0;
        public static bool operator >(SentCode x, SentCode y) => x.CompareTo(y) > 0;
        public static bool operator >=(SentCode x, SentCode y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SentCode.{_tag.GetType().Name}{_tag}";
    }
}