using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputWebFileLocation : ITlType, IEquatable<InputWebFileLocation>, IComparable<InputWebFileLocation>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xc239d686;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly long AccessHash;
            
            public Tag(
                Some<string> url,
                long accessHash
            ) {
                Url = url;
                AccessHash = accessHash;
            }
            
            (string, long) CmpTuple =>
                (Url, AccessHash);

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

            public override string ToString() => $"(Url: {Url}, AccessHash: {AccessHash})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var accessHash = Read(br, ReadLong);
                return new Tag(url, accessHash);
            }
        }

        public sealed class GeoPointTag : ITlTypeTag, IEquatable<GeoPointTag>, IComparable<GeoPointTag>, IComparable
        {
            internal const uint TypeNumber = 0x9f2221c9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputGeoPoint GeoPoint;
            public readonly long AccessHash;
            public readonly int W;
            public readonly int H;
            public readonly int Zoom;
            public readonly int Scale;
            
            public GeoPointTag(
                Some<T.InputGeoPoint> geoPoint,
                long accessHash,
                int w,
                int h,
                int zoom,
                int scale
            ) {
                GeoPoint = geoPoint;
                AccessHash = accessHash;
                W = w;
                H = h;
                Zoom = zoom;
                Scale = scale;
            }
            
            (T.InputGeoPoint, long, int, int, int, int) CmpTuple =>
                (GeoPoint, AccessHash, W, H, Zoom, Scale);

            public bool Equals(GeoPointTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is GeoPointTag x && Equals(x);
            public static bool operator ==(GeoPointTag x, GeoPointTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GeoPointTag x, GeoPointTag y) => !(x == y);

            public int CompareTo(GeoPointTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is GeoPointTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GeoPointTag x, GeoPointTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GeoPointTag x, GeoPointTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GeoPointTag x, GeoPointTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GeoPointTag x, GeoPointTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(GeoPoint: {GeoPoint}, AccessHash: {AccessHash}, W: {W}, H: {H}, Zoom: {Zoom}, Scale: {Scale})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(GeoPoint, bw, WriteSerializable);
                Write(AccessHash, bw, WriteLong);
                Write(W, bw, WriteInt);
                Write(H, bw, WriteInt);
                Write(Zoom, bw, WriteInt);
                Write(Scale, bw, WriteInt);
            }
            
            internal static GeoPointTag DeserializeTag(BinaryReader br)
            {
                var geoPoint = Read(br, T.InputGeoPoint.Deserialize);
                var accessHash = Read(br, ReadLong);
                var w = Read(br, ReadInt);
                var h = Read(br, ReadInt);
                var zoom = Read(br, ReadInt);
                var scale = Read(br, ReadInt);
                return new GeoPointTag(geoPoint, accessHash, w, h, zoom, scale);
            }
        }

        readonly ITlTypeTag _tag;
        InputWebFileLocation(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputWebFileLocation(Tag tag) => new InputWebFileLocation(tag);
        public static explicit operator InputWebFileLocation(GeoPointTag tag) => new InputWebFileLocation(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputWebFileLocation Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputWebFileLocation) Tag.DeserializeTag(br);
                case GeoPointTag.TypeNumber: return (InputWebFileLocation) GeoPointTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, GeoPointTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<GeoPointTag, T> geoPointTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case GeoPointTag x when geoPointTag != null: return geoPointTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<GeoPointTag, T> geoPointTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            geoPointTag ?? throw new ArgumentNullException(nameof(geoPointTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case GeoPointTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputWebFileLocation other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputWebFileLocation x && Equals(x);
        public static bool operator ==(InputWebFileLocation x, InputWebFileLocation y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputWebFileLocation x, InputWebFileLocation y) => !(x == y);

        public int CompareTo(InputWebFileLocation other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputWebFileLocation x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputWebFileLocation x, InputWebFileLocation y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputWebFileLocation x, InputWebFileLocation y) => x.CompareTo(y) < 0;
        public static bool operator >(InputWebFileLocation x, InputWebFileLocation y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputWebFileLocation x, InputWebFileLocation y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputWebFileLocation.{_tag.GetType().Name}{_tag}";
    }
}