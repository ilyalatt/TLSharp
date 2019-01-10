using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputPaymentCredentials : ITlType, IEquatable<InputPaymentCredentials>, IComparable<InputPaymentCredentials>, IComparable
    {
        public sealed class SavedTag : Record<SavedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xc10eb2cf;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Id { get; }
            public Arr<byte> TmpPassword { get; }
            
            public SavedTag(
                Some<string> id,
                Some<Arr<byte>> tmpPassword
            ) {
                Id = id;
                TmpPassword = tmpPassword;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteString);
                Write(TmpPassword, bw, WriteBytes);
            }
            
            internal static SavedTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadString);
                var tmpPassword = Read(br, ReadBytes);
                return new SavedTag(id, tmpPassword);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x3417d728;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Save { get; }
            public T.DataJson Data { get; }
            
            public Tag(
                bool save,
                Some<T.DataJson> data
            ) {
                Save = save;
                Data = data;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Save), bw, WriteInt);
                Write(Data, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var save = Read(br, ReadOption(flags, 0));
                var data = Read(br, T.DataJson.Deserialize);
                return new Tag(save, data);
            }
        }

        readonly ITlTypeTag _tag;
        InputPaymentCredentials(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputPaymentCredentials(SavedTag tag) => new InputPaymentCredentials(tag);
        public static explicit operator InputPaymentCredentials(Tag tag) => new InputPaymentCredentials(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputPaymentCredentials Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case SavedTag.TypeNumber: return (InputPaymentCredentials) SavedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (InputPaymentCredentials) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { SavedTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<SavedTag, T> savedTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case SavedTag x when savedTag != null: return savedTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<SavedTag, T> savedTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            savedTag ?? throw new ArgumentNullException(nameof(savedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(InputPaymentCredentials other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputPaymentCredentials x && Equals(x);
        public static bool operator ==(InputPaymentCredentials a, InputPaymentCredentials b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputPaymentCredentials a, InputPaymentCredentials b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case SavedTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputPaymentCredentials other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputPaymentCredentials x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPaymentCredentials a, InputPaymentCredentials b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputPaymentCredentials a, InputPaymentCredentials b) => a.CompareTo(b) < 0;
        public static bool operator >(InputPaymentCredentials a, InputPaymentCredentials b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputPaymentCredentials a, InputPaymentCredentials b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}