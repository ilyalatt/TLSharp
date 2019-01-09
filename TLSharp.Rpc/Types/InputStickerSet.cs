using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputStickerSet : ITlType, IEquatable<InputStickerSet>, IComparable<InputStickerSet>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xffb62b95;
            

            
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

        public sealed class IdTag : Record<IdTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9de7a269;
            
            public long Id { get; }
            public long AccessHash { get; }
            
            public IdTag(
                long id,
                long accessHash
            ) {
                Id = id;
                AccessHash = accessHash;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static IdTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                return new IdTag(id, accessHash);
            }
        }

        public sealed class ShortNameTag : Record<ShortNameTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x861cc8a0;
            
            public string ShortName { get; }
            
            public ShortNameTag(
                Some<string> shortName
            ) {
                ShortName = shortName;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ShortName, bw, WriteString);
            }
            
            internal static ShortNameTag DeserializeTag(BinaryReader br)
            {
                var shortName = Read(br, ReadString);
                return new ShortNameTag(shortName);
            }
        }

        readonly ITlTypeTag _tag;
        InputStickerSet(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputStickerSet(EmptyTag tag) => new InputStickerSet(tag);
        public static explicit operator InputStickerSet(IdTag tag) => new InputStickerSet(tag);
        public static explicit operator InputStickerSet(ShortNameTag tag) => new InputStickerSet(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputStickerSet Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xffb62b95: return (InputStickerSet) EmptyTag.DeserializeTag(br);
                case 0x9de7a269: return (InputStickerSet) IdTag.DeserializeTag(br);
                case 0x861cc8a0: return (InputStickerSet) ShortNameTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xffb62b95, 0x9de7a269, 0x861cc8a0 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<IdTag, T> idTag = null,
            Func<ShortNameTag, T> shortNameTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case IdTag x when idTag != null: return idTag(x);
                case ShortNameTag x when shortNameTag != null: return shortNameTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<IdTag, T> idTag,
            Func<ShortNameTag, T> shortNameTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            idTag ?? throw new ArgumentNullException(nameof(idTag)),
            shortNameTag ?? throw new ArgumentNullException(nameof(shortNameTag))
        );

        public bool Equals(InputStickerSet other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputStickerSet x && Equals(x);
        public static bool operator ==(InputStickerSet a, InputStickerSet b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputStickerSet a, InputStickerSet b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case IdTag _: return 1;
                case ShortNameTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputStickerSet other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputStickerSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputStickerSet a, InputStickerSet b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputStickerSet a, InputStickerSet b) => a.CompareTo(b) < 0;
        public static bool operator >(InputStickerSet a, InputStickerSet b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputStickerSet a, InputStickerSet b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}