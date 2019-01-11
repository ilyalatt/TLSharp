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
        public sealed class SavedTag : ITlTypeTag, IEquatable<SavedTag>, IComparable<SavedTag>, IComparable
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
            
            (string, Arr<byte>) CmpTuple =>
                (Id, TmpPassword);

            public bool Equals(SavedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is SavedTag x && Equals(x);
            public static bool operator ==(SavedTag x, SavedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SavedTag x, SavedTag y) => !(x == y);

            public int CompareTo(SavedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is SavedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SavedTag x, SavedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SavedTag x, SavedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SavedTag x, SavedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SavedTag x, SavedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, TmpPassword: {TmpPassword})";
            
            
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

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
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
            
            (bool, T.DataJson) CmpTuple =>
                (Save, Data);

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

            public override string ToString() => $"(Save: {Save}, Data: {Data})";
            
            
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

        public bool Equals(InputPaymentCredentials other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is InputPaymentCredentials x && Equals(x);
        public static bool operator ==(InputPaymentCredentials x, InputPaymentCredentials y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputPaymentCredentials x, InputPaymentCredentials y) => !(x == y);

        public int CompareTo(InputPaymentCredentials other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputPaymentCredentials x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPaymentCredentials x, InputPaymentCredentials y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputPaymentCredentials x, InputPaymentCredentials y) => x.CompareTo(y) < 0;
        public static bool operator >(InputPaymentCredentials x, InputPaymentCredentials y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputPaymentCredentials x, InputPaymentCredentials y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputPaymentCredentials.{_tag.GetType().Name}{_tag}";
    }
}