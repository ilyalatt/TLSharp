using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class KeyboardButton : ITlType, IEquatable<KeyboardButton>, IComparable<KeyboardButton>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xa2fa4880;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Text { get; }
            
            public Tag(
                Some<string> text
            ) {
                Text = text;
            }
            
            string CmpTuple =>
                Text;

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, ReadString);
                return new Tag(text);
            }
        }

        public sealed class UrlTag : ITlTypeTag, IEquatable<UrlTag>, IComparable<UrlTag>, IComparable
        {
            internal const uint TypeNumber = 0x258aff05;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Text { get; }
            public string Url { get; }
            
            public UrlTag(
                Some<string> text,
                Some<string> url
            ) {
                Text = text;
                Url = url;
            }
            
            (string, string) CmpTuple =>
                (Text, Url);

            public bool Equals(UrlTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UrlTag x && Equals(x);
            public static bool operator ==(UrlTag x, UrlTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UrlTag x, UrlTag y) => !(x == y);

            public int CompareTo(UrlTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UrlTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UrlTag x, UrlTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UrlTag x, UrlTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UrlTag x, UrlTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UrlTag x, UrlTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text}, Url: {Url})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteString);
                Write(Url, bw, WriteString);
            }
            
            internal static UrlTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, ReadString);
                var url = Read(br, ReadString);
                return new UrlTag(text, url);
            }
        }

        public sealed class CallbackTag : ITlTypeTag, IEquatable<CallbackTag>, IComparable<CallbackTag>, IComparable
        {
            internal const uint TypeNumber = 0x683a5e46;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Text { get; }
            public Arr<byte> Data { get; }
            
            public CallbackTag(
                Some<string> text,
                Some<Arr<byte>> data
            ) {
                Text = text;
                Data = data;
            }
            
            (string, Arr<byte>) CmpTuple =>
                (Text, Data);

            public bool Equals(CallbackTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is CallbackTag x && Equals(x);
            public static bool operator ==(CallbackTag x, CallbackTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CallbackTag x, CallbackTag y) => !(x == y);

            public int CompareTo(CallbackTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is CallbackTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CallbackTag x, CallbackTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CallbackTag x, CallbackTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CallbackTag x, CallbackTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CallbackTag x, CallbackTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text}, Data: {Data})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteString);
                Write(Data, bw, WriteBytes);
            }
            
            internal static CallbackTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, ReadString);
                var data = Read(br, ReadBytes);
                return new CallbackTag(text, data);
            }
        }

        public sealed class RequestPhoneTag : ITlTypeTag, IEquatable<RequestPhoneTag>, IComparable<RequestPhoneTag>, IComparable
        {
            internal const uint TypeNumber = 0xb16a6c29;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Text { get; }
            
            public RequestPhoneTag(
                Some<string> text
            ) {
                Text = text;
            }
            
            string CmpTuple =>
                Text;

            public bool Equals(RequestPhoneTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is RequestPhoneTag x && Equals(x);
            public static bool operator ==(RequestPhoneTag x, RequestPhoneTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RequestPhoneTag x, RequestPhoneTag y) => !(x == y);

            public int CompareTo(RequestPhoneTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is RequestPhoneTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RequestPhoneTag x, RequestPhoneTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RequestPhoneTag x, RequestPhoneTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RequestPhoneTag x, RequestPhoneTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RequestPhoneTag x, RequestPhoneTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteString);
            }
            
            internal static RequestPhoneTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, ReadString);
                return new RequestPhoneTag(text);
            }
        }

        public sealed class RequestGeoLocationTag : ITlTypeTag, IEquatable<RequestGeoLocationTag>, IComparable<RequestGeoLocationTag>, IComparable
        {
            internal const uint TypeNumber = 0xfc796b3f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Text { get; }
            
            public RequestGeoLocationTag(
                Some<string> text
            ) {
                Text = text;
            }
            
            string CmpTuple =>
                Text;

            public bool Equals(RequestGeoLocationTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is RequestGeoLocationTag x && Equals(x);
            public static bool operator ==(RequestGeoLocationTag x, RequestGeoLocationTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RequestGeoLocationTag x, RequestGeoLocationTag y) => !(x == y);

            public int CompareTo(RequestGeoLocationTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is RequestGeoLocationTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RequestGeoLocationTag x, RequestGeoLocationTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RequestGeoLocationTag x, RequestGeoLocationTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RequestGeoLocationTag x, RequestGeoLocationTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RequestGeoLocationTag x, RequestGeoLocationTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteString);
            }
            
            internal static RequestGeoLocationTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, ReadString);
                return new RequestGeoLocationTag(text);
            }
        }

        public sealed class SwitchInlineTag : ITlTypeTag, IEquatable<SwitchInlineTag>, IComparable<SwitchInlineTag>, IComparable
        {
            internal const uint TypeNumber = 0x0568a748;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool SamePeer { get; }
            public string Text { get; }
            public string Query { get; }
            
            public SwitchInlineTag(
                bool samePeer,
                Some<string> text,
                Some<string> query
            ) {
                SamePeer = samePeer;
                Text = text;
                Query = query;
            }
            
            (bool, string, string) CmpTuple =>
                (SamePeer, Text, Query);

            public bool Equals(SwitchInlineTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is SwitchInlineTag x && Equals(x);
            public static bool operator ==(SwitchInlineTag x, SwitchInlineTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SwitchInlineTag x, SwitchInlineTag y) => !(x == y);

            public int CompareTo(SwitchInlineTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is SwitchInlineTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SwitchInlineTag x, SwitchInlineTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SwitchInlineTag x, SwitchInlineTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SwitchInlineTag x, SwitchInlineTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SwitchInlineTag x, SwitchInlineTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(SamePeer: {SamePeer}, Text: {Text}, Query: {Query})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, SamePeer), bw, WriteInt);
                Write(Text, bw, WriteString);
                Write(Query, bw, WriteString);
            }
            
            internal static SwitchInlineTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var samePeer = Read(br, ReadOption(flags, 0));
                var text = Read(br, ReadString);
                var query = Read(br, ReadString);
                return new SwitchInlineTag(samePeer, text, query);
            }
        }

        public sealed class GameTag : ITlTypeTag, IEquatable<GameTag>, IComparable<GameTag>, IComparable
        {
            internal const uint TypeNumber = 0x50f41ccf;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Text { get; }
            
            public GameTag(
                Some<string> text
            ) {
                Text = text;
            }
            
            string CmpTuple =>
                Text;

            public bool Equals(GameTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is GameTag x && Equals(x);
            public static bool operator ==(GameTag x, GameTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GameTag x, GameTag y) => !(x == y);

            public int CompareTo(GameTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is GameTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GameTag x, GameTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GameTag x, GameTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GameTag x, GameTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GameTag x, GameTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteString);
            }
            
            internal static GameTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, ReadString);
                return new GameTag(text);
            }
        }

        public sealed class BuyTag : ITlTypeTag, IEquatable<BuyTag>, IComparable<BuyTag>, IComparable
        {
            internal const uint TypeNumber = 0xafd93fbb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Text { get; }
            
            public BuyTag(
                Some<string> text
            ) {
                Text = text;
            }
            
            string CmpTuple =>
                Text;

            public bool Equals(BuyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BuyTag x && Equals(x);
            public static bool operator ==(BuyTag x, BuyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BuyTag x, BuyTag y) => !(x == y);

            public int CompareTo(BuyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BuyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BuyTag x, BuyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BuyTag x, BuyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BuyTag x, BuyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BuyTag x, BuyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteString);
            }
            
            internal static BuyTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, ReadString);
                return new BuyTag(text);
            }
        }

        readonly ITlTypeTag _tag;
        KeyboardButton(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator KeyboardButton(Tag tag) => new KeyboardButton(tag);
        public static explicit operator KeyboardButton(UrlTag tag) => new KeyboardButton(tag);
        public static explicit operator KeyboardButton(CallbackTag tag) => new KeyboardButton(tag);
        public static explicit operator KeyboardButton(RequestPhoneTag tag) => new KeyboardButton(tag);
        public static explicit operator KeyboardButton(RequestGeoLocationTag tag) => new KeyboardButton(tag);
        public static explicit operator KeyboardButton(SwitchInlineTag tag) => new KeyboardButton(tag);
        public static explicit operator KeyboardButton(GameTag tag) => new KeyboardButton(tag);
        public static explicit operator KeyboardButton(BuyTag tag) => new KeyboardButton(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static KeyboardButton Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (KeyboardButton) Tag.DeserializeTag(br);
                case UrlTag.TypeNumber: return (KeyboardButton) UrlTag.DeserializeTag(br);
                case CallbackTag.TypeNumber: return (KeyboardButton) CallbackTag.DeserializeTag(br);
                case RequestPhoneTag.TypeNumber: return (KeyboardButton) RequestPhoneTag.DeserializeTag(br);
                case RequestGeoLocationTag.TypeNumber: return (KeyboardButton) RequestGeoLocationTag.DeserializeTag(br);
                case SwitchInlineTag.TypeNumber: return (KeyboardButton) SwitchInlineTag.DeserializeTag(br);
                case GameTag.TypeNumber: return (KeyboardButton) GameTag.DeserializeTag(br);
                case BuyTag.TypeNumber: return (KeyboardButton) BuyTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, UrlTag.TypeNumber, CallbackTag.TypeNumber, RequestPhoneTag.TypeNumber, RequestGeoLocationTag.TypeNumber, SwitchInlineTag.TypeNumber, GameTag.TypeNumber, BuyTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<UrlTag, T> urlTag = null,
            Func<CallbackTag, T> callbackTag = null,
            Func<RequestPhoneTag, T> requestPhoneTag = null,
            Func<RequestGeoLocationTag, T> requestGeoLocationTag = null,
            Func<SwitchInlineTag, T> switchInlineTag = null,
            Func<GameTag, T> gameTag = null,
            Func<BuyTag, T> buyTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case UrlTag x when urlTag != null: return urlTag(x);
                case CallbackTag x when callbackTag != null: return callbackTag(x);
                case RequestPhoneTag x when requestPhoneTag != null: return requestPhoneTag(x);
                case RequestGeoLocationTag x when requestGeoLocationTag != null: return requestGeoLocationTag(x);
                case SwitchInlineTag x when switchInlineTag != null: return switchInlineTag(x);
                case GameTag x when gameTag != null: return gameTag(x);
                case BuyTag x when buyTag != null: return buyTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<UrlTag, T> urlTag,
            Func<CallbackTag, T> callbackTag,
            Func<RequestPhoneTag, T> requestPhoneTag,
            Func<RequestGeoLocationTag, T> requestGeoLocationTag,
            Func<SwitchInlineTag, T> switchInlineTag,
            Func<GameTag, T> gameTag,
            Func<BuyTag, T> buyTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            urlTag ?? throw new ArgumentNullException(nameof(urlTag)),
            callbackTag ?? throw new ArgumentNullException(nameof(callbackTag)),
            requestPhoneTag ?? throw new ArgumentNullException(nameof(requestPhoneTag)),
            requestGeoLocationTag ?? throw new ArgumentNullException(nameof(requestGeoLocationTag)),
            switchInlineTag ?? throw new ArgumentNullException(nameof(switchInlineTag)),
            gameTag ?? throw new ArgumentNullException(nameof(gameTag)),
            buyTag ?? throw new ArgumentNullException(nameof(buyTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case UrlTag _: return 1;
                case CallbackTag _: return 2;
                case RequestPhoneTag _: return 3;
                case RequestGeoLocationTag _: return 4;
                case SwitchInlineTag _: return 5;
                case GameTag _: return 6;
                case BuyTag _: return 7;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(KeyboardButton other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is KeyboardButton x && Equals(x);
        public static bool operator ==(KeyboardButton x, KeyboardButton y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(KeyboardButton x, KeyboardButton y) => !(x == y);

        public int CompareTo(KeyboardButton other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is KeyboardButton x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(KeyboardButton x, KeyboardButton y) => x.CompareTo(y) <= 0;
        public static bool operator <(KeyboardButton x, KeyboardButton y) => x.CompareTo(y) < 0;
        public static bool operator >(KeyboardButton x, KeyboardButton y) => x.CompareTo(y) > 0;
        public static bool operator >=(KeyboardButton x, KeyboardButton y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"KeyboardButton.{_tag.GetType().Name}{_tag}";
    }
}