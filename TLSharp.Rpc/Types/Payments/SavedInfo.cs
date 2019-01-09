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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfb8fe43c;
            
            public bool HasSavedCredentials { get; }
            public Option<T.PaymentRequestedInfo> SavedInfo { get; }
            
            public Tag(
                bool hasSavedCredentials,
                Option<T.PaymentRequestedInfo> savedInfo
            ) {
                HasSavedCredentials = hasSavedCredentials;
                SavedInfo = savedInfo;
            }
            
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
                case 0xfb8fe43c: return (SavedInfo) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xfb8fe43c });
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

        public bool Equals(SavedInfo other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is SavedInfo x && Equals(x);
        public static bool operator ==(SavedInfo a, SavedInfo b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(SavedInfo a, SavedInfo b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(SavedInfo other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SavedInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SavedInfo a, SavedInfo b) => a.CompareTo(b) <= 0;
        public static bool operator <(SavedInfo a, SavedInfo b) => a.CompareTo(b) < 0;
        public static bool operator >(SavedInfo a, SavedInfo b) => a.CompareTo(b) > 0;
        public static bool operator >=(SavedInfo a, SavedInfo b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}