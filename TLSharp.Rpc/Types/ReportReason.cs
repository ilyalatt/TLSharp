using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ReportReason : ITlType, IEquatable<ReportReason>, IComparable<ReportReason>, IComparable
    {
        public sealed class InputSpamTag : ITlTypeTag, IEquatable<InputSpamTag>, IComparable<InputSpamTag>, IComparable
        {
            internal const uint TypeNumber = 0x58dbcab8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputSpamTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputSpamTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputSpamTag x && Equals(x);
            public static bool operator ==(InputSpamTag x, InputSpamTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputSpamTag x, InputSpamTag y) => !(x == y);

            public int CompareTo(InputSpamTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputSpamTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputSpamTag x, InputSpamTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputSpamTag x, InputSpamTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputSpamTag x, InputSpamTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputSpamTag x, InputSpamTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputSpamTag DeserializeTag(BinaryReader br)
            {

                return new InputSpamTag();
            }
        }

        public sealed class InputViolenceTag : ITlTypeTag, IEquatable<InputViolenceTag>, IComparable<InputViolenceTag>, IComparable
        {
            internal const uint TypeNumber = 0x1e22c78d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputViolenceTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputViolenceTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputViolenceTag x && Equals(x);
            public static bool operator ==(InputViolenceTag x, InputViolenceTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputViolenceTag x, InputViolenceTag y) => !(x == y);

            public int CompareTo(InputViolenceTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputViolenceTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputViolenceTag x, InputViolenceTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputViolenceTag x, InputViolenceTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputViolenceTag x, InputViolenceTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputViolenceTag x, InputViolenceTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputViolenceTag DeserializeTag(BinaryReader br)
            {

                return new InputViolenceTag();
            }
        }

        public sealed class InputPornographyTag : ITlTypeTag, IEquatable<InputPornographyTag>, IComparable<InputPornographyTag>, IComparable
        {
            internal const uint TypeNumber = 0x2e59d922;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputPornographyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputPornographyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputPornographyTag x && Equals(x);
            public static bool operator ==(InputPornographyTag x, InputPornographyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputPornographyTag x, InputPornographyTag y) => !(x == y);

            public int CompareTo(InputPornographyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputPornographyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputPornographyTag x, InputPornographyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputPornographyTag x, InputPornographyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputPornographyTag x, InputPornographyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputPornographyTag x, InputPornographyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputPornographyTag DeserializeTag(BinaryReader br)
            {

                return new InputPornographyTag();
            }
        }

        public sealed class InputOtherTag : ITlTypeTag, IEquatable<InputOtherTag>, IComparable<InputOtherTag>, IComparable
        {
            internal const uint TypeNumber = 0xe1746d0a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Text;
            
            public InputOtherTag(
                Some<string> text
            ) {
                Text = text;
            }
            
            string CmpTuple =>
                Text;

            public bool Equals(InputOtherTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputOtherTag x && Equals(x);
            public static bool operator ==(InputOtherTag x, InputOtherTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputOtherTag x, InputOtherTag y) => !(x == y);

            public int CompareTo(InputOtherTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputOtherTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputOtherTag x, InputOtherTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputOtherTag x, InputOtherTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputOtherTag x, InputOtherTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputOtherTag x, InputOtherTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteString);
            }
            
            internal static InputOtherTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, ReadString);
                return new InputOtherTag(text);
            }
        }

        readonly ITlTypeTag _tag;
        ReportReason(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ReportReason(InputSpamTag tag) => new ReportReason(tag);
        public static explicit operator ReportReason(InputViolenceTag tag) => new ReportReason(tag);
        public static explicit operator ReportReason(InputPornographyTag tag) => new ReportReason(tag);
        public static explicit operator ReportReason(InputOtherTag tag) => new ReportReason(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ReportReason Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case InputSpamTag.TypeNumber: return (ReportReason) InputSpamTag.DeserializeTag(br);
                case InputViolenceTag.TypeNumber: return (ReportReason) InputViolenceTag.DeserializeTag(br);
                case InputPornographyTag.TypeNumber: return (ReportReason) InputPornographyTag.DeserializeTag(br);
                case InputOtherTag.TypeNumber: return (ReportReason) InputOtherTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { InputSpamTag.TypeNumber, InputViolenceTag.TypeNumber, InputPornographyTag.TypeNumber, InputOtherTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<InputSpamTag, T> inputSpamTag = null,
            Func<InputViolenceTag, T> inputViolenceTag = null,
            Func<InputPornographyTag, T> inputPornographyTag = null,
            Func<InputOtherTag, T> inputOtherTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case InputSpamTag x when inputSpamTag != null: return inputSpamTag(x);
                case InputViolenceTag x when inputViolenceTag != null: return inputViolenceTag(x);
                case InputPornographyTag x when inputPornographyTag != null: return inputPornographyTag(x);
                case InputOtherTag x when inputOtherTag != null: return inputOtherTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<InputSpamTag, T> inputSpamTag,
            Func<InputViolenceTag, T> inputViolenceTag,
            Func<InputPornographyTag, T> inputPornographyTag,
            Func<InputOtherTag, T> inputOtherTag
        ) => Match(
            () => throw new Exception("WTF"),
            inputSpamTag ?? throw new ArgumentNullException(nameof(inputSpamTag)),
            inputViolenceTag ?? throw new ArgumentNullException(nameof(inputViolenceTag)),
            inputPornographyTag ?? throw new ArgumentNullException(nameof(inputPornographyTag)),
            inputOtherTag ?? throw new ArgumentNullException(nameof(inputOtherTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case InputSpamTag _: return 0;
                case InputViolenceTag _: return 1;
                case InputPornographyTag _: return 2;
                case InputOtherTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ReportReason other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ReportReason x && Equals(x);
        public static bool operator ==(ReportReason x, ReportReason y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReportReason x, ReportReason y) => !(x == y);

        public int CompareTo(ReportReason other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ReportReason x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReportReason x, ReportReason y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReportReason x, ReportReason y) => x.CompareTo(y) < 0;
        public static bool operator >(ReportReason x, ReportReason y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReportReason x, ReportReason y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ReportReason.{_tag.GetType().Name}{_tag}";
    }
}