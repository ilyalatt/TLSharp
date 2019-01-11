using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Help
{
    public sealed class TermsOfServiceUpdate : ITlType, IEquatable<TermsOfServiceUpdate>, IComparable<TermsOfServiceUpdate>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0xe3309f7f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Expires;
            
            public EmptyTag(
                int expires
            ) {
                Expires = expires;
            }
            
            int CmpTuple =>
                Expires;

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

            public override string ToString() => $"(Expires: {Expires})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Expires, bw, WriteInt);
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var expires = Read(br, ReadInt);
                return new EmptyTag(expires);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x28ecf961;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Expires;
            public readonly T.Help.TermsOfService TermsOfService;
            
            public Tag(
                int expires,
                Some<T.Help.TermsOfService> termsOfService
            ) {
                Expires = expires;
                TermsOfService = termsOfService;
            }
            
            (int, T.Help.TermsOfService) CmpTuple =>
                (Expires, TermsOfService);

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

            public override string ToString() => $"(Expires: {Expires}, TermsOfService: {TermsOfService})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Expires, bw, WriteInt);
                Write(TermsOfService, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var expires = Read(br, ReadInt);
                var termsOfService = Read(br, T.Help.TermsOfService.Deserialize);
                return new Tag(expires, termsOfService);
            }
        }

        readonly ITlTypeTag _tag;
        TermsOfServiceUpdate(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator TermsOfServiceUpdate(EmptyTag tag) => new TermsOfServiceUpdate(tag);
        public static explicit operator TermsOfServiceUpdate(Tag tag) => new TermsOfServiceUpdate(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static TermsOfServiceUpdate Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (TermsOfServiceUpdate) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (TermsOfServiceUpdate) Tag.DeserializeTag(br);
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

        public bool Equals(TermsOfServiceUpdate other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is TermsOfServiceUpdate x && Equals(x);
        public static bool operator ==(TermsOfServiceUpdate x, TermsOfServiceUpdate y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(TermsOfServiceUpdate x, TermsOfServiceUpdate y) => !(x == y);

        public int CompareTo(TermsOfServiceUpdate other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is TermsOfServiceUpdate x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TermsOfServiceUpdate x, TermsOfServiceUpdate y) => x.CompareTo(y) <= 0;
        public static bool operator <(TermsOfServiceUpdate x, TermsOfServiceUpdate y) => x.CompareTo(y) < 0;
        public static bool operator >(TermsOfServiceUpdate x, TermsOfServiceUpdate y) => x.CompareTo(y) > 0;
        public static bool operator >=(TermsOfServiceUpdate x, TermsOfServiceUpdate y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"TermsOfServiceUpdate.{_tag.GetType().Name}{_tag}";
    }
}