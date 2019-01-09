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
        public sealed class IdTag : Record<IdTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x032c3e77;
            
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
            uint ITlTypeTag.TypeNumber => 0xc331e80a;
            
            public T.InputUser BotId { get; }
            public string ShortName { get; }
            
            public ShortNameTag(
                Some<T.InputUser> botId,
                Some<string> shortName
            ) {
                BotId = botId;
                ShortName = shortName;
            }
            
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
                case 0x032c3e77: return (InputGame) IdTag.DeserializeTag(br);
                case 0xc331e80a: return (InputGame) ShortNameTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x032c3e77, 0xc331e80a });
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

        public bool Equals(InputGame other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputGame x && Equals(x);
        public static bool operator ==(InputGame a, InputGame b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputGame a, InputGame b) => !(a == b);

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

        public int CompareTo(InputGame other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputGame x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputGame a, InputGame b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputGame a, InputGame b) => a.CompareTo(b) < 0;
        public static bool operator >(InputGame a, InputGame b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputGame a, InputGame b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}