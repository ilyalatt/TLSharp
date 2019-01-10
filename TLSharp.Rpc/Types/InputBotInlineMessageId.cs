using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputBotInlineMessageId : ITlType, IEquatable<InputBotInlineMessageId>, IComparable<InputBotInlineMessageId>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x890c3d89;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int DcId { get; }
            public long Id { get; }
            public long AccessHash { get; }
            
            public Tag(
                int dcId,
                long id,
                long accessHash
            ) {
                DcId = dcId;
                Id = id;
                AccessHash = accessHash;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(DcId, bw, WriteInt);
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var dcId = Read(br, ReadInt);
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                return new Tag(dcId, id, accessHash);
            }
        }

        readonly ITlTypeTag _tag;
        InputBotInlineMessageId(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputBotInlineMessageId(Tag tag) => new InputBotInlineMessageId(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputBotInlineMessageId Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputBotInlineMessageId) Tag.DeserializeTag(br);
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

        public bool Equals(InputBotInlineMessageId other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputBotInlineMessageId x && Equals(x);
        public static bool operator ==(InputBotInlineMessageId a, InputBotInlineMessageId b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputBotInlineMessageId a, InputBotInlineMessageId b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputBotInlineMessageId other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputBotInlineMessageId x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputBotInlineMessageId a, InputBotInlineMessageId b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputBotInlineMessageId a, InputBotInlineMessageId b) => a.CompareTo(b) < 0;
        public static bool operator >(InputBotInlineMessageId a, InputBotInlineMessageId b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputBotInlineMessageId a, InputBotInlineMessageId b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}