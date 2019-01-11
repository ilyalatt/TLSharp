using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Help
{
    public sealed class AppUpdate : ITlType, IEquatable<AppUpdate>, IComparable<AppUpdate>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x8987f311;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Id { get; }
            public bool Critical { get; }
            public string Url { get; }
            public string Text { get; }
            
            public Tag(
                int id,
                bool critical,
                Some<string> url,
                Some<string> text
            ) {
                Id = id;
                Critical = critical;
                Url = url;
                Text = text;
            }
            
            (int, bool, string, string) CmpTuple =>
                (Id, Critical, Url, Text);

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

            public override string ToString() => $"(Id: {Id}, Critical: {Critical}, Url: {Url}, Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
                Write(Critical, bw, WriteBool);
                Write(Url, bw, WriteString);
                Write(Text, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                var critical = Read(br, ReadBool);
                var url = Read(br, ReadString);
                var text = Read(br, ReadString);
                return new Tag(id, critical, url, text);
            }
        }

        public sealed class NoTag : ITlTypeTag, IEquatable<NoTag>, IComparable<NoTag>, IComparable
        {
            internal const uint TypeNumber = 0xc45a6536;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public NoTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(NoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NoTag x && Equals(x);
            public static bool operator ==(NoTag x, NoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NoTag x, NoTag y) => !(x == y);

            public int CompareTo(NoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NoTag x, NoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NoTag x, NoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NoTag x, NoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NoTag x, NoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NoTag DeserializeTag(BinaryReader br)
            {

                return new NoTag();
            }
        }

        readonly ITlTypeTag _tag;
        AppUpdate(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator AppUpdate(Tag tag) => new AppUpdate(tag);
        public static explicit operator AppUpdate(NoTag tag) => new AppUpdate(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static AppUpdate Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (AppUpdate) Tag.DeserializeTag(br);
                case NoTag.TypeNumber: return (AppUpdate) NoTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, NoTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<NoTag, T> noTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case NoTag x when noTag != null: return noTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<NoTag, T> noTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            noTag ?? throw new ArgumentNullException(nameof(noTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case NoTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(AppUpdate other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is AppUpdate x && Equals(x);
        public static bool operator ==(AppUpdate x, AppUpdate y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AppUpdate x, AppUpdate y) => !(x == y);

        public int CompareTo(AppUpdate other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is AppUpdate x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AppUpdate x, AppUpdate y) => x.CompareTo(y) <= 0;
        public static bool operator <(AppUpdate x, AppUpdate y) => x.CompareTo(y) < 0;
        public static bool operator >(AppUpdate x, AppUpdate y) => x.CompareTo(y) > 0;
        public static bool operator >=(AppUpdate x, AppUpdate y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"AppUpdate.{_tag.GetType().Name}{_tag}";
    }
}