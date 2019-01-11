using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputChatPhoto : ITlType, IEquatable<InputChatPhoto>, IComparable<InputChatPhoto>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x1ca48f57;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class UploadedTag : ITlTypeTag, IEquatable<UploadedTag>, IComparable<UploadedTag>, IComparable
        {
            internal const uint TypeNumber = 0x927c55b4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputFile File { get; }
            
            public UploadedTag(
                Some<T.InputFile> file
            ) {
                File = file;
            }
            
            T.InputFile CmpTuple =>
                File;

            public bool Equals(UploadedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UploadedTag x && Equals(x);
            public static bool operator ==(UploadedTag x, UploadedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadedTag x, UploadedTag y) => !(x == y);

            public int CompareTo(UploadedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UploadedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadedTag x, UploadedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadedTag x, UploadedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadedTag x, UploadedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadedTag x, UploadedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(File: {File})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(File, bw, WriteSerializable);
            }
            
            internal static UploadedTag DeserializeTag(BinaryReader br)
            {
                var file = Read(br, T.InputFile.Deserialize);
                return new UploadedTag(file);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x8953ad37;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputPhoto Id { get; }
            
            public Tag(
                Some<T.InputPhoto> id
            ) {
                Id = id;
            }
            
            T.InputPhoto CmpTuple =>
                Id;

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

            public override string ToString() => $"(Id: {Id})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, T.InputPhoto.Deserialize);
                return new Tag(id);
            }
        }

        readonly ITlTypeTag _tag;
        InputChatPhoto(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputChatPhoto(EmptyTag tag) => new InputChatPhoto(tag);
        public static explicit operator InputChatPhoto(UploadedTag tag) => new InputChatPhoto(tag);
        public static explicit operator InputChatPhoto(Tag tag) => new InputChatPhoto(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputChatPhoto Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (InputChatPhoto) EmptyTag.DeserializeTag(br);
                case UploadedTag.TypeNumber: return (InputChatPhoto) UploadedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (InputChatPhoto) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, UploadedTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<UploadedTag, T> uploadedTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case UploadedTag x when uploadedTag != null: return uploadedTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<UploadedTag, T> uploadedTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            uploadedTag ?? throw new ArgumentNullException(nameof(uploadedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case UploadedTag _: return 1;
                case Tag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputChatPhoto other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is InputChatPhoto x && Equals(x);
        public static bool operator ==(InputChatPhoto x, InputChatPhoto y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputChatPhoto x, InputChatPhoto y) => !(x == y);

        public int CompareTo(InputChatPhoto other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputChatPhoto x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputChatPhoto x, InputChatPhoto y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputChatPhoto x, InputChatPhoto y) => x.CompareTo(y) < 0;
        public static bool operator >(InputChatPhoto x, InputChatPhoto y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputChatPhoto x, InputChatPhoto y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputChatPhoto.{_tag.GetType().Name}{_tag}";
    }
}