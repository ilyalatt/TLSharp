using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputMessage : ITlType, IEquatable<InputMessage>, IComparable<InputMessage>, IComparable
    {
        public sealed class IdTag : ITlTypeTag, IEquatable<IdTag>, IComparable<IdTag>, IComparable
        {
            internal const uint TypeNumber = 0xa676a322;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Id;
            
            public IdTag(
                int id
            ) {
                Id = id;
            }
            
            int CmpTuple =>
                Id;

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

            public override string ToString() => $"(Id: {Id})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
            }
            
            internal static IdTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                return new IdTag(id);
            }
        }

        public sealed class ReplyToTag : ITlTypeTag, IEquatable<ReplyToTag>, IComparable<ReplyToTag>, IComparable
        {
            internal const uint TypeNumber = 0xbad88395;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Id;
            
            public ReplyToTag(
                int id
            ) {
                Id = id;
            }
            
            int CmpTuple =>
                Id;

            public bool Equals(ReplyToTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ReplyToTag x && Equals(x);
            public static bool operator ==(ReplyToTag x, ReplyToTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ReplyToTag x, ReplyToTag y) => !(x == y);

            public int CompareTo(ReplyToTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ReplyToTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ReplyToTag x, ReplyToTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ReplyToTag x, ReplyToTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ReplyToTag x, ReplyToTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ReplyToTag x, ReplyToTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
            }
            
            internal static ReplyToTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                return new ReplyToTag(id);
            }
        }

        public sealed class PinnedTag : ITlTypeTag, IEquatable<PinnedTag>, IComparable<PinnedTag>, IComparable
        {
            internal const uint TypeNumber = 0x86872538;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PinnedTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PinnedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PinnedTag x && Equals(x);
            public static bool operator ==(PinnedTag x, PinnedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PinnedTag x, PinnedTag y) => !(x == y);

            public int CompareTo(PinnedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PinnedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PinnedTag x, PinnedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PinnedTag x, PinnedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PinnedTag x, PinnedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PinnedTag x, PinnedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PinnedTag DeserializeTag(BinaryReader br)
            {

                return new PinnedTag();
            }
        }

        readonly ITlTypeTag _tag;
        InputMessage(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputMessage(IdTag tag) => new InputMessage(tag);
        public static explicit operator InputMessage(ReplyToTag tag) => new InputMessage(tag);
        public static explicit operator InputMessage(PinnedTag tag) => new InputMessage(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputMessage Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case IdTag.TypeNumber: return (InputMessage) IdTag.DeserializeTag(br);
                case ReplyToTag.TypeNumber: return (InputMessage) ReplyToTag.DeserializeTag(br);
                case PinnedTag.TypeNumber: return (InputMessage) PinnedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { IdTag.TypeNumber, ReplyToTag.TypeNumber, PinnedTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<IdTag, T> idTag = null,
            Func<ReplyToTag, T> replyToTag = null,
            Func<PinnedTag, T> pinnedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case IdTag x when idTag != null: return idTag(x);
                case ReplyToTag x when replyToTag != null: return replyToTag(x);
                case PinnedTag x when pinnedTag != null: return pinnedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<IdTag, T> idTag,
            Func<ReplyToTag, T> replyToTag,
            Func<PinnedTag, T> pinnedTag
        ) => Match(
            () => throw new Exception("WTF"),
            idTag ?? throw new ArgumentNullException(nameof(idTag)),
            replyToTag ?? throw new ArgumentNullException(nameof(replyToTag)),
            pinnedTag ?? throw new ArgumentNullException(nameof(pinnedTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case IdTag _: return 0;
                case ReplyToTag _: return 1;
                case PinnedTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputMessage other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputMessage x && Equals(x);
        public static bool operator ==(InputMessage x, InputMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputMessage x, InputMessage y) => !(x == y);

        public int CompareTo(InputMessage other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputMessage x, InputMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputMessage x, InputMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(InputMessage x, InputMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputMessage x, InputMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputMessage.{_tag.GetType().Name}{_tag}";
    }
}