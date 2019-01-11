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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x36585ea4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Alert;
            public readonly bool HasUrl;
            public readonly bool NativeUi;
            public readonly Option<string> Message;
            public readonly Option<string> Url;
            public readonly int CacheTime;
            
            public Tag(
                bool alert,
                bool hasUrl,
                bool nativeUi,
                Option<string> message,
                Option<string> url,
                int cacheTime
            ) {
                Alert = alert;
                HasUrl = hasUrl;
                NativeUi = nativeUi;
                Message = message;
                Url = url;
                CacheTime = cacheTime;
            }
            
            (bool, bool, bool, Option<string>, Option<string>, int) CmpTuple =>
                (Alert, HasUrl, NativeUi, Message, Url, CacheTime);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Alert: {Alert}, HasUrl: {HasUrl}, NativeUi: {NativeUi}, Message: {Message}, Url: {Url}, CacheTime: {CacheTime})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Alert) | MaskBit(3, HasUrl) | MaskBit(4, NativeUi) | MaskBit(0, Message) | MaskBit(2, Url), bw, WriteInt);
                Write(Message, bw, WriteOption<string>(WriteString));
                Write(Url, bw, WriteOption<string>(WriteString));
                Write(CacheTime, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var alert = Read(br, ReadOption(flags, 1));
                var hasUrl = Read(br, ReadOption(flags, 3));
                var nativeUi = Read(br, ReadOption(flags, 4));
                var message = Read(br, ReadOption(flags, 0, ReadString));
                var url = Read(br, ReadOption(flags, 2, ReadString));
                var cacheTime = Read(br, ReadInt);
                return new Tag(alert, hasUrl, nativeUi, message, url, cacheTime);
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
                case Tag.TypeNumber: return (BotCallbackAnswer) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber });
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

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(BotCallbackAnswer other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is BotCallbackAnswer x && Equals(x);
        public static bool operator ==(BotCallbackAnswer x, BotCallbackAnswer y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(BotCallbackAnswer x, BotCallbackAnswer y) => !(x == y);

        public int CompareTo(BotCallbackAnswer other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is BotCallbackAnswer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotCallbackAnswer x, BotCallbackAnswer y) => x.CompareTo(y) <= 0;
        public static bool operator <(BotCallbackAnswer x, BotCallbackAnswer y) => x.CompareTo(y) < 0;
        public static bool operator >(BotCallbackAnswer x, BotCallbackAnswer y) => x.CompareTo(y) > 0;
        public static bool operator >=(BotCallbackAnswer x, BotCallbackAnswer y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"BotCallbackAnswer.{_tag.GetType().Name}{_tag}";
    }
}