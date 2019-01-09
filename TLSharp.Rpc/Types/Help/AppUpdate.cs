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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x8987f311;
            
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

        public sealed class NoTag : Record<NoTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xc45a6536;
            

            
            public NoTag(

            ) {

            }
            
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
                case 0x8987f311: return (AppUpdate) Tag.DeserializeTag(br);
                case 0xc45a6536: return (AppUpdate) NoTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x8987f311, 0xc45a6536 });
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

        public bool Equals(AppUpdate other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is AppUpdate x && Equals(x);
        public static bool operator ==(AppUpdate a, AppUpdate b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(AppUpdate a, AppUpdate b) => !(a == b);

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

        public int CompareTo(AppUpdate other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is AppUpdate x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AppUpdate a, AppUpdate b) => a.CompareTo(b) <= 0;
        public static bool operator <(AppUpdate a, AppUpdate b) => a.CompareTo(b) < 0;
        public static bool operator >(AppUpdate a, AppUpdate b) => a.CompareTo(b) > 0;
        public static bool operator >=(AppUpdate a, AppUpdate b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}