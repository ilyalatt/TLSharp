using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChannelParticipantRole : ITlType, IEquatable<ChannelParticipantRole>, IComparable<ChannelParticipantRole>, IComparable
    {
        public sealed class RoleEmptyTag : ITlTypeTag, IEquatable<RoleEmptyTag>, IComparable<RoleEmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0xb285a0c6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RoleEmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(RoleEmptyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is RoleEmptyTag x && Equals(x);
            public static bool operator ==(RoleEmptyTag x, RoleEmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RoleEmptyTag x, RoleEmptyTag y) => !(x == y);

            public int CompareTo(RoleEmptyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is RoleEmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RoleEmptyTag x, RoleEmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RoleEmptyTag x, RoleEmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RoleEmptyTag x, RoleEmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RoleEmptyTag x, RoleEmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RoleEmptyTag DeserializeTag(BinaryReader br)
            {

                return new RoleEmptyTag();
            }
        }

        public sealed class RoleModeratorTag : ITlTypeTag, IEquatable<RoleModeratorTag>, IComparable<RoleModeratorTag>, IComparable
        {
            internal const uint TypeNumber = 0x9618d975;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RoleModeratorTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(RoleModeratorTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is RoleModeratorTag x && Equals(x);
            public static bool operator ==(RoleModeratorTag x, RoleModeratorTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RoleModeratorTag x, RoleModeratorTag y) => !(x == y);

            public int CompareTo(RoleModeratorTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is RoleModeratorTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RoleModeratorTag x, RoleModeratorTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RoleModeratorTag x, RoleModeratorTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RoleModeratorTag x, RoleModeratorTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RoleModeratorTag x, RoleModeratorTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RoleModeratorTag DeserializeTag(BinaryReader br)
            {

                return new RoleModeratorTag();
            }
        }

        public sealed class RoleEditorTag : ITlTypeTag, IEquatable<RoleEditorTag>, IComparable<RoleEditorTag>, IComparable
        {
            internal const uint TypeNumber = 0x820bfe8c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RoleEditorTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(RoleEditorTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is RoleEditorTag x && Equals(x);
            public static bool operator ==(RoleEditorTag x, RoleEditorTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RoleEditorTag x, RoleEditorTag y) => !(x == y);

            public int CompareTo(RoleEditorTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is RoleEditorTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RoleEditorTag x, RoleEditorTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RoleEditorTag x, RoleEditorTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RoleEditorTag x, RoleEditorTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RoleEditorTag x, RoleEditorTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RoleEditorTag DeserializeTag(BinaryReader br)
            {

                return new RoleEditorTag();
            }
        }

        readonly ITlTypeTag _tag;
        ChannelParticipantRole(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelParticipantRole(RoleEmptyTag tag) => new ChannelParticipantRole(tag);
        public static explicit operator ChannelParticipantRole(RoleModeratorTag tag) => new ChannelParticipantRole(tag);
        public static explicit operator ChannelParticipantRole(RoleEditorTag tag) => new ChannelParticipantRole(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelParticipantRole Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case RoleEmptyTag.TypeNumber: return (ChannelParticipantRole) RoleEmptyTag.DeserializeTag(br);
                case RoleModeratorTag.TypeNumber: return (ChannelParticipantRole) RoleModeratorTag.DeserializeTag(br);
                case RoleEditorTag.TypeNumber: return (ChannelParticipantRole) RoleEditorTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { RoleEmptyTag.TypeNumber, RoleModeratorTag.TypeNumber, RoleEditorTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<RoleEmptyTag, T> roleEmptyTag = null,
            Func<RoleModeratorTag, T> roleModeratorTag = null,
            Func<RoleEditorTag, T> roleEditorTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case RoleEmptyTag x when roleEmptyTag != null: return roleEmptyTag(x);
                case RoleModeratorTag x when roleModeratorTag != null: return roleModeratorTag(x);
                case RoleEditorTag x when roleEditorTag != null: return roleEditorTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<RoleEmptyTag, T> roleEmptyTag,
            Func<RoleModeratorTag, T> roleModeratorTag,
            Func<RoleEditorTag, T> roleEditorTag
        ) => Match(
            () => throw new Exception("WTF"),
            roleEmptyTag ?? throw new ArgumentNullException(nameof(roleEmptyTag)),
            roleModeratorTag ?? throw new ArgumentNullException(nameof(roleModeratorTag)),
            roleEditorTag ?? throw new ArgumentNullException(nameof(roleEditorTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case RoleEmptyTag _: return 0;
                case RoleModeratorTag _: return 1;
                case RoleEditorTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ChannelParticipantRole other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is ChannelParticipantRole x && Equals(x);
        public static bool operator ==(ChannelParticipantRole x, ChannelParticipantRole y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelParticipantRole x, ChannelParticipantRole y) => !(x == y);

        public int CompareTo(ChannelParticipantRole other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChannelParticipantRole x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelParticipantRole x, ChannelParticipantRole y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelParticipantRole x, ChannelParticipantRole y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelParticipantRole x, ChannelParticipantRole y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelParticipantRole x, ChannelParticipantRole y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelParticipantRole.{_tag.GetType().Name}{_tag}";
    }
}