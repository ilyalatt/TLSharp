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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xa2fa4880;
            
            public string Text { get; }
            
            public Tag(
                Some<string> text
            ) {
                Text = text;
            }
            
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

        public sealed class UrlTag : Record<UrlTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x258aff05;
            
            public string Text { get; }
            public string Url { get; }
            
            public UrlTag(
                Some<string> text,
                Some<string> url
            ) {
                Text = text;
                Url = url;
            }
            
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

        public sealed class CallbackTag : Record<CallbackTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x683a5e46;
            
            public string Text { get; }
            public Arr<byte> Data { get; }
            
            public CallbackTag(
                Some<string> text,
                Some<Arr<byte>> data
            ) {
                Text = text;
                Data = data;
            }
            
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

        public sealed class RequestPhoneTag : Record<RequestPhoneTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xb16a6c29;
            
            public string Text { get; }
            
            public RequestPhoneTag(
                Some<string> text
            ) {
                Text = text;
            }
            
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

        public sealed class RequestGeoLocationTag : Record<RequestGeoLocationTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfc796b3f;
            
            public string Text { get; }
            
            public RequestGeoLocationTag(
                Some<string> text
            ) {
                Text = text;
            }
            
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

        public sealed class SwitchInlineTag : Record<SwitchInlineTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x0568a748;
            
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

        public sealed class GameTag : Record<GameTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x50f41ccf;
            
            public string Text { get; }
            
            public GameTag(
                Some<string> text
            ) {
                Text = text;
            }
            
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

        public sealed class BuyTag : Record<BuyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xafd93fbb;
            
            public string Text { get; }
            
            public BuyTag(
                Some<string> text
            ) {
                Text = text;
            }
            
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
                case 0xa2fa4880: return (KeyboardButton) Tag.DeserializeTag(br);
                case 0x258aff05: return (KeyboardButton) UrlTag.DeserializeTag(br);
                case 0x683a5e46: return (KeyboardButton) CallbackTag.DeserializeTag(br);
                case 0xb16a6c29: return (KeyboardButton) RequestPhoneTag.DeserializeTag(br);
                case 0xfc796b3f: return (KeyboardButton) RequestGeoLocationTag.DeserializeTag(br);
                case 0x0568a748: return (KeyboardButton) SwitchInlineTag.DeserializeTag(br);
                case 0x50f41ccf: return (KeyboardButton) GameTag.DeserializeTag(br);
                case 0xafd93fbb: return (KeyboardButton) BuyTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xa2fa4880, 0x258aff05, 0x683a5e46, 0xb16a6c29, 0xfc796b3f, 0x0568a748, 0x50f41ccf, 0xafd93fbb });
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

        public bool Equals(KeyboardButton other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is KeyboardButton x && Equals(x);
        public static bool operator ==(KeyboardButton a, KeyboardButton b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(KeyboardButton a, KeyboardButton b) => !(a == b);

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

        public int CompareTo(KeyboardButton other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is KeyboardButton x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(KeyboardButton a, KeyboardButton b) => a.CompareTo(b) <= 0;
        public static bool operator <(KeyboardButton a, KeyboardButton b) => a.CompareTo(b) < 0;
        public static bool operator >(KeyboardButton a, KeyboardButton b) => a.CompareTo(b) > 0;
        public static bool operator >=(KeyboardButton a, KeyboardButton b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}