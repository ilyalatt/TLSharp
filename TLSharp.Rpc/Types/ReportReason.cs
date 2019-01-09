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
        public sealed class InputSpamTag : Record<InputSpamTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x58dbcab8;
            

            
            public InputSpamTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputSpamTag DeserializeTag(BinaryReader br)
            {

                return new InputSpamTag();
            }
        }

        public sealed class InputViolenceTag : Record<InputViolenceTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x1e22c78d;
            

            
            public InputViolenceTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputViolenceTag DeserializeTag(BinaryReader br)
            {

                return new InputViolenceTag();
            }
        }

        public sealed class InputPornographyTag : Record<InputPornographyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x2e59d922;
            

            
            public InputPornographyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputPornographyTag DeserializeTag(BinaryReader br)
            {

                return new InputPornographyTag();
            }
        }

        public sealed class InputOtherTag : Record<InputOtherTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xe1746d0a;
            
            public string Text { get; }
            
            public InputOtherTag(
                Some<string> text
            ) {
                Text = text;
            }
            
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
                case 0x58dbcab8: return (ReportReason) InputSpamTag.DeserializeTag(br);
                case 0x1e22c78d: return (ReportReason) InputViolenceTag.DeserializeTag(br);
                case 0x2e59d922: return (ReportReason) InputPornographyTag.DeserializeTag(br);
                case 0xe1746d0a: return (ReportReason) InputOtherTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x58dbcab8, 0x1e22c78d, 0x2e59d922, 0xe1746d0a });
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

        public bool Equals(ReportReason other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ReportReason x && Equals(x);
        public static bool operator ==(ReportReason a, ReportReason b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ReportReason a, ReportReason b) => !(a == b);

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

        public int CompareTo(ReportReason other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReportReason x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReportReason a, ReportReason b) => a.CompareTo(b) <= 0;
        public static bool operator <(ReportReason a, ReportReason b) => a.CompareTo(b) < 0;
        public static bool operator >(ReportReason a, ReportReason b) => a.CompareTo(b) > 0;
        public static bool operator >=(ReportReason a, ReportReason b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}