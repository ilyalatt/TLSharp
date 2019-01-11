using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChannelParticipantsFilter : ITlType, IEquatable<ChannelParticipantsFilter>, IComparable<ChannelParticipantsFilter>, IComparable
    {
        public sealed class RecentTag : ITlTypeTag, IEquatable<RecentTag>, IComparable<RecentTag>, IComparable
        {
            internal const uint TypeNumber = 0xde3f3c79;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RecentTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(RecentTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is RecentTag x && Equals(x);
            public static bool operator ==(RecentTag x, RecentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RecentTag x, RecentTag y) => !(x == y);

            public int CompareTo(RecentTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is RecentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RecentTag x, RecentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RecentTag x, RecentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RecentTag x, RecentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RecentTag x, RecentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RecentTag DeserializeTag(BinaryReader br)
            {

                return new RecentTag();
            }
        }

        public sealed class AdminsTag : ITlTypeTag, IEquatable<AdminsTag>, IComparable<AdminsTag>, IComparable
        {
            internal const uint TypeNumber = 0xb4608969;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public AdminsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(AdminsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is AdminsTag x && Equals(x);
            public static bool operator ==(AdminsTag x, AdminsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AdminsTag x, AdminsTag y) => !(x == y);

            public int CompareTo(AdminsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is AdminsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AdminsTag x, AdminsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AdminsTag x, AdminsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AdminsTag x, AdminsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AdminsTag x, AdminsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static AdminsTag DeserializeTag(BinaryReader br)
            {

                return new AdminsTag();
            }
        }

        public sealed class KickedTag : ITlTypeTag, IEquatable<KickedTag>, IComparable<KickedTag>, IComparable
        {
            internal const uint TypeNumber = 0x3c37bb7a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public KickedTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(KickedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is KickedTag x && Equals(x);
            public static bool operator ==(KickedTag x, KickedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(KickedTag x, KickedTag y) => !(x == y);

            public int CompareTo(KickedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is KickedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(KickedTag x, KickedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(KickedTag x, KickedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(KickedTag x, KickedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(KickedTag x, KickedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static KickedTag DeserializeTag(BinaryReader br)
            {

                return new KickedTag();
            }
        }

        public sealed class BotsTag : ITlTypeTag, IEquatable<BotsTag>, IComparable<BotsTag>, IComparable
        {
            internal const uint TypeNumber = 0xb0d1865b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public BotsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(BotsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BotsTag x && Equals(x);
            public static bool operator ==(BotsTag x, BotsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotsTag x, BotsTag y) => !(x == y);

            public int CompareTo(BotsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BotsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotsTag x, BotsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotsTag x, BotsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotsTag x, BotsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotsTag x, BotsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static BotsTag DeserializeTag(BinaryReader br)
            {

                return new BotsTag();
            }
        }

        readonly ITlTypeTag _tag;
        ChannelParticipantsFilter(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelParticipantsFilter(RecentTag tag) => new ChannelParticipantsFilter(tag);
        public static explicit operator ChannelParticipantsFilter(AdminsTag tag) => new ChannelParticipantsFilter(tag);
        public static explicit operator ChannelParticipantsFilter(KickedTag tag) => new ChannelParticipantsFilter(tag);
        public static explicit operator ChannelParticipantsFilter(BotsTag tag) => new ChannelParticipantsFilter(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelParticipantsFilter Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case RecentTag.TypeNumber: return (ChannelParticipantsFilter) RecentTag.DeserializeTag(br);
                case AdminsTag.TypeNumber: return (ChannelParticipantsFilter) AdminsTag.DeserializeTag(br);
                case KickedTag.TypeNumber: return (ChannelParticipantsFilter) KickedTag.DeserializeTag(br);
                case BotsTag.TypeNumber: return (ChannelParticipantsFilter) BotsTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { RecentTag.TypeNumber, AdminsTag.TypeNumber, KickedTag.TypeNumber, BotsTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<RecentTag, T> recentTag = null,
            Func<AdminsTag, T> adminsTag = null,
            Func<KickedTag, T> kickedTag = null,
            Func<BotsTag, T> botsTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case RecentTag x when recentTag != null: return recentTag(x);
                case AdminsTag x when adminsTag != null: return adminsTag(x);
                case KickedTag x when kickedTag != null: return kickedTag(x);
                case BotsTag x when botsTag != null: return botsTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<RecentTag, T> recentTag,
            Func<AdminsTag, T> adminsTag,
            Func<KickedTag, T> kickedTag,
            Func<BotsTag, T> botsTag
        ) => Match(
            () => throw new Exception("WTF"),
            recentTag ?? throw new ArgumentNullException(nameof(recentTag)),
            adminsTag ?? throw new ArgumentNullException(nameof(adminsTag)),
            kickedTag ?? throw new ArgumentNullException(nameof(kickedTag)),
            botsTag ?? throw new ArgumentNullException(nameof(botsTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case RecentTag _: return 0;
                case AdminsTag _: return 1;
                case KickedTag _: return 2;
                case BotsTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ChannelParticipantsFilter other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is ChannelParticipantsFilter x && Equals(x);
        public static bool operator ==(ChannelParticipantsFilter x, ChannelParticipantsFilter y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelParticipantsFilter x, ChannelParticipantsFilter y) => !(x == y);

        public int CompareTo(ChannelParticipantsFilter other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChannelParticipantsFilter x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelParticipantsFilter x, ChannelParticipantsFilter y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelParticipantsFilter x, ChannelParticipantsFilter y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelParticipantsFilter x, ChannelParticipantsFilter y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelParticipantsFilter x, ChannelParticipantsFilter y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelParticipantsFilter.{_tag.GetType().Name}{_tag}";
    }
}