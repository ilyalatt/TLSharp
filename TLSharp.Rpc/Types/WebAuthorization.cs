using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class WebAuthorization : ITlType, IEquatable<WebAuthorization>, IComparable<WebAuthorization>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xcac943f2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Hash;
            public readonly int BotId;
            public readonly string Domain;
            public readonly string Browser;
            public readonly string Platform;
            public readonly int DateCreated;
            public readonly int DateActive;
            public readonly string Ip;
            public readonly string Region;
            
            public Tag(
                long hash,
                int botId,
                Some<string> domain,
                Some<string> browser,
                Some<string> platform,
                int dateCreated,
                int dateActive,
                Some<string> ip,
                Some<string> region
            ) {
                Hash = hash;
                BotId = botId;
                Domain = domain;
                Browser = browser;
                Platform = platform;
                DateCreated = dateCreated;
                DateActive = dateActive;
                Ip = ip;
                Region = region;
            }
            
            (long, int, string, string, string, int, int, string, string) CmpTuple =>
                (Hash, BotId, Domain, Browser, Platform, DateCreated, DateActive, Ip, Region);

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

            public override string ToString() => $"(Hash: {Hash}, BotId: {BotId}, Domain: {Domain}, Browser: {Browser}, Platform: {Platform}, DateCreated: {DateCreated}, DateActive: {DateActive}, Ip: {Ip}, Region: {Region})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Hash, bw, WriteLong);
                Write(BotId, bw, WriteInt);
                Write(Domain, bw, WriteString);
                Write(Browser, bw, WriteString);
                Write(Platform, bw, WriteString);
                Write(DateCreated, bw, WriteInt);
                Write(DateActive, bw, WriteInt);
                Write(Ip, bw, WriteString);
                Write(Region, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var hash = Read(br, ReadLong);
                var botId = Read(br, ReadInt);
                var domain = Read(br, ReadString);
                var browser = Read(br, ReadString);
                var platform = Read(br, ReadString);
                var dateCreated = Read(br, ReadInt);
                var dateActive = Read(br, ReadInt);
                var ip = Read(br, ReadString);
                var region = Read(br, ReadString);
                return new Tag(hash, botId, domain, browser, platform, dateCreated, dateActive, ip, region);
            }
        }

        readonly ITlTypeTag _tag;
        WebAuthorization(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator WebAuthorization(Tag tag) => new WebAuthorization(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static WebAuthorization Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (WebAuthorization) Tag.DeserializeTag(br);
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

        public bool Equals(WebAuthorization other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is WebAuthorization x && Equals(x);
        public static bool operator ==(WebAuthorization x, WebAuthorization y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(WebAuthorization x, WebAuthorization y) => !(x == y);

        public int CompareTo(WebAuthorization other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is WebAuthorization x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(WebAuthorization x, WebAuthorization y) => x.CompareTo(y) <= 0;
        public static bool operator <(WebAuthorization x, WebAuthorization y) => x.CompareTo(y) < 0;
        public static bool operator >(WebAuthorization x, WebAuthorization y) => x.CompareTo(y) > 0;
        public static bool operator >=(WebAuthorization x, WebAuthorization y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"WebAuthorization.{_tag.GetType().Name}{_tag}";
    }
}