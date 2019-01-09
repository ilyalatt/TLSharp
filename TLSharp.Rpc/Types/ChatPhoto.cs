using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChatPhoto : ITlType, IEquatable<ChatPhoto>, IComparable<ChatPhoto>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x37c1011c;
            

            
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
            uint ITlTypeTag.TypeNumber => 0x6153276a;
            
            public T.FileLocation PhotoSmall { get; }
            public T.FileLocation PhotoBig { get; }
            
            public Tag(
                Some<T.FileLocation> photoSmall,
                Some<T.FileLocation> photoBig
            ) {
                PhotoSmall = photoSmall;
                PhotoBig = photoBig;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PhotoSmall, bw, WriteSerializable);
                Write(PhotoBig, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var photoSmall = Read(br, T.FileLocation.Deserialize);
                var photoBig = Read(br, T.FileLocation.Deserialize);
                return new Tag(photoSmall, photoBig);
            }
        }

        readonly ITlTypeTag _tag;
        ChatPhoto(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChatPhoto(EmptyTag tag) => new ChatPhoto(tag);
        public static explicit operator ChatPhoto(Tag tag) => new ChatPhoto(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChatPhoto Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x37c1011c: return (ChatPhoto) EmptyTag.DeserializeTag(br);
                case 0x6153276a: return (ChatPhoto) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x37c1011c, 0x6153276a });
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

        public bool Equals(ChatPhoto other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ChatPhoto x && Equals(x);
        public static bool operator ==(ChatPhoto a, ChatPhoto b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ChatPhoto a, ChatPhoto b) => !(a == b);

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

        public int CompareTo(ChatPhoto other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChatPhoto x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChatPhoto a, ChatPhoto b) => a.CompareTo(b) <= 0;
        public static bool operator <(ChatPhoto a, ChatPhoto b) => a.CompareTo(b) < 0;
        public static bool operator >(ChatPhoto a, ChatPhoto b) => a.CompareTo(b) > 0;
        public static bool operator >=(ChatPhoto a, ChatPhoto b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}