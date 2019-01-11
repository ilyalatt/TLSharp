using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputGame : ITlType, IEquatable<InputGame>, IComparable<InputGame>, IComparable
    {
        public sealed class IdTag : ITlTypeTag, IEquatable<IdTag>, IComparable<IdTag>, IComparable
        {
            internal const uint TypeNumber = 0x032c3e77;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly long AccessHash;
            
            public IdTag(
                long id,
                long accessHash
            ) {
                Id = id;
                AccessHash = accessHash;
            }
            
            (long, long) CmpTuple =>
                (Id, AccessHash);

            public bool Equals(IdTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is IdTag x && Equals(x);
            public static bool operator ==(IdTag x, IdTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(IdTag x, IdTag y) => !(x == y);

            public int CompareTo(IdTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
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
            internal const uint TypeNumber = 0xc331e80a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputUser BotId;
            public readonly string ShortName;
            
            public ShortNameTag(
                Some<T.InputUser> botId,
                Some<string> shortName
            ) {
                BotId = botId;
                ShortName = shortName;
            }
            
            (T.InputUser, string) CmpTuple =>
                (BotId, ShortName);

            public bool Equals(ShortNameTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ShortNameTag x && Equals(x);
            public static bool operator ==(ShortNameTag x, ShortNameTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ShortNameTag x, ShortNameTag y) => !(x == y);

            public int CompareTo(ShortNameTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ShortNameTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ShortNameTag x, ShortNameTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ShortNameTag x, ShortNameTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ShortNameTag x, ShortNameTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ShortNameTag x, ShortNameTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(BotId: {BotId}, ShortName: {ShortName})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(BotId, bw, WriteSerializable);
                Write(ShortName, bw, WriteString);
            }
            
            internal static ShortNameTag DeserializeTag(BinaryReader br)
            {
                var botId = Read(br, T.InputUser.Deserialize);
                var shortName = Read(br, ReadString);
                return new ShortNameTag(botId, shortName);
            }
        }

        readonly ITlTypeTag _tag;
        InputGame(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputGame(IdTag tag) => new InputGame(tag);
        public static explicit operator InputGame(ShortNameTag tag) => new InputGame(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputGame Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case IdTag.TypeNumber: return (InputGame) IdTag.DeserializeTag(br);
                case ShortNameTag.TypeNumber: return (InputGame) ShortNameTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { IdTag.TypeNumber, ShortNameTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<IdTag, T> idTag = null,
            Func<ShortNameTag, T> shortNameTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case IdTag x when idTag != null: return idTag(x);
                case ShortNameTag x when shortNameTag != null: return shortNameTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<IdTag, T> idTag,
            Func<ShortNameTag, T> shortNameTag
        ) => Match(
            () => throw new Exception("WTF"),
            idTag ?? throw new ArgumentNullException(nameof(idTag)),
            shortNameTag ?? throw new ArgumentNullException(nameof(shortNameTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case IdTag _: return 0;
                case ShortNameTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputGame other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputGame x && Equals(x);
        public static bool operator ==(InputGame x, InputGame y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputGame x, InputGame y) => !(x == y);

        public int CompareTo(InputGame other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputGame x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputGame x, InputGame y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputGame x, InputGame y) => x.CompareTo(y) < 0;
        public static bool operator >(InputGame x, InputGame y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputGame x, InputGame y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputGame.{_tag.GetType().Name}{_tag}";
    }
}