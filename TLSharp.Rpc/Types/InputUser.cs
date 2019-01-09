using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputUser : ITlType, IEquatable<InputUser>, IComparable<InputUser>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xb98886cf;
            

            
            public EmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class SelfTag : Record<SelfTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xf7c1b13f;
            

            
            public SelfTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static SelfTag DeserializeTag(BinaryReader br)
            {

                return new SelfTag();
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xd8292816;
            
            public int UserId { get; }
            public long AccessHash { get; }
            
            public Tag(
                int userId,
                long accessHash
            ) {
                UserId = userId;
                AccessHash = accessHash;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var accessHash = Read(br, ReadLong);
                return new Tag(userId, accessHash);
            }
        }

        readonly ITlTypeTag _tag;
        InputUser(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputUser(EmptyTag tag) => new InputUser(tag);
        public static explicit operator InputUser(SelfTag tag) => new InputUser(tag);
        public static explicit operator InputUser(Tag tag) => new InputUser(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputUser Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xb98886cf: return (InputUser) EmptyTag.DeserializeTag(br);
                case 0xf7c1b13f: return (InputUser) SelfTag.DeserializeTag(br);
                case 0xd8292816: return (InputUser) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xb98886cf, 0xf7c1b13f, 0xd8292816 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<SelfTag, T> selfTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case SelfTag x when selfTag != null: return selfTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<SelfTag, T> selfTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            selfTag ?? throw new ArgumentNullException(nameof(selfTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(InputUser other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputUser x && Equals(x);
        public static bool operator ==(InputUser a, InputUser b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputUser a, InputUser b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case SelfTag _: return 1;
                case Tag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputUser other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputUser x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputUser a, InputUser b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputUser a, InputUser b) => a.CompareTo(b) < 0;
        public static bool operator >(InputUser a, InputUser b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputUser a, InputUser b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}