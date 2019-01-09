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
        public sealed class RecentTag : Record<RecentTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xde3f3c79;
            

            
            public RecentTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RecentTag DeserializeTag(BinaryReader br)
            {

                return new RecentTag();
            }
        }

        public sealed class AdminsTag : Record<AdminsTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xb4608969;
            

            
            public AdminsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static AdminsTag DeserializeTag(BinaryReader br)
            {

                return new AdminsTag();
            }
        }

        public sealed class KickedTag : Record<KickedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3c37bb7a;
            

            
            public KickedTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static KickedTag DeserializeTag(BinaryReader br)
            {

                return new KickedTag();
            }
        }

        public sealed class BotsTag : Record<BotsTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xb0d1865b;
            

            
            public BotsTag(

            ) {

            }
            
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
                case 0xde3f3c79: return (ChannelParticipantsFilter) RecentTag.DeserializeTag(br);
                case 0xb4608969: return (ChannelParticipantsFilter) AdminsTag.DeserializeTag(br);
                case 0x3c37bb7a: return (ChannelParticipantsFilter) KickedTag.DeserializeTag(br);
                case 0xb0d1865b: return (ChannelParticipantsFilter) BotsTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xde3f3c79, 0xb4608969, 0x3c37bb7a, 0xb0d1865b });
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

        public bool Equals(ChannelParticipantsFilter other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ChannelParticipantsFilter x && Equals(x);
        public static bool operator ==(ChannelParticipantsFilter a, ChannelParticipantsFilter b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ChannelParticipantsFilter a, ChannelParticipantsFilter b) => !(a == b);

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

        public int CompareTo(ChannelParticipantsFilter other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChannelParticipantsFilter x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelParticipantsFilter a, ChannelParticipantsFilter b) => a.CompareTo(b) <= 0;
        public static bool operator <(ChannelParticipantsFilter a, ChannelParticipantsFilter b) => a.CompareTo(b) < 0;
        public static bool operator >(ChannelParticipantsFilter a, ChannelParticipantsFilter b) => a.CompareTo(b) > 0;
        public static bool operator >=(ChannelParticipantsFilter a, ChannelParticipantsFilter b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}