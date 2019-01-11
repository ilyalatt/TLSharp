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
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0xffb62b95;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class IdTag : ITlTypeTag, IEquatable<IdTag>, IComparable<IdTag>, IComparable
        {
            internal const uint TypeNumber = 0x9de7a269;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public long AccessHash { get; }
            
            public IdTag(
                long id,
                long accessHash
            ) {
                Id = id;
                AccessHash = accessHash;
            }
            
            (long, long) CmpTuple =>
                (Id, AccessHash);

            public bool Equals(IdTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is IdTag x && Equals(x);
            public static bool operator ==(IdTag x, IdTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(IdTag x, IdTag y) => !(x == y);

            public int CompareTo(IdTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is IdTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(IdTag x, IdTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(IdTag x, IdTag y) => x.CompareTo(y) < 0;
            public static bool operator >(IdTag x, IdTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(IdTag x, IdTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash})";
            
            
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

        public sealed class ShortNameTag : ITlTypeTag, IEquatable<ShortNameTag>, IComparable<ShortNameTag>, IComparable
        {
            internal const uint TypeNumber = 0x861cc8a0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string ShortName { get; }
            
            public ShortNameTag(
                Some<string> shortName
            ) {
                ShortName = shortName;
            }
            
            string CmpTuple =>
                ShortName;

            public bool Equals(ShortNameTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ShortNameTag x && Equals(x);
            public static bool operator ==(ShortNameTag x, ShortNameTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ShortNameTag x, ShortNameTag y) => !(x == y);

            public int CompareTo(ShortNameTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ShortNameTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ShortNameTag x, ShortNameTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ShortNameTag x, ShortNameTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ShortNameTag x, ShortNameTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ShortNameTag x, ShortNameTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ShortName: {ShortName})";
            
            
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
                case EmptyTag.TypeNumber: return (InputStickerSet) EmptyTag.DeserializeTag(br);
                case IdTag.TypeNumber: return (InputStickerSet) IdTag.DeserializeTag(br);
                case ShortNameTag.TypeNumber: return (InputStickerSet) ShortNameTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, IdTag.TypeNumber, ShortNameTag.TypeNumber });
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

        public bool Equals(InputStickerSet other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is InputStickerSet x && Equals(x);
        public static bool operator ==(InputStickerSet x, InputStickerSet y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputStickerSet x, InputStickerSet y) => !(x == y);

        public int CompareTo(InputStickerSet other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputStickerSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputStickerSet x, InputStickerSet y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputStickerSet x, InputStickerSet y) => x.CompareTo(y) < 0;
        public static bool operator >(InputStickerSet x, InputStickerSet y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputStickerSet x, InputStickerSet y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputStickerSet.{_tag.GetType().Name}{_tag}";
    }
}