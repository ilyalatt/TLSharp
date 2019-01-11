using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Payments
{
    public sealed class SavedInfo : ITlType, IEquatable<SavedInfo>, IComparable<SavedInfo>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xfb8fe43c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool HasSavedCredentials { get; }
            public Option<T.PaymentRequestedInfo> SavedInfo { get; }
            
            public Tag(
                bool hasSavedCredentials,
                Option<T.PaymentRequestedInfo> savedInfo
            ) {
                HasSavedCredentials = hasSavedCredentials;
                SavedInfo = savedInfo;
            }
            
            (bool, Option<T.PaymentRequestedInfo>) CmpTuple =>
                (HasSavedCredentials, SavedInfo);

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

            public override string ToString() => $"(HasSavedCredentials: {HasSavedCredentials}, SavedInfo: {SavedInfo})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, HasSavedCredentials) | MaskBit(0, SavedInfo), bw, WriteInt);
                Write(SavedInfo, bw, WriteOption<T.PaymentRequestedInfo>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var hasSavedCredentials = Read(br, ReadOption(flags, 1));
                var savedInfo = Read(br, ReadOption(flags, 0, T.PaymentRequestedInfo.Deserialize));
                return new Tag(hasSavedCredentials, savedInfo);
            }
        }

        readonly ITlTypeTag _tag;
        SavedInfo(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SavedInfo(Tag tag) => new SavedInfo(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SavedInfo Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (SavedInfo) Tag.DeserializeTag(br);
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

        public bool Equals(SavedInfo other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is SavedInfo x && Equals(x);
        public static bool operator ==(SavedInfo x, SavedInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SavedInfo x, SavedInfo y) => !(x == y);

        public int CompareTo(SavedInfo other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SavedInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SavedInfo x, SavedInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(SavedInfo x, SavedInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(SavedInfo x, SavedInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(SavedInfo x, SavedInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SavedInfo.{_tag.GetType().Name}{_tag}";
    }
}