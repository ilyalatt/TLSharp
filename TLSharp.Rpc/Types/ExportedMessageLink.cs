using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ExportedMessageLink : ITlType, IEquatable<ExportedMessageLink>, IComparable<ExportedMessageLink>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x1f486803;
            
            public string Link { get; }
            
            public Tag(
                Some<string> link
            ) {
                Link = link;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Link, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var link = Read(br, ReadString);
                return new Tag(link);
            }
        }

        readonly ITlTypeTag _tag;
        ExportedMessageLink(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ExportedMessageLink(Tag tag) => new ExportedMessageLink(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ExportedMessageLink Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x1f486803: return (ExportedMessageLink) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x1f486803 });
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

        public bool Equals(ExportedMessageLink other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ExportedMessageLink x && Equals(x);
        public static bool operator ==(ExportedMessageLink a, ExportedMessageLink b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ExportedMessageLink a, ExportedMessageLink b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ExportedMessageLink other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ExportedMessageLink x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ExportedMessageLink a, ExportedMessageLink b) => a.CompareTo(b) <= 0;
        public static bool operator <(ExportedMessageLink a, ExportedMessageLink b) => a.CompareTo(b) < 0;
        public static bool operator >(ExportedMessageLink a, ExportedMessageLink b) => a.CompareTo(b) > 0;
        public static bool operator >=(ExportedMessageLink a, ExportedMessageLink b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}