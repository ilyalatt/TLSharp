using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class MessagesFilter : ITlType, IEquatable<MessagesFilter>, IComparable<MessagesFilter>, IComparable
    {
        public sealed class InputEmptyTag : Record<InputEmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x57e2f66c;
            

            
            public InputEmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputEmptyTag DeserializeTag(BinaryReader br)
            {

                return new InputEmptyTag();
            }
        }

        public sealed class InputPhotosTag : Record<InputPhotosTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9609a51c;
            

            
            public InputPhotosTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputPhotosTag DeserializeTag(BinaryReader br)
            {

                return new InputPhotosTag();
            }
        }

        public sealed class InputVideoTag : Record<InputVideoTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9fc00e65;
            

            
            public InputVideoTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputVideoTag DeserializeTag(BinaryReader br)
            {

                return new InputVideoTag();
            }
        }

        public sealed class InputPhotoVideoTag : Record<InputPhotoVideoTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x56e9f0e4;
            

            
            public InputPhotoVideoTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputPhotoVideoTag DeserializeTag(BinaryReader br)
            {

                return new InputPhotoVideoTag();
            }
        }

        public sealed class InputPhotoVideoDocumentsTag : Record<InputPhotoVideoDocumentsTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xd95e73bb;
            

            
            public InputPhotoVideoDocumentsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputPhotoVideoDocumentsTag DeserializeTag(BinaryReader br)
            {

                return new InputPhotoVideoDocumentsTag();
            }
        }

        public sealed class InputDocumentTag : Record<InputDocumentTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9eddf188;
            

            
            public InputDocumentTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputDocumentTag DeserializeTag(BinaryReader br)
            {

                return new InputDocumentTag();
            }
        }

        public sealed class InputUrlTag : Record<InputUrlTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x7ef0dd87;
            

            
            public InputUrlTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputUrlTag DeserializeTag(BinaryReader br)
            {

                return new InputUrlTag();
            }
        }

        public sealed class InputGifTag : Record<InputGifTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xffc86587;
            

            
            public InputGifTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputGifTag DeserializeTag(BinaryReader br)
            {

                return new InputGifTag();
            }
        }

        public sealed class InputVoiceTag : Record<InputVoiceTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x50f5c392;
            

            
            public InputVoiceTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputVoiceTag DeserializeTag(BinaryReader br)
            {

                return new InputVoiceTag();
            }
        }

        public sealed class InputMusicTag : Record<InputMusicTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3751b49e;
            

            
            public InputMusicTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputMusicTag DeserializeTag(BinaryReader br)
            {

                return new InputMusicTag();
            }
        }

        public sealed class InputChatPhotosTag : Record<InputChatPhotosTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3a20ecb8;
            

            
            public InputChatPhotosTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputChatPhotosTag DeserializeTag(BinaryReader br)
            {

                return new InputChatPhotosTag();
            }
        }

        public sealed class InputPhoneCallsTag : Record<InputPhoneCallsTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x80c99768;
            
            public bool Missed { get; }
            
            public InputPhoneCallsTag(
                bool missed
            ) {
                Missed = missed;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Missed), bw, WriteInt);
            }
            
            internal static InputPhoneCallsTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var missed = Read(br, ReadOption(flags, 0));
                return new InputPhoneCallsTag(missed);
            }
        }

        public sealed class InputRoundVoiceTag : Record<InputRoundVoiceTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x7a7c17a4;
            

            
            public InputRoundVoiceTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputRoundVoiceTag DeserializeTag(BinaryReader br)
            {

                return new InputRoundVoiceTag();
            }
        }

        public sealed class InputRoundVideoTag : Record<InputRoundVideoTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xb549da53;
            

            
            public InputRoundVideoTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputRoundVideoTag DeserializeTag(BinaryReader br)
            {

                return new InputRoundVideoTag();
            }
        }

        readonly ITlTypeTag _tag;
        MessagesFilter(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MessagesFilter(InputEmptyTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputPhotosTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputVideoTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputPhotoVideoTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputPhotoVideoDocumentsTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputDocumentTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputUrlTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputGifTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputVoiceTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputMusicTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputChatPhotosTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputPhoneCallsTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputRoundVoiceTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputRoundVideoTag tag) => new MessagesFilter(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static MessagesFilter Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x57e2f66c: return (MessagesFilter) InputEmptyTag.DeserializeTag(br);
                case 0x9609a51c: return (MessagesFilter) InputPhotosTag.DeserializeTag(br);
                case 0x9fc00e65: return (MessagesFilter) InputVideoTag.DeserializeTag(br);
                case 0x56e9f0e4: return (MessagesFilter) InputPhotoVideoTag.DeserializeTag(br);
                case 0xd95e73bb: return (MessagesFilter) InputPhotoVideoDocumentsTag.DeserializeTag(br);
                case 0x9eddf188: return (MessagesFilter) InputDocumentTag.DeserializeTag(br);
                case 0x7ef0dd87: return (MessagesFilter) InputUrlTag.DeserializeTag(br);
                case 0xffc86587: return (MessagesFilter) InputGifTag.DeserializeTag(br);
                case 0x50f5c392: return (MessagesFilter) InputVoiceTag.DeserializeTag(br);
                case 0x3751b49e: return (MessagesFilter) InputMusicTag.DeserializeTag(br);
                case 0x3a20ecb8: return (MessagesFilter) InputChatPhotosTag.DeserializeTag(br);
                case 0x80c99768: return (MessagesFilter) InputPhoneCallsTag.DeserializeTag(br);
                case 0x7a7c17a4: return (MessagesFilter) InputRoundVoiceTag.DeserializeTag(br);
                case 0xb549da53: return (MessagesFilter) InputRoundVideoTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x57e2f66c, 0x9609a51c, 0x9fc00e65, 0x56e9f0e4, 0xd95e73bb, 0x9eddf188, 0x7ef0dd87, 0xffc86587, 0x50f5c392, 0x3751b49e, 0x3a20ecb8, 0x80c99768, 0x7a7c17a4, 0xb549da53 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<InputEmptyTag, T> inputEmptyTag = null,
            Func<InputPhotosTag, T> inputPhotosTag = null,
            Func<InputVideoTag, T> inputVideoTag = null,
            Func<InputPhotoVideoTag, T> inputPhotoVideoTag = null,
            Func<InputPhotoVideoDocumentsTag, T> inputPhotoVideoDocumentsTag = null,
            Func<InputDocumentTag, T> inputDocumentTag = null,
            Func<InputUrlTag, T> inputUrlTag = null,
            Func<InputGifTag, T> inputGifTag = null,
            Func<InputVoiceTag, T> inputVoiceTag = null,
            Func<InputMusicTag, T> inputMusicTag = null,
            Func<InputChatPhotosTag, T> inputChatPhotosTag = null,
            Func<InputPhoneCallsTag, T> inputPhoneCallsTag = null,
            Func<InputRoundVoiceTag, T> inputRoundVoiceTag = null,
            Func<InputRoundVideoTag, T> inputRoundVideoTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case InputEmptyTag x when inputEmptyTag != null: return inputEmptyTag(x);
                case InputPhotosTag x when inputPhotosTag != null: return inputPhotosTag(x);
                case InputVideoTag x when inputVideoTag != null: return inputVideoTag(x);
                case InputPhotoVideoTag x when inputPhotoVideoTag != null: return inputPhotoVideoTag(x);
                case InputPhotoVideoDocumentsTag x when inputPhotoVideoDocumentsTag != null: return inputPhotoVideoDocumentsTag(x);
                case InputDocumentTag x when inputDocumentTag != null: return inputDocumentTag(x);
                case InputUrlTag x when inputUrlTag != null: return inputUrlTag(x);
                case InputGifTag x when inputGifTag != null: return inputGifTag(x);
                case InputVoiceTag x when inputVoiceTag != null: return inputVoiceTag(x);
                case InputMusicTag x when inputMusicTag != null: return inputMusicTag(x);
                case InputChatPhotosTag x when inputChatPhotosTag != null: return inputChatPhotosTag(x);
                case InputPhoneCallsTag x when inputPhoneCallsTag != null: return inputPhoneCallsTag(x);
                case InputRoundVoiceTag x when inputRoundVoiceTag != null: return inputRoundVoiceTag(x);
                case InputRoundVideoTag x when inputRoundVideoTag != null: return inputRoundVideoTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<InputEmptyTag, T> inputEmptyTag,
            Func<InputPhotosTag, T> inputPhotosTag,
            Func<InputVideoTag, T> inputVideoTag,
            Func<InputPhotoVideoTag, T> inputPhotoVideoTag,
            Func<InputPhotoVideoDocumentsTag, T> inputPhotoVideoDocumentsTag,
            Func<InputDocumentTag, T> inputDocumentTag,
            Func<InputUrlTag, T> inputUrlTag,
            Func<InputGifTag, T> inputGifTag,
            Func<InputVoiceTag, T> inputVoiceTag,
            Func<InputMusicTag, T> inputMusicTag,
            Func<InputChatPhotosTag, T> inputChatPhotosTag,
            Func<InputPhoneCallsTag, T> inputPhoneCallsTag,
            Func<InputRoundVoiceTag, T> inputRoundVoiceTag,
            Func<InputRoundVideoTag, T> inputRoundVideoTag
        ) => Match(
            () => throw new Exception("WTF"),
            inputEmptyTag ?? throw new ArgumentNullException(nameof(inputEmptyTag)),
            inputPhotosTag ?? throw new ArgumentNullException(nameof(inputPhotosTag)),
            inputVideoTag ?? throw new ArgumentNullException(nameof(inputVideoTag)),
            inputPhotoVideoTag ?? throw new ArgumentNullException(nameof(inputPhotoVideoTag)),
            inputPhotoVideoDocumentsTag ?? throw new ArgumentNullException(nameof(inputPhotoVideoDocumentsTag)),
            inputDocumentTag ?? throw new ArgumentNullException(nameof(inputDocumentTag)),
            inputUrlTag ?? throw new ArgumentNullException(nameof(inputUrlTag)),
            inputGifTag ?? throw new ArgumentNullException(nameof(inputGifTag)),
            inputVoiceTag ?? throw new ArgumentNullException(nameof(inputVoiceTag)),
            inputMusicTag ?? throw new ArgumentNullException(nameof(inputMusicTag)),
            inputChatPhotosTag ?? throw new ArgumentNullException(nameof(inputChatPhotosTag)),
            inputPhoneCallsTag ?? throw new ArgumentNullException(nameof(inputPhoneCallsTag)),
            inputRoundVoiceTag ?? throw new ArgumentNullException(nameof(inputRoundVoiceTag)),
            inputRoundVideoTag ?? throw new ArgumentNullException(nameof(inputRoundVideoTag))
        );

        public bool Equals(MessagesFilter other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is MessagesFilter x && Equals(x);
        public static bool operator ==(MessagesFilter a, MessagesFilter b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(MessagesFilter a, MessagesFilter b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case InputEmptyTag _: return 0;
                case InputPhotosTag _: return 1;
                case InputVideoTag _: return 2;
                case InputPhotoVideoTag _: return 3;
                case InputPhotoVideoDocumentsTag _: return 4;
                case InputDocumentTag _: return 5;
                case InputUrlTag _: return 6;
                case InputGifTag _: return 7;
                case InputVoiceTag _: return 8;
                case InputMusicTag _: return 9;
                case InputChatPhotosTag _: return 10;
                case InputPhoneCallsTag _: return 11;
                case InputRoundVoiceTag _: return 12;
                case InputRoundVideoTag _: return 13;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(MessagesFilter other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is MessagesFilter x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MessagesFilter a, MessagesFilter b) => a.CompareTo(b) <= 0;
        public static bool operator <(MessagesFilter a, MessagesFilter b) => a.CompareTo(b) < 0;
        public static bool operator >(MessagesFilter a, MessagesFilter b) => a.CompareTo(b) > 0;
        public static bool operator >=(MessagesFilter a, MessagesFilter b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}