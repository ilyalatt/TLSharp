using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputWebFileLocation : ITlType, IEquatable<InputWebFileLocation>, IComparable<InputWebFileLocation>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xc239d686;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Url { get; }
            public long AccessHash { get; }
            
            public Tag(
                Some<string> url,
                long accessHash
            ) {
                Url = url;
                AccessHash = accessHash;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var accessHash = Read(br, ReadLong);
                return new Tag(url, accessHash);
            }
        }

        readonly ITlTypeTag _tag;
        InputWebFileLocation(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputWebFileLocation(Tag tag) => new InputWebFileLocation(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputWebFileLocation Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputWebFileLocation) Tag.DeserializeTag(br);
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

        public bool Equals(InputWebFileLocation other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputWebFileLocation x && Equals(x);
        public static bool operator ==(InputWebFileLocation a, InputWebFileLocation b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputWebFileLocation a, InputWebFileLocation b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputWebFileLocation other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputWebFileLocation x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputWebFileLocation a, InputWebFileLocation b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputWebFileLocation a, InputWebFileLocation b) => a.CompareTo(b) < 0;
        public static bool operator >(InputWebFileLocation a, InputWebFileLocation b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputWebFileLocation a, InputWebFileLocation b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}