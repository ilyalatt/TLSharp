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
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x09d05049;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
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

        public sealed class OnlineTag : Record<OnlineTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xedb93949;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Expires { get; }
            
            public OnlineTag(
                int expires
            ) {
                Expires = expires;
            }
            
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

        public sealed class OfflineTag : Record<OfflineTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x008c703f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int WasOnline { get; }
            
            public OfflineTag(
                int wasOnline
            ) {
                WasOnline = wasOnline;
            }
            
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

        public sealed class RecentlyTag : Record<RecentlyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xe26f42f1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RecentlyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RecentlyTag DeserializeTag(BinaryReader br)
            {

                return new RecentlyTag();
            }
        }

        public sealed class LastWeekTag : Record<LastWeekTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x07bf09fc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public LastWeekTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static LastWeekTag DeserializeTag(BinaryReader br)
            {

                return new LastWeekTag();
            }
        }

        public sealed class LastMonthTag : Record<LastMonthTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x77ebc742;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public LastMonthTag(

            ) {

            }
            
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

        public bool Equals(UserStatus other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is UserStatus x && Equals(x);
        public static bool operator ==(UserStatus a, UserStatus b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(UserStatus a, UserStatus b) => !(a == b);

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

        public int CompareTo(UserStatus other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is UserStatus x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UserStatus a, UserStatus b) => a.CompareTo(b) <= 0;
        public static bool operator <(UserStatus a, UserStatus b) => a.CompareTo(b) < 0;
        public static bool operator >(UserStatus a, UserStatus b) => a.CompareTo(b) > 0;
        public static bool operator >=(UserStatus a, UserStatus b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}