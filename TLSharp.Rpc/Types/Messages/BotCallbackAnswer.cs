using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class BotCallbackAnswer : ITlType, IEquatable<BotCallbackAnswer>, IComparable<BotCallbackAnswer>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x36585ea4;
            
            public bool Alert { get; }
            public bool HasUrl { get; }
            public Option<string> Message { get; }
            public Option<string> Url { get; }
            public int CacheTime { get; }
            
            public Tag(
                bool alert,
                bool hasUrl,
                Option<string> message,
                Option<string> url,
                int cacheTime
            ) {
                Alert = alert;
                HasUrl = hasUrl;
                Message = message;
                Url = url;
                CacheTime = cacheTime;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Alert) | MaskBit(3, HasUrl) | MaskBit(0, Message) | MaskBit(2, Url), bw, WriteInt);
                Write(Message, bw, WriteOption<string>(WriteString));
                Write(Url, bw, WriteOption<string>(WriteString));
                Write(CacheTime, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var alert = Read(br, ReadOption(flags, 1));
                var hasUrl = Read(br, ReadOption(flags, 3));
                var message = Read(br, ReadOption(flags, 0, ReadString));
                var url = Read(br, ReadOption(flags, 2, ReadString));
                var cacheTime = Read(br, ReadInt);
                return new Tag(alert, hasUrl, message, url, cacheTime);
            }
        }

        readonly ITlTypeTag _tag;
        BotCallbackAnswer(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator BotCallbackAnswer(Tag tag) => new BotCallbackAnswer(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static BotCallbackAnswer Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x36585ea4: return (BotCallbackAnswer) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x36585ea4 });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(BotCallbackAnswer other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is BotCallbackAnswer x && Equals(x);
        public static bool operator ==(BotCallbackAnswer a, BotCallbackAnswer b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(BotCallbackAnswer a, BotCallbackAnswer b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(BotCallbackAnswer other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is BotCallbackAnswer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotCallbackAnswer a, BotCallbackAnswer b) => a.CompareTo(b) <= 0;
        public static bool operator <(BotCallbackAnswer a, BotCallbackAnswer b) => a.CompareTo(b) < 0;
        public static bool operator >(BotCallbackAnswer a, BotCallbackAnswer b) => a.CompareTo(b) > 0;
        public static bool operator >=(BotCallbackAnswer a, BotCallbackAnswer b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}