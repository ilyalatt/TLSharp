using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class SecureValue : ITlType, IEquatable<SecureValue>, IComparable<SecureValue>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xb4b4b699;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.SecureValueType Type;
            public readonly Option<T.SecureData> Data;
            public readonly Option<T.SecureFile> FrontSide;
            public readonly Option<T.SecureFile> ReverseSide;
            public readonly Option<T.SecureFile> Selfie;
            public readonly Option<Arr<T.SecureFile>> Files;
            public readonly Option<T.SecurePlainData> PlainData;
            public readonly Arr<byte> Hash;
            
            public Tag(
                Some<T.SecureValueType> type,
                Option<T.SecureData> data,
                Option<T.SecureFile> frontSide,
                Option<T.SecureFile> reverseSide,
                Option<T.SecureFile> selfie,
                Option<Arr<T.SecureFile>> files,
                Option<T.SecurePlainData> plainData,
                Some<Arr<byte>> hash
            ) {
                Type = type;
                Data = data;
                FrontSide = frontSide;
                ReverseSide = reverseSide;
                Selfie = selfie;
                Files = files;
                PlainData = plainData;
                Hash = hash;
            }
            
            (T.SecureValueType, Option<T.SecureData>, Option<T.SecureFile>, Option<T.SecureFile>, Option<T.SecureFile>, Option<Arr<T.SecureFile>>, Option<T.SecurePlainData>, Arr<byte>) CmpTuple =>
                (Type, Data, FrontSide, ReverseSide, Selfie, Files, PlainData, Hash);

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

            public override string ToString() => $"(Type: {Type}, Data: {Data}, FrontSide: {FrontSide}, ReverseSide: {ReverseSide}, Selfie: {Selfie}, Files: {Files}, PlainData: {PlainData}, Hash: {Hash})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Data) | MaskBit(1, FrontSide) | MaskBit(2, ReverseSide) | MaskBit(3, Selfie) | MaskBit(4, Files) | MaskBit(5, PlainData), bw, WriteInt);
                Write(Type, bw, WriteSerializable);
                Write(Data, bw, WriteOption<T.SecureData>(WriteSerializable));
                Write(FrontSide, bw, WriteOption<T.SecureFile>(WriteSerializable));
                Write(ReverseSide, bw, WriteOption<T.SecureFile>(WriteSerializable));
                Write(Selfie, bw, WriteOption<T.SecureFile>(WriteSerializable));
                Write(Files, bw, WriteOption<Arr<T.SecureFile>>(WriteVector<T.SecureFile>(WriteSerializable)));
                Write(PlainData, bw, WriteOption<T.SecurePlainData>(WriteSerializable));
                Write(Hash, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var type = Read(br, T.SecureValueType.Deserialize);
                var data = Read(br, ReadOption(flags, 0, T.SecureData.Deserialize));
                var frontSide = Read(br, ReadOption(flags, 1, T.SecureFile.Deserialize));
                var reverseSide = Read(br, ReadOption(flags, 2, T.SecureFile.Deserialize));
                var selfie = Read(br, ReadOption(flags, 3, T.SecureFile.Deserialize));
                var files = Read(br, ReadOption(flags, 4, ReadVector(T.SecureFile.Deserialize)));
                var plainData = Read(br, ReadOption(flags, 5, T.SecurePlainData.Deserialize));
                var hash = Read(br, ReadBytes);
                return new Tag(type, data, frontSide, reverseSide, selfie, files, plainData, hash);
            }
        }

        readonly ITlTypeTag _tag;
        SecureValue(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SecureValue(Tag tag) => new SecureValue(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SecureValue Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (SecureValue) Tag.DeserializeTag(br);
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

        public bool Equals(SecureValue other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is SecureValue x && Equals(x);
        public static bool operator ==(SecureValue x, SecureValue y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SecureValue x, SecureValue y) => !(x == y);

        public int CompareTo(SecureValue other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is SecureValue x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SecureValue x, SecureValue y) => x.CompareTo(y) <= 0;
        public static bool operator <(SecureValue x, SecureValue y) => x.CompareTo(y) < 0;
        public static bool operator >(SecureValue x, SecureValue y) => x.CompareTo(y) > 0;
        public static bool operator >=(SecureValue x, SecureValue y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SecureValue.{_tag.GetType().Name}{_tag}";
    }
}