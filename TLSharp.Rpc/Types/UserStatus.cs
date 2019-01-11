using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class UserStatus : ITlType, IEquatable<UserStatus>, IComparable<UserStatus>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x09d05049;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
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

        public sealed class OnlineTag : ITlTypeTag, IEquatable<OnlineTag>, IComparable<OnlineTag>, IComparable
        {
            internal const uint TypeNumber = 0xedb93949;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Expires;
            
            public OnlineTag(
                int expires
            ) {
                Expires = expires;
            }
            
            int CmpTuple =>
                Expires;

            public bool Equals(OnlineTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is OnlineTag x && Equals(x);
            public static bool operator ==(OnlineTag x, OnlineTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(OnlineTag x, OnlineTag y) => !(x == y);

            public int CompareTo(OnlineTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is OnlineTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(OnlineTag x, OnlineTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(OnlineTag x, OnlineTag y) => x.CompareTo(y) < 0;
            public static bool operator >(OnlineTag x, OnlineTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(OnlineTag x, OnlineTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Expires: {Expires})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Expires, bw, WriteInt);
            }
            
            internal static OnlineTag DeserializeTag(BinaryReader br)
            {
                var expires = Read(br, ReadInt);
                return new OnlineTag(expires);
            }
        }

        public sealed class OfflineTag : ITlTypeTag, IEquatable<OfflineTag>, IComparable<OfflineTag>, IComparable
        {
            internal const uint TypeNumber = 0x008c703f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int WasOnline;
            
            public OfflineTag(
                int wasOnline
            ) {
                WasOnline = wasOnline;
            }
            
            int CmpTuple =>
                WasOnline;

            public bool Equals(OfflineTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is OfflineTag x && Equals(x);
            public static bool operator ==(OfflineTag x, OfflineTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(OfflineTag x, OfflineTag y) => !(x == y);

            public int CompareTo(OfflineTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is OfflineTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(OfflineTag x, OfflineTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(OfflineTag x, OfflineTag y) => x.CompareTo(y) < 0;
            public static bool operator >(OfflineTag x, OfflineTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(OfflineTag x, OfflineTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(WasOnline: {WasOnline})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(WasOnline, bw, WriteInt);
            }
            
            internal static OfflineTag DeserializeTag(BinaryReader br)
            {
                var wasOnline = Read(br, ReadInt);
                return new OfflineTag(wasOnline);
            }
        }

        public sealed class RecentlyTag : ITlTypeTag, IEquatable<RecentlyTag>, IComparable<RecentlyTag>, IComparable
        {
            internal const uint TypeNumber = 0xe26f42f1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RecentlyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(RecentlyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is RecentlyTag x && Equals(x);
            public static bool operator ==(RecentlyTag x, RecentlyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RecentlyTag x, RecentlyTag y) => !(x == y);

            public int CompareTo(RecentlyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is RecentlyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RecentlyTag x, RecentlyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RecentlyTag x, RecentlyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RecentlyTag x, RecentlyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RecentlyTag x, RecentlyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RecentlyTag DeserializeTag(BinaryReader br)
            {

                return new RecentlyTag();
            }
        }

        public sealed class LastWeekTag : ITlTypeTag, IEquatable<LastWeekTag>, IComparable<LastWeekTag>, IComparable
        {
            internal const uint TypeNumber = 0x07bf09fc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public LastWeekTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(LastWeekTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is LastWeekTag x && Equals(x);
            public static bool operator ==(LastWeekTag x, LastWeekTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(LastWeekTag x, LastWeekTag y) => !(x == y);

            public int CompareTo(LastWeekTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is LastWeekTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(LastWeekTag x, LastWeekTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(LastWeekTag x, LastWeekTag y) => x.CompareTo(y) < 0;
            public static bool operator >(LastWeekTag x, LastWeekTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(LastWeekTag x, LastWeekTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static LastWeekTag DeserializeTag(BinaryReader br)
            {

                return new LastWeekTag();
            }
        }

        public sealed class LastMonthTag : ITlTypeTag, IEquatable<LastMonthTag>, IComparable<LastMonthTag>, IComparable
        {
            internal const uint TypeNumber = 0x77ebc742;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public LastMonthTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(LastMonthTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is LastMonthTag x && Equals(x);
            public static bool operator ==(LastMonthTag x, LastMonthTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(LastMonthTag x, LastMonthTag y) => !(x == y);

            public int CompareTo(LastMonthTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is LastMonthTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(LastMonthTag x, LastMonthTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(LastMonthTag x, LastMonthTag y) => x.CompareTo(y) < 0;
            public static bool operator >(LastMonthTag x, LastMonthTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(LastMonthTag x, LastMonthTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static LastMonthTag DeserializeTag(BinaryReader br)
            {

                return new LastMonthTag();
            }
        }

        readonly ITlTypeTag _tag;
        UserStatus(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator UserStatus(EmptyTag tag) => new UserStatus(tag);
        public static explicit operator UserStatus(OnlineTag tag) => new UserStatus(tag);
        public static explicit operator UserStatus(OfflineTag tag) => new UserStatus(tag);
        public static explicit operator UserStatus(RecentlyTag tag) => new UserStatus(tag);
        public static explicit operator UserStatus(LastWeekTag tag) => new UserStatus(tag);
        public static explicit operator UserStatus(LastMonthTag tag) => new UserStatus(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static UserStatus Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (UserStatus) EmptyTag.DeserializeTag(br);
                case OnlineTag.TypeNumber: return (UserStatus) OnlineTag.DeserializeTag(br);
                case OfflineTag.TypeNumber: return (UserStatus) OfflineTag.DeserializeTag(br);
                case RecentlyTag.TypeNumber: return (UserStatus) RecentlyTag.DeserializeTag(br);
                case LastWeekTag.TypeNumber: return (UserStatus) LastWeekTag.DeserializeTag(br);
                case LastMonthTag.TypeNumber: return (UserStatus) LastMonthTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, OnlineTag.TypeNumber, OfflineTag.TypeNumber, RecentlyTag.TypeNumber, LastWeekTag.TypeNumber, LastMonthTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<OnlineTag, T> onlineTag = null,
            Func<OfflineTag, T> offlineTag = null,
            Func<RecentlyTag, T> recentlyTag = null,
            Func<LastWeekTag, T> lastWeekTag = null,
            Func<LastMonthTag, T> lastMonthTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case OnlineTag x when onlineTag != null: return onlineTag(x);
                case OfflineTag x when offlineTag != null: return offlineTag(x);
                case RecentlyTag x when recentlyTag != null: return recentlyTag(x);
                case LastWeekTag x when lastWeekTag != null: return lastWeekTag(x);
                case LastMonthTag x when lastMonthTag != null: return lastMonthTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<OnlineTag, T> onlineTag,
            Func<OfflineTag, T> offlineTag,
            Func<RecentlyTag, T> recentlyTag,
            Func<LastWeekTag, T> lastWeekTag,
            Func<LastMonthTag, T> lastMonthTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            onlineTag ?? throw new ArgumentNullException(nameof(onlineTag)),
            offlineTag ?? throw new ArgumentNullException(nameof(offlineTag)),
            recentlyTag ?? throw new ArgumentNullException(nameof(recentlyTag)),
            lastWeekTag ?? throw new ArgumentNullException(nameof(lastWeekTag)),
            lastMonthTag ?? throw new ArgumentNullException(nameof(lastMonthTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case OnlineTag _: return 1;
                case OfflineTag _: return 2;
                case RecentlyTag _: return 3;
                case LastWeekTag _: return 4;
                case LastMonthTag _: return 5;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(UserStatus other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is UserStatus x && Equals(x);
        public static bool operator ==(UserStatus x, UserStatus y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UserStatus x, UserStatus y) => !(x == y);

        public int CompareTo(UserStatus other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is UserStatus x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UserStatus x, UserStatus y) => x.CompareTo(y) <= 0;
        public static bool operator <(UserStatus x, UserStatus y) => x.CompareTo(y) < 0;
        public static bool operator >(UserStatus x, UserStatus y) => x.CompareTo(y) > 0;
        public static bool operator >=(UserStatus x, UserStatus y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"UserStatus.{_tag.GetType().Name}{_tag}";
    }
}