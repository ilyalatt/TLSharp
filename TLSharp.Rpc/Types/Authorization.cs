using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Authorization : ITlType, IEquatable<Authorization>, IComparable<Authorization>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x7bf2e6f6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Hash { get; }
            public int Flags { get; }
            public string DeviceModel { get; }
            public string Platform { get; }
            public string SystemVersion { get; }
            public int ApiId { get; }
            public string AppName { get; }
            public string AppVersion { get; }
            public int DateCreated { get; }
            public int DateActive { get; }
            public string Ip { get; }
            public string Country { get; }
            public string Region { get; }
            
            public Tag(
                long hash,
                int flags,
                Some<string> deviceModel,
                Some<string> platform,
                Some<string> systemVersion,
                int apiId,
                Some<string> appName,
                Some<string> appVersion,
                int dateCreated,
                int dateActive,
                Some<string> ip,
                Some<string> country,
                Some<string> region
            ) {
                Hash = hash;
                Flags = flags;
                DeviceModel = deviceModel;
                Platform = platform;
                SystemVersion = systemVersion;
                ApiId = apiId;
                AppName = appName;
                AppVersion = appVersion;
                DateCreated = dateCreated;
                DateActive = dateActive;
                Ip = ip;
                Country = country;
                Region = region;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Hash, bw, WriteLong);
                Write(Flags, bw, WriteInt);
                Write(DeviceModel, bw, WriteString);
                Write(Platform, bw, WriteString);
                Write(SystemVersion, bw, WriteString);
                Write(ApiId, bw, WriteInt);
                Write(AppName, bw, WriteString);
                Write(AppVersion, bw, WriteString);
                Write(DateCreated, bw, WriteInt);
                Write(DateActive, bw, WriteInt);
                Write(Ip, bw, WriteString);
                Write(Country, bw, WriteString);
                Write(Region, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var hash = Read(br, ReadLong);
                var flags = Read(br, ReadInt);
                var deviceModel = Read(br, ReadString);
                var platform = Read(br, ReadString);
                var systemVersion = Read(br, ReadString);
                var apiId = Read(br, ReadInt);
                var appName = Read(br, ReadString);
                var appVersion = Read(br, ReadString);
                var dateCreated = Read(br, ReadInt);
                var dateActive = Read(br, ReadInt);
                var ip = Read(br, ReadString);
                var country = Read(br, ReadString);
                var region = Read(br, ReadString);
                return new Tag(hash, flags, deviceModel, platform, systemVersion, apiId, appName, appVersion, dateCreated, dateActive, ip, country, region);
            }
        }

        readonly ITlTypeTag _tag;
        Authorization(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Authorization(Tag tag) => new Authorization(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Authorization Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (Authorization) Tag.DeserializeTag(br);
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

        public bool Equals(Authorization other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Authorization x && Equals(x);
        public static bool operator ==(Authorization a, Authorization b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Authorization a, Authorization b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Authorization other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Authorization x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Authorization a, Authorization b) => a.CompareTo(b) <= 0;
        public static bool operator <(Authorization a, Authorization b) => a.CompareTo(b) < 0;
        public static bool operator >(Authorization a, Authorization b) => a.CompareTo(b) > 0;
        public static bool operator >=(Authorization a, Authorization b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}