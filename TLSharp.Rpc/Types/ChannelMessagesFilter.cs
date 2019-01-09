using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChannelMessagesFilter : ITlType, IEquatable<ChannelMessagesFilter>, IComparable<ChannelMessagesFilter>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x94d42ee7;
            

            
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

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xcd77d957;
            
            public bool ExcludeNewMessages { get; }
            public Arr<T.MessageRange> Ranges { get; }
            
            public Tag(
                bool excludeNewMessages,
                Some<Arr<T.MessageRange>> ranges
            ) {
                ExcludeNewMessages = excludeNewMessages;
                Ranges = ranges;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, ExcludeNewMessages), bw, WriteInt);
                Write(Ranges, bw, WriteVector<T.MessageRange>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var excludeNewMessages = Read(br, ReadOption(flags, 1));
                var ranges = Read(br, ReadVector(T.MessageRange.Deserialize));
                return new Tag(excludeNewMessages, ranges);
            }
        }

        readonly ITlTypeTag _tag;
        ChannelMessagesFilter(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelMessagesFilter(EmptyTag tag) => new ChannelMessagesFilter(tag);
        public static explicit operator ChannelMessagesFilter(Tag tag) => new ChannelMessagesFilter(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelMessagesFilter Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x94d42ee7: return (ChannelMessagesFilter) EmptyTag.DeserializeTag(br);
                case 0xcd77d957: return (ChannelMessagesFilter) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x94d42ee7, 0xcd77d957 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(ChannelMessagesFilter other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ChannelMessagesFilter x && Equals(x);
        public static bool operator ==(ChannelMessagesFilter a, ChannelMessagesFilter b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ChannelMessagesFilter a, ChannelMessagesFilter b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ChannelMessagesFilter other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChannelMessagesFilter x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelMessagesFilter a, ChannelMessagesFilter b) => a.CompareTo(b) <= 0;
        public static bool operator <(ChannelMessagesFilter a, ChannelMessagesFilter b) => a.CompareTo(b) < 0;
        public static bool operator >(ChannelMessagesFilter a, ChannelMessagesFilter b) => a.CompareTo(b) > 0;
        public static bool operator >=(ChannelMessagesFilter a, ChannelMessagesFilter b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}