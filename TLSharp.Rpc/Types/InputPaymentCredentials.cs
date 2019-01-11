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
            
            public readonly string Id;
            public readonly Arr<byte> TmpPassword;
            
            public SavedTag(
                Some<string> id,
                Some<Arr<byte>> tmpPassword
            ) {
                Id = id;
                TmpPassword = tmpPassword;
            }
            
            (string, Arr<byte>) CmpTuple =>
                (Id, TmpPassword);

            public bool Equals(SavedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SavedTag x && Equals(x);
            public static bool operator ==(SavedTag x, SavedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SavedTag x, SavedTag y) => !(x == y);

            public int CompareTo(SavedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
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
            
            public readonly bool Save;
            public readonly T.DataJson Data;
            
            public Tag(
                bool save,
                Some<T.DataJson> data
            ) {
                Save = save;
                Data = data;
            }
            
            (bool, T.DataJson) CmpTuple =>
                (Save, Data);

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

        public sealed class ApplePayTag : ITlTypeTag, IEquatable<ApplePayTag>, IComparable<ApplePayTag>, IComparable
        {
            internal const uint TypeNumber = 0x0aa1c39f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.DataJson PaymentData;
            
            public ApplePayTag(
                Some<T.DataJson> paymentData
            ) {
                PaymentData = paymentData;
            }
            
            T.DataJson CmpTuple =>
                PaymentData;

            public bool Equals(ApplePayTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ApplePayTag x && Equals(x);
            public static bool operator ==(ApplePayTag x, ApplePayTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ApplePayTag x, ApplePayTag y) => !(x == y);

            public int CompareTo(ApplePayTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ApplePayTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ApplePayTag x, ApplePayTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ApplePayTag x, ApplePayTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ApplePayTag x, ApplePayTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ApplePayTag x, ApplePayTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PaymentData: {PaymentData})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PaymentData, bw, WriteSerializable);
            }
            
            internal static ApplePayTag DeserializeTag(BinaryReader br)
            {
                var paymentData = Read(br, T.DataJson.Deserialize);
                return new ApplePayTag(paymentData);
            }
        }

        public sealed class AndroidPayTag : ITlTypeTag, IEquatable<AndroidPayTag>, IComparable<AndroidPayTag>, IComparable
        {
            internal const uint TypeNumber = 0xca05d50e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.DataJson PaymentToken;
            public readonly string GoogleTransactionId;
            
            public AndroidPayTag(
                Some<T.DataJson> paymentToken,
                Some<string> googleTransactionId
            ) {
                PaymentToken = paymentToken;
                GoogleTransactionId = googleTransactionId;
            }
            
            (T.DataJson, string) CmpTuple =>
                (PaymentToken, GoogleTransactionId);

            public bool Equals(AndroidPayTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AndroidPayTag x && Equals(x);
            public static bool operator ==(AndroidPayTag x, AndroidPayTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AndroidPayTag x, AndroidPayTag y) => !(x == y);

            public int CompareTo(AndroidPayTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AndroidPayTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AndroidPayTag x, AndroidPayTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AndroidPayTag x, AndroidPayTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AndroidPayTag x, AndroidPayTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AndroidPayTag x, AndroidPayTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PaymentToken: {PaymentToken}, GoogleTransactionId: {GoogleTransactionId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PaymentToken, bw, WriteSerializable);
                Write(GoogleTransactionId, bw, WriteString);
            }
            
            internal static AndroidPayTag DeserializeTag(BinaryReader br)
            {
                var paymentToken = Read(br, T.DataJson.Deserialize);
                var googleTransactionId = Read(br, ReadString);
                return new AndroidPayTag(paymentToken, googleTransactionId);
            }
        }

        readonly ITlTypeTag _tag;
        InputPaymentCredentials(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputPaymentCredentials(SavedTag tag) => new InputPaymentCredentials(tag);
        public static explicit operator InputPaymentCredentials(Tag tag) => new InputPaymentCredentials(tag);
        public static explicit operator InputPaymentCredentials(ApplePayTag tag) => new InputPaymentCredentials(tag);
        public static explicit operator InputPaymentCredentials(AndroidPayTag tag) => new InputPaymentCredentials(tag);

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
                case ApplePayTag.TypeNumber: return (InputPaymentCredentials) ApplePayTag.DeserializeTag(br);
                case AndroidPayTag.TypeNumber: return (InputPaymentCredentials) AndroidPayTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { SavedTag.TypeNumber, Tag.TypeNumber, ApplePayTag.TypeNumber, AndroidPayTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<SavedTag, T> savedTag = null,
            Func<Tag, T> tag = null,
            Func<ApplePayTag, T> applePayTag = null,
            Func<AndroidPayTag, T> androidPayTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case SavedTag x when savedTag != null: return savedTag(x);
                case Tag x when tag != null: return tag(x);
                case ApplePayTag x when applePayTag != null: return applePayTag(x);
                case AndroidPayTag x when androidPayTag != null: return androidPayTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<SavedTag, T> savedTag,
            Func<Tag, T> tag,
            Func<ApplePayTag, T> applePayTag,
            Func<AndroidPayTag, T> androidPayTag
        ) => Match(
            () => throw new Exception("WTF"),
            savedTag ?? throw new ArgumentNullException(nameof(savedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            applePayTag ?? throw new ArgumentNullException(nameof(applePayTag)),
            androidPayTag ?? throw new ArgumentNullException(nameof(androidPayTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case SavedTag _: return 0;
                case Tag _: return 1;
                case ApplePayTag _: return 2;
                case AndroidPayTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputPaymentCredentials other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputPaymentCredentials x && Equals(x);
        public static bool operator ==(InputPaymentCredentials x, InputPaymentCredentials y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputPaymentCredentials x, InputPaymentCredentials y) => !(x == y);

        public int CompareTo(InputPaymentCredentials other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputPaymentCredentials x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPaymentCredentials x, InputPaymentCredentials y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputPaymentCredentials x, InputPaymentCredentials y) => x.CompareTo(y) < 0;
        public static bool operator >(InputPaymentCredentials x, InputPaymentCredentials y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputPaymentCredentials x, InputPaymentCredentials y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputPaymentCredentials.{_tag.GetType().Name}{_tag}";
    }
}