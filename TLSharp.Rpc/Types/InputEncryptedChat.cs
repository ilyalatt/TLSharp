using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputEncryptedChat : ITlType, IEquatable<InputEncryptedChat>, IComparable<InputEncryptedChat>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xf141b5e1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            public long AccessHash { get; }
            
            public Tag(
                int chatId,
                long accessHash
            ) {
                ChatId = chatId;
                AccessHash = accessHash;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChatId, bw, WriteInt);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var chatId = Read(br, ReadInt);
                var accessHash = Read(br, ReadLong);
                return new Tag(chatId, accessHash);
            }
        }

        readonly ITlTypeTag _tag;
        InputEncryptedChat(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputEncryptedChat(Tag tag) => new InputEncryptedChat(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputEncryptedChat Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputEncryptedChat) Tag.DeserializeTag(br);
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

        public bool Equals(InputEncryptedChat other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputEncryptedChat x && Equals(x);
        public static bool operator ==(InputEncryptedChat a, InputEncryptedChat b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputEncryptedChat a, InputEncryptedChat b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputEncryptedChat other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputEncryptedChat x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputEncryptedChat a, InputEncryptedChat b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputEncryptedChat a, InputEncryptedChat b) => a.CompareTo(b) < 0;
        public static bool operator >(InputEncryptedChat a, InputEncryptedChat b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputEncryptedChat a, InputEncryptedChat b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}