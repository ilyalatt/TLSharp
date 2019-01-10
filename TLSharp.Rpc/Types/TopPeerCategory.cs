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
        public sealed class BotsPmTag : Record<BotsPmTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xab661b5b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public BotsPmTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static BotsPmTag DeserializeTag(BinaryReader br)
            {

                return new BotsPmTag();
            }
        }

        public sealed class BotsInlineTag : Record<BotsInlineTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x148677e2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public BotsInlineTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static BotsInlineTag DeserializeTag(BinaryReader br)
            {

                return new BotsInlineTag();
            }
        }

        public sealed class CorrespondentsTag : Record<CorrespondentsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x0637b7ed;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public CorrespondentsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static CorrespondentsTag DeserializeTag(BinaryReader br)
            {

                return new CorrespondentsTag();
            }
        }

        public sealed class GroupsTag : Record<GroupsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xbd17a14a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public GroupsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static GroupsTag DeserializeTag(BinaryReader br)
            {

                return new GroupsTag();
            }
        }

        public sealed class ChannelsTag : Record<ChannelsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x161d9628;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ChannelsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChannelsTag DeserializeTag(BinaryReader br)
            {

                return new ChannelsTag();
            }
        }

        readonly ITlTypeTag _tag;
        TopPeerCategory(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator TopPeerCategory(BotsPmTag tag) => new TopPeerCategory(tag);
        public static explicit operator TopPeerCategory(BotsInlineTag tag) => new TopPeerCategory(tag);
        public static explicit operator TopPeerCategory(CorrespondentsTag tag) => new TopPeerCategory(tag);
        public static explicit operator TopPeerCategory(GroupsTag tag) => new TopPeerCategory(tag);
        public static explicit operator TopPeerCategory(ChannelsTag tag) => new TopPeerCategory(tag);

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
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { BotsPmTag.TypeNumber, BotsInlineTag.TypeNumber, CorrespondentsTag.TypeNumber, GroupsTag.TypeNumber, ChannelsTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<BotsPmTag, T> botsPmTag = null,
            Func<BotsInlineTag, T> botsInlineTag = null,
            Func<CorrespondentsTag, T> correspondentsTag = null,
            Func<GroupsTag, T> groupsTag = null,
            Func<ChannelsTag, T> channelsTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case BotsPmTag x when botsPmTag != null: return botsPmTag(x);
                case BotsInlineTag x when botsInlineTag != null: return botsInlineTag(x);
                case CorrespondentsTag x when correspondentsTag != null: return correspondentsTag(x);
                case GroupsTag x when groupsTag != null: return groupsTag(x);
                case ChannelsTag x when channelsTag != null: return channelsTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<BotsPmTag, T> botsPmTag,
            Func<BotsInlineTag, T> botsInlineTag,
            Func<CorrespondentsTag, T> correspondentsTag,
            Func<GroupsTag, T> groupsTag,
            Func<ChannelsTag, T> channelsTag
        ) => Match(
            () => throw new Exception("WTF"),
            botsPmTag ?? throw new ArgumentNullException(nameof(botsPmTag)),
            botsInlineTag ?? throw new ArgumentNullException(nameof(botsInlineTag)),
            correspondentsTag ?? throw new ArgumentNullException(nameof(correspondentsTag)),
            groupsTag ?? throw new ArgumentNullException(nameof(groupsTag)),
            channelsTag ?? throw new ArgumentNullException(nameof(channelsTag))
        );

        public bool Equals(TopPeerCategory other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is TopPeerCategory x && Equals(x);
        public static bool operator ==(TopPeerCategory a, TopPeerCategory b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(TopPeerCategory a, TopPeerCategory b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case BotsPmTag _: return 0;
                case BotsInlineTag _: return 1;
                case CorrespondentsTag _: return 2;
                case GroupsTag _: return 3;
                case ChannelsTag _: return 4;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(TopPeerCategory other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is TopPeerCategory x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TopPeerCategory a, TopPeerCategory b) => a.CompareTo(b) <= 0;
        public static bool operator <(TopPeerCategory a, TopPeerCategory b) => a.CompareTo(b) < 0;
        public static bool operator >(TopPeerCategory a, TopPeerCategory b) => a.CompareTo(b) > 0;
        public static bool operator >=(TopPeerCategory a, TopPeerCategory b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}