using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Error : ITlType, IEquatable<Error>, IComparable<Error>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xc4b9f9bb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Code { get; }
            public string Text { get; }
            
            public Tag(
                int code,
                Some<string> text
            ) {
                Code = code;
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Code, bw, WriteInt);
                Write(Text, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var code = Read(br, ReadInt);
                var text = Read(br, ReadString);
                return new Tag(code, text);
            }
        }

        readonly ITlTypeTag _tag;
        Error(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Error(Tag tag) => new Error(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Error Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (Error) Tag.DeserializeTag(br);
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

        public bool Equals(Error other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Error x && Equals(x);
        public static bool operator ==(Error a, Error b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Error a, Error b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Error other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Error x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Error a, Error b) => a.CompareTo(b) <= 0;
        public static bool operator <(Error a, Error b) => a.CompareTo(b) < 0;
        public static bool operator >(Error a, Error b) => a.CompareTo(b) > 0;
        public static bool operator >=(Error a, Error b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}