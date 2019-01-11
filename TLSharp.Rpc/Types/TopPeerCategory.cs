using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class TopPeerCategory : ITlType, IEquatable<TopPeerCategory>, IComparable<TopPeerCategory>, IComparable
    {
        public sealed class BotsPmTag : ITlTypeTag, IEquatable<BotsPmTag>, IComparable<BotsPmTag>, IComparable
        {
            internal const uint TypeNumber = 0xab661b5b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public BotsPmTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(BotsPmTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is BotsPmTag x && Equals(x);
            public static bool operator ==(BotsPmTag x, BotsPmTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotsPmTag x, BotsPmTag y) => !(x == y);

            public int CompareTo(BotsPmTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is BotsPmTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotsPmTag x, BotsPmTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotsPmTag x, BotsPmTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotsPmTag x, BotsPmTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotsPmTag x, BotsPmTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static BotsPmTag DeserializeTag(BinaryReader br)
            {

                return new BotsPmTag();
            }
        }

        public sealed class BotsInlineTag : ITlTypeTag, IEquatable<BotsInlineTag>, IComparable<BotsInlineTag>, IComparable
        {
            internal const uint TypeNumber = 0x148677e2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public BotsInlineTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(BotsInlineTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is BotsInlineTag x && Equals(x);
            public static bool operator ==(BotsInlineTag x, BotsInlineTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotsInlineTag x, BotsInlineTag y) => !(x == y);

            public int CompareTo(BotsInlineTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is BotsInlineTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotsInlineTag x, BotsInlineTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotsInlineTag x, BotsInlineTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotsInlineTag x, BotsInlineTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotsInlineTag x, BotsInlineTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static BotsInlineTag DeserializeTag(BinaryReader br)
            {

                return new BotsInlineTag();
            }
        }

        public sealed class CorrespondentsTag : ITlTypeTag, IEquatable<CorrespondentsTag>, IComparable<CorrespondentsTag>, IComparable
        {
            internal const uint TypeNumber = 0x0637b7ed;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public CorrespondentsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(CorrespondentsTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is CorrespondentsTag x && Equals(x);
            public static bool operator ==(CorrespondentsTag x, CorrespondentsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CorrespondentsTag x, CorrespondentsTag y) => !(x == y);

            public int CompareTo(CorrespondentsTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is CorrespondentsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CorrespondentsTag x, CorrespondentsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CorrespondentsTag x, CorrespondentsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CorrespondentsTag x, CorrespondentsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CorrespondentsTag x, CorrespondentsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static CorrespondentsTag DeserializeTag(BinaryReader br)
            {

                return new CorrespondentsTag();
            }
        }

        public sealed class GroupsTag : ITlTypeTag, IEquatable<GroupsTag>, IComparable<GroupsTag>, IComparable
        {
            internal const uint TypeNumber = 0xbd17a14a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public GroupsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(GroupsTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is GroupsTag x && Equals(x);
            public static bool operator ==(GroupsTag x, GroupsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GroupsTag x, GroupsTag y) => !(x == y);

            public int CompareTo(GroupsTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is GroupsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GroupsTag x, GroupsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GroupsTag x, GroupsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GroupsTag x, GroupsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GroupsTag x, GroupsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static GroupsTag DeserializeTag(BinaryReader br)
            {

                return new GroupsTag();
            }
        }

        public sealed class ChannelsTag : ITlTypeTag, IEquatable<ChannelsTag>, IComparable<ChannelsTag>, IComparable
        {
            internal const uint TypeNumber = 0x161d9628;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ChannelsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ChannelsTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChannelsTag x && Equals(x);
            public static bool operator ==(ChannelsTag x, ChannelsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelsTag x, ChannelsTag y) => !(x == y);

            public int CompareTo(ChannelsTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChannelsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelsTag x, ChannelsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelsTag x, ChannelsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelsTag x, ChannelsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelsTag x, ChannelsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChannelsTag DeserializeTag(BinaryReader br)
            {

                return new ChannelsTag();
            }
        }

        public sealed class PhoneCallsTag : ITlTypeTag, IEquatable<PhoneCallsTag>, IComparable<PhoneCallsTag>, IComparable
        {
            internal const uint TypeNumber = 0x1e76a78c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PhoneCallsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PhoneCallsTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PhoneCallsTag x && Equals(x);
            public static bool operator ==(PhoneCallsTag x, PhoneCallsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PhoneCallsTag x, PhoneCallsTag y) => !(x == y);

            public int CompareTo(PhoneCallsTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PhoneCallsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PhoneCallsTag x, PhoneCallsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PhoneCallsTag x, PhoneCallsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PhoneCallsTag x, PhoneCallsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PhoneCallsTag x, PhoneCallsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PhoneCallsTag DeserializeTag(BinaryReader br)
            {

                return new PhoneCallsTag();
            }
        }

        readonly ITlTypeTag _tag;
        TopPeerCategory(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator TopPeerCategory(BotsPmTag tag) => new TopPeerCategory(tag);
        public static explicit operator TopPeerCategory(BotsInlineTag tag) => new TopPeerCategory(tag);
        public static explicit operator TopPeerCategory(CorrespondentsTag tag) => new TopPeerCategory(tag);
        public static explicit operator TopPeerCategory(GroupsTag tag) => new TopPeerCategory(tag);
        public static explicit operator TopPeerCategory(ChannelsTag tag) => new TopPeerCategory(tag);
        public static explicit operator TopPeerCategory(PhoneCallsTag tag) => new TopPeerCategory(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static TopPeerCategory Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case BotsPmTag.TypeNumber: return (TopPeerCategory) BotsPmTag.DeserializeTag(br);
                case BotsInlineTag.TypeNumber: return (TopPeerCategory) BotsInlineTag.DeserializeTag(br);
                case CorrespondentsTag.TypeNumber: return (TopPeerCategory) CorrespondentsTag.DeserializeTag(br);
                case GroupsTag.TypeNumber: return (TopPeerCategory) GroupsTag.DeserializeTag(br);
                case ChannelsTag.TypeNumber: return (TopPeerCategory) ChannelsTag.DeserializeTag(br);
                case PhoneCallsTag.TypeNumber: return (TopPeerCategory) PhoneCallsTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { BotsPmTag.TypeNumber, BotsInlineTag.TypeNumber, CorrespondentsTag.TypeNumber, GroupsTag.TypeNumber, ChannelsTag.TypeNumber, PhoneCallsTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<BotsPmTag, T> botsPmTag = null,
            Func<BotsInlineTag, T> botsInlineTag = null,
            Func<CorrespondentsTag, T> correspondentsTag = null,
            Func<GroupsTag, T> groupsTag = null,
            Func<ChannelsTag, T> channelsTag = null,
            Func<PhoneCallsTag, T> phoneCallsTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case BotsPmTag x when botsPmTag != null: return botsPmTag(x);
                case BotsInlineTag x when botsInlineTag != null: return botsInlineTag(x);
                case CorrespondentsTag x when correspondentsTag != null: return correspondentsTag(x);
                case GroupsTag x when groupsTag != null: return groupsTag(x);
                case ChannelsTag x when channelsTag != null: return channelsTag(x);
                case PhoneCallsTag x when phoneCallsTag != null: return phoneCallsTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<BotsPmTag, T> botsPmTag,
            Func<BotsInlineTag, T> botsInlineTag,
            Func<CorrespondentsTag, T> correspondentsTag,
            Func<GroupsTag, T> groupsTag,
            Func<ChannelsTag, T> channelsTag,
            Func<PhoneCallsTag, T> phoneCallsTag
        ) => Match(
            () => throw new Exception("WTF"),
            botsPmTag ?? throw new ArgumentNullException(nameof(botsPmTag)),
            botsInlineTag ?? throw new ArgumentNullException(nameof(botsInlineTag)),
            correspondentsTag ?? throw new ArgumentNullException(nameof(correspondentsTag)),
            groupsTag ?? throw new ArgumentNullException(nameof(groupsTag)),
            channelsTag ?? throw new ArgumentNullException(nameof(channelsTag)),
            phoneCallsTag ?? throw new ArgumentNullException(nameof(phoneCallsTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case BotsPmTag _: return 0;
                case BotsInlineTag _: return 1;
                case CorrespondentsTag _: return 2;
                case GroupsTag _: return 3;
                case ChannelsTag _: return 4;
                case PhoneCallsTag _: return 5;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(TopPeerCategory other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is TopPeerCategory x && Equals(x);
        public static bool operator ==(TopPeerCategory x, TopPeerCategory y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(TopPeerCategory x, TopPeerCategory y) => !(x == y);

        public int CompareTo(TopPeerCategory other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is TopPeerCategory x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TopPeerCategory x, TopPeerCategory y) => x.CompareTo(y) <= 0;
        public static bool operator <(TopPeerCategory x, TopPeerCategory y) => x.CompareTo(y) < 0;
        public static bool operator >(TopPeerCategory x, TopPeerCategory y) => x.CompareTo(y) > 0;
        public static bool operator >=(TopPeerCategory x, TopPeerCategory y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"TopPeerCategory.{_tag.GetType().Name}{_tag}";
    }
}