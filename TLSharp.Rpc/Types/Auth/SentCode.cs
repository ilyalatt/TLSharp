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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x5e002502;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool PhoneRegistered { get; }
            public T.Auth.SentCodeType Type { get; }
            public string PhoneCodeHash { get; }
            public Option<T.Auth.CodeType> NextType { get; }
            public Option<int> Timeout { get; }
            
            public Tag(
                bool phoneRegistered,
                Some<T.Auth.SentCodeType> type,
                Some<string> phoneCodeHash,
                Option<T.Auth.CodeType> nextType,
                Option<int> timeout
            ) {
                PhoneRegistered = phoneRegistered;
                Type = type;
                PhoneCodeHash = phoneCodeHash;
                NextType = nextType;
                Timeout = timeout;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, PhoneRegistered) | MaskBit(1, NextType) | MaskBit(2, Timeout), bw, WriteInt);
                Write(Type, bw, WriteSerializable);
                Write(PhoneCodeHash, bw, WriteString);
                Write(NextType, bw, WriteOption<T.Auth.CodeType>(WriteSerializable));
                Write(Timeout, bw, WriteOption<int>(WriteInt));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var phoneRegistered = Read(br, ReadOption(flags, 0));
                var type = Read(br, T.Auth.SentCodeType.Deserialize);
                var phoneCodeHash = Read(br, ReadString);
                var nextType = Read(br, ReadOption(flags, 1, T.Auth.CodeType.Deserialize));
                var timeout = Read(br, ReadOption(flags, 2, ReadInt));
                return new Tag(phoneRegistered, type, phoneCodeHash, nextType, timeout);
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

        public bool Equals(SentCode other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is SentCode x && Equals(x);
        public static bool operator ==(SentCode a, SentCode b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(SentCode a, SentCode b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(SentCode other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SentCode x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SentCode a, SentCode b) => a.CompareTo(b) <= 0;
        public static bool operator <(SentCode a, SentCode b) => a.CompareTo(b) < 0;
        public static bool operator >(SentCode a, SentCode b) => a.CompareTo(b) > 0;
        public static bool operator >=(SentCode a, SentCode b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}