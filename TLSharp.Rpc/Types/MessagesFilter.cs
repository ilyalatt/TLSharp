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
        public sealed class InputEmptyTag : ITlTypeTag, IEquatable<InputEmptyTag>, IComparable<InputEmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x57e2f66c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputEmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputEmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputEmptyTag x && Equals(x);
            public static bool operator ==(InputEmptyTag x, InputEmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputEmptyTag x, InputEmptyTag y) => !(x == y);

            public int CompareTo(InputEmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputEmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputEmptyTag x, InputEmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputEmptyTag x, InputEmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputEmptyTag x, InputEmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputEmptyTag x, InputEmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputEmptyTag DeserializeTag(BinaryReader br)
            {

                return new InputEmptyTag();
            }
        }

        public sealed class InputPhotosTag : ITlTypeTag, IEquatable<InputPhotosTag>, IComparable<InputPhotosTag>, IComparable
        {
            internal const uint TypeNumber = 0x9609a51c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputPhotosTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputPhotosTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputPhotosTag x && Equals(x);
            public static bool operator ==(InputPhotosTag x, InputPhotosTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputPhotosTag x, InputPhotosTag y) => !(x == y);

            public int CompareTo(InputPhotosTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputPhotosTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputPhotosTag x, InputPhotosTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputPhotosTag x, InputPhotosTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputPhotosTag x, InputPhotosTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputPhotosTag x, InputPhotosTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputPhotosTag DeserializeTag(BinaryReader br)
            {

                return new InputPhotosTag();
            }
        }

        public sealed class InputVideoTag : ITlTypeTag, IEquatable<InputVideoTag>, IComparable<InputVideoTag>, IComparable
        {
            internal const uint TypeNumber = 0x9fc00e65;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputVideoTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputVideoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputVideoTag x && Equals(x);
            public static bool operator ==(InputVideoTag x, InputVideoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputVideoTag x, InputVideoTag y) => !(x == y);

            public int CompareTo(InputVideoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputVideoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputVideoTag x, InputVideoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputVideoTag x, InputVideoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputVideoTag x, InputVideoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputVideoTag x, InputVideoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputVideoTag DeserializeTag(BinaryReader br)
            {

                return new InputVideoTag();
            }
        }

        public sealed class InputPhotoVideoTag : ITlTypeTag, IEquatable<InputPhotoVideoTag>, IComparable<InputPhotoVideoTag>, IComparable
        {
            internal const uint TypeNumber = 0x56e9f0e4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputPhotoVideoTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputPhotoVideoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputPhotoVideoTag x && Equals(x);
            public static bool operator ==(InputPhotoVideoTag x, InputPhotoVideoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputPhotoVideoTag x, InputPhotoVideoTag y) => !(x == y);

            public int CompareTo(InputPhotoVideoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputPhotoVideoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputPhotoVideoTag x, InputPhotoVideoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputPhotoVideoTag x, InputPhotoVideoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputPhotoVideoTag x, InputPhotoVideoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputPhotoVideoTag x, InputPhotoVideoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputPhotoVideoTag DeserializeTag(BinaryReader br)
            {

                return new InputPhotoVideoTag();
            }
        }

        public sealed class InputDocumentTag : ITlTypeTag, IEquatable<InputDocumentTag>, IComparable<InputDocumentTag>, IComparable
        {
            internal const uint TypeNumber = 0x9eddf188;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputDocumentTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputDocumentTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputDocumentTag x && Equals(x);
            public static bool operator ==(InputDocumentTag x, InputDocumentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputDocumentTag x, InputDocumentTag y) => !(x == y);

            public int CompareTo(InputDocumentTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputDocumentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputDocumentTag x, InputDocumentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputDocumentTag x, InputDocumentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputDocumentTag x, InputDocumentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputDocumentTag x, InputDocumentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputDocumentTag DeserializeTag(BinaryReader br)
            {

                return new InputDocumentTag();
            }
        }

        public sealed class InputUrlTag : ITlTypeTag, IEquatable<InputUrlTag>, IComparable<InputUrlTag>, IComparable
        {
            internal const uint TypeNumber = 0x7ef0dd87;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputUrlTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputUrlTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputUrlTag x && Equals(x);
            public static bool operator ==(InputUrlTag x, InputUrlTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputUrlTag x, InputUrlTag y) => !(x == y);

            public int CompareTo(InputUrlTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputUrlTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputUrlTag x, InputUrlTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputUrlTag x, InputUrlTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputUrlTag x, InputUrlTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputUrlTag x, InputUrlTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputUrlTag DeserializeTag(BinaryReader br)
            {

                return new InputUrlTag();
            }
        }

        public sealed class InputGifTag : ITlTypeTag, IEquatable<InputGifTag>, IComparable<InputGifTag>, IComparable
        {
            internal const uint TypeNumber = 0xffc86587;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputGifTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputGifTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputGifTag x && Equals(x);
            public static bool operator ==(InputGifTag x, InputGifTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputGifTag x, InputGifTag y) => !(x == y);

            public int CompareTo(InputGifTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputGifTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputGifTag x, InputGifTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputGifTag x, InputGifTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputGifTag x, InputGifTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputGifTag x, InputGifTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputGifTag DeserializeTag(BinaryReader br)
            {

                return new InputGifTag();
            }
        }

        public sealed class InputVoiceTag : ITlTypeTag, IEquatable<InputVoiceTag>, IComparable<InputVoiceTag>, IComparable
        {
            internal const uint TypeNumber = 0x50f5c392;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputVoiceTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputVoiceTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputVoiceTag x && Equals(x);
            public static bool operator ==(InputVoiceTag x, InputVoiceTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputVoiceTag x, InputVoiceTag y) => !(x == y);

            public int CompareTo(InputVoiceTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputVoiceTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputVoiceTag x, InputVoiceTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputVoiceTag x, InputVoiceTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputVoiceTag x, InputVoiceTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputVoiceTag x, InputVoiceTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputVoiceTag DeserializeTag(BinaryReader br)
            {

                return new InputVoiceTag();
            }
        }

        public sealed class InputMusicTag : ITlTypeTag, IEquatable<InputMusicTag>, IComparable<InputMusicTag>, IComparable
        {
            internal const uint TypeNumber = 0x3751b49e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputMusicTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputMusicTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputMusicTag x && Equals(x);
            public static bool operator ==(InputMusicTag x, InputMusicTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputMusicTag x, InputMusicTag y) => !(x == y);

            public int CompareTo(InputMusicTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputMusicTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputMusicTag x, InputMusicTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputMusicTag x, InputMusicTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputMusicTag x, InputMusicTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputMusicTag x, InputMusicTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputMusicTag DeserializeTag(BinaryReader br)
            {

                return new InputMusicTag();
            }
        }

        public sealed class InputChatPhotosTag : ITlTypeTag, IEquatable<InputChatPhotosTag>, IComparable<InputChatPhotosTag>, IComparable
        {
            internal const uint TypeNumber = 0x3a20ecb8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputChatPhotosTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputChatPhotosTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputChatPhotosTag x && Equals(x);
            public static bool operator ==(InputChatPhotosTag x, InputChatPhotosTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputChatPhotosTag x, InputChatPhotosTag y) => !(x == y);

            public int CompareTo(InputChatPhotosTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputChatPhotosTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputChatPhotosTag x, InputChatPhotosTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputChatPhotosTag x, InputChatPhotosTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputChatPhotosTag x, InputChatPhotosTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputChatPhotosTag x, InputChatPhotosTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputChatPhotosTag DeserializeTag(BinaryReader br)
            {

                return new InputChatPhotosTag();
            }
        }

        public sealed class InputPhoneCallsTag : ITlTypeTag, IEquatable<InputPhoneCallsTag>, IComparable<InputPhoneCallsTag>, IComparable
        {
            internal const uint TypeNumber = 0x80c99768;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Missed;
            
            public InputPhoneCallsTag(
                bool missed
            ) {
                Missed = missed;
            }
            
            bool CmpTuple =>
                Missed;

            public bool Equals(InputPhoneCallsTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputPhoneCallsTag x && Equals(x);
            public static bool operator ==(InputPhoneCallsTag x, InputPhoneCallsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputPhoneCallsTag x, InputPhoneCallsTag y) => !(x == y);

            public int CompareTo(InputPhoneCallsTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputPhoneCallsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputPhoneCallsTag x, InputPhoneCallsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputPhoneCallsTag x, InputPhoneCallsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputPhoneCallsTag x, InputPhoneCallsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputPhoneCallsTag x, InputPhoneCallsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Missed: {Missed})";
            
            
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

        public sealed class InputRoundVoiceTag : ITlTypeTag, IEquatable<InputRoundVoiceTag>, IComparable<InputRoundVoiceTag>, IComparable
        {
            internal const uint TypeNumber = 0x7a7c17a4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputRoundVoiceTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputRoundVoiceTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputRoundVoiceTag x && Equals(x);
            public static bool operator ==(InputRoundVoiceTag x, InputRoundVoiceTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputRoundVoiceTag x, InputRoundVoiceTag y) => !(x == y);

            public int CompareTo(InputRoundVoiceTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputRoundVoiceTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputRoundVoiceTag x, InputRoundVoiceTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputRoundVoiceTag x, InputRoundVoiceTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputRoundVoiceTag x, InputRoundVoiceTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputRoundVoiceTag x, InputRoundVoiceTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputRoundVoiceTag DeserializeTag(BinaryReader br)
            {

                return new InputRoundVoiceTag();
            }
        }

        public sealed class InputRoundVideoTag : ITlTypeTag, IEquatable<InputRoundVideoTag>, IComparable<InputRoundVideoTag>, IComparable
        {
            internal const uint TypeNumber = 0xb549da53;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputRoundVideoTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputRoundVideoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputRoundVideoTag x && Equals(x);
            public static bool operator ==(InputRoundVideoTag x, InputRoundVideoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputRoundVideoTag x, InputRoundVideoTag y) => !(x == y);

            public int CompareTo(InputRoundVideoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputRoundVideoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputRoundVideoTag x, InputRoundVideoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputRoundVideoTag x, InputRoundVideoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputRoundVideoTag x, InputRoundVideoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputRoundVideoTag x, InputRoundVideoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputRoundVideoTag DeserializeTag(BinaryReader br)
            {

                return new InputRoundVideoTag();
            }
        }

        public sealed class InputMyMentionsTag : ITlTypeTag, IEquatable<InputMyMentionsTag>, IComparable<InputMyMentionsTag>, IComparable
        {
            internal const uint TypeNumber = 0xc1f8e69a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputMyMentionsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputMyMentionsTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputMyMentionsTag x && Equals(x);
            public static bool operator ==(InputMyMentionsTag x, InputMyMentionsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputMyMentionsTag x, InputMyMentionsTag y) => !(x == y);

            public int CompareTo(InputMyMentionsTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputMyMentionsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputMyMentionsTag x, InputMyMentionsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputMyMentionsTag x, InputMyMentionsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputMyMentionsTag x, InputMyMentionsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputMyMentionsTag x, InputMyMentionsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputMyMentionsTag DeserializeTag(BinaryReader br)
            {

                return new InputMyMentionsTag();
            }
        }

        public sealed class InputGeoTag : ITlTypeTag, IEquatable<InputGeoTag>, IComparable<InputGeoTag>, IComparable
        {
            internal const uint TypeNumber = 0xe7026d0d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputGeoTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputGeoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputGeoTag x && Equals(x);
            public static bool operator ==(InputGeoTag x, InputGeoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputGeoTag x, InputGeoTag y) => !(x == y);

            public int CompareTo(InputGeoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputGeoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputGeoTag x, InputGeoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputGeoTag x, InputGeoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputGeoTag x, InputGeoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputGeoTag x, InputGeoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputGeoTag DeserializeTag(BinaryReader br)
            {

                return new InputGeoTag();
            }
        }

        public sealed class InputContactsTag : ITlTypeTag, IEquatable<InputContactsTag>, IComparable<InputContactsTag>, IComparable
        {
            internal const uint TypeNumber = 0xe062db83;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InputContactsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InputContactsTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputContactsTag x && Equals(x);
            public static bool operator ==(InputContactsTag x, InputContactsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputContactsTag x, InputContactsTag y) => !(x == y);

            public int CompareTo(InputContactsTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputContactsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputContactsTag x, InputContactsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputContactsTag x, InputContactsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputContactsTag x, InputContactsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputContactsTag x, InputContactsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InputContactsTag DeserializeTag(BinaryReader br)
            {

                return new InputContactsTag();
            }
        }

        readonly ITlTypeTag _tag;
        MessagesFilter(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MessagesFilter(InputEmptyTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputPhotosTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputVideoTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputPhotoVideoTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputDocumentTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputUrlTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputGifTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputVoiceTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputMusicTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputChatPhotosTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputPhoneCallsTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputRoundVoiceTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputRoundVideoTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputMyMentionsTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputGeoTag tag) => new MessagesFilter(tag);
        public static explicit operator MessagesFilter(InputContactsTag tag) => new MessagesFilter(tag);

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
                case InputEmptyTag.TypeNumber: return (MessagesFilter) InputEmptyTag.DeserializeTag(br);
                case InputPhotosTag.TypeNumber: return (MessagesFilter) InputPhotosTag.DeserializeTag(br);
                case InputVideoTag.TypeNumber: return (MessagesFilter) InputVideoTag.DeserializeTag(br);
                case InputPhotoVideoTag.TypeNumber: return (MessagesFilter) InputPhotoVideoTag.DeserializeTag(br);
                case InputDocumentTag.TypeNumber: return (MessagesFilter) InputDocumentTag.DeserializeTag(br);
                case InputUrlTag.TypeNumber: return (MessagesFilter) InputUrlTag.DeserializeTag(br);
                case InputGifTag.TypeNumber: return (MessagesFilter) InputGifTag.DeserializeTag(br);
                case InputVoiceTag.TypeNumber: return (MessagesFilter) InputVoiceTag.DeserializeTag(br);
                case InputMusicTag.TypeNumber: return (MessagesFilter) InputMusicTag.DeserializeTag(br);
                case InputChatPhotosTag.TypeNumber: return (MessagesFilter) InputChatPhotosTag.DeserializeTag(br);
                case InputPhoneCallsTag.TypeNumber: return (MessagesFilter) InputPhoneCallsTag.DeserializeTag(br);
                case InputRoundVoiceTag.TypeNumber: return (MessagesFilter) InputRoundVoiceTag.DeserializeTag(br);
                case InputRoundVideoTag.TypeNumber: return (MessagesFilter) InputRoundVideoTag.DeserializeTag(br);
                case InputMyMentionsTag.TypeNumber: return (MessagesFilter) InputMyMentionsTag.DeserializeTag(br);
                case InputGeoTag.TypeNumber: return (MessagesFilter) InputGeoTag.DeserializeTag(br);
                case InputContactsTag.TypeNumber: return (MessagesFilter) InputContactsTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { InputEmptyTag.TypeNumber, InputPhotosTag.TypeNumber, InputVideoTag.TypeNumber, InputPhotoVideoTag.TypeNumber, InputDocumentTag.TypeNumber, InputUrlTag.TypeNumber, InputGifTag.TypeNumber, InputVoiceTag.TypeNumber, InputMusicTag.TypeNumber, InputChatPhotosTag.TypeNumber, InputPhoneCallsTag.TypeNumber, InputRoundVoiceTag.TypeNumber, InputRoundVideoTag.TypeNumber, InputMyMentionsTag.TypeNumber, InputGeoTag.TypeNumber, InputContactsTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<InputEmptyTag, T> inputEmptyTag = null,
            Func<InputPhotosTag, T> inputPhotosTag = null,
            Func<InputVideoTag, T> inputVideoTag = null,
            Func<InputPhotoVideoTag, T> inputPhotoVideoTag = null,
            Func<InputDocumentTag, T> inputDocumentTag = null,
            Func<InputUrlTag, T> inputUrlTag = null,
            Func<InputGifTag, T> inputGifTag = null,
            Func<InputVoiceTag, T> inputVoiceTag = null,
            Func<InputMusicTag, T> inputMusicTag = null,
            Func<InputChatPhotosTag, T> inputChatPhotosTag = null,
            Func<InputPhoneCallsTag, T> inputPhoneCallsTag = null,
            Func<InputRoundVoiceTag, T> inputRoundVoiceTag = null,
            Func<InputRoundVideoTag, T> inputRoundVideoTag = null,
            Func<InputMyMentionsTag, T> inputMyMentionsTag = null,
            Func<InputGeoTag, T> inputGeoTag = null,
            Func<InputContactsTag, T> inputContactsTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case InputEmptyTag x when inputEmptyTag != null: return inputEmptyTag(x);
                case InputPhotosTag x when inputPhotosTag != null: return inputPhotosTag(x);
                case InputVideoTag x when inputVideoTag != null: return inputVideoTag(x);
                case InputPhotoVideoTag x when inputPhotoVideoTag != null: return inputPhotoVideoTag(x);
                case InputDocumentTag x when inputDocumentTag != null: return inputDocumentTag(x);
                case InputUrlTag x when inputUrlTag != null: return inputUrlTag(x);
                case InputGifTag x when inputGifTag != null: return inputGifTag(x);
                case InputVoiceTag x when inputVoiceTag != null: return inputVoiceTag(x);
                case InputMusicTag x when inputMusicTag != null: return inputMusicTag(x);
                case InputChatPhotosTag x when inputChatPhotosTag != null: return inputChatPhotosTag(x);
                case InputPhoneCallsTag x when inputPhoneCallsTag != null: return inputPhoneCallsTag(x);
                case InputRoundVoiceTag x when inputRoundVoiceTag != null: return inputRoundVoiceTag(x);
                case InputRoundVideoTag x when inputRoundVideoTag != null: return inputRoundVideoTag(x);
                case InputMyMentionsTag x when inputMyMentionsTag != null: return inputMyMentionsTag(x);
                case InputGeoTag x when inputGeoTag != null: return inputGeoTag(x);
                case InputContactsTag x when inputContactsTag != null: return inputContactsTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<InputEmptyTag, T> inputEmptyTag,
            Func<InputPhotosTag, T> inputPhotosTag,
            Func<InputVideoTag, T> inputVideoTag,
            Func<InputPhotoVideoTag, T> inputPhotoVideoTag,
            Func<InputDocumentTag, T> inputDocumentTag,
            Func<InputUrlTag, T> inputUrlTag,
            Func<InputGifTag, T> inputGifTag,
            Func<InputVoiceTag, T> inputVoiceTag,
            Func<InputMusicTag, T> inputMusicTag,
            Func<InputChatPhotosTag, T> inputChatPhotosTag,
            Func<InputPhoneCallsTag, T> inputPhoneCallsTag,
            Func<InputRoundVoiceTag, T> inputRoundVoiceTag,
            Func<InputRoundVideoTag, T> inputRoundVideoTag,
            Func<InputMyMentionsTag, T> inputMyMentionsTag,
            Func<InputGeoTag, T> inputGeoTag,
            Func<InputContactsTag, T> inputContactsTag
        ) => Match(
            () => throw new Exception("WTF"),
            inputEmptyTag ?? throw new ArgumentNullException(nameof(inputEmptyTag)),
            inputPhotosTag ?? throw new ArgumentNullException(nameof(inputPhotosTag)),
            inputVideoTag ?? throw new ArgumentNullException(nameof(inputVideoTag)),
            inputPhotoVideoTag ?? throw new ArgumentNullException(nameof(inputPhotoVideoTag)),
            inputDocumentTag ?? throw new ArgumentNullException(nameof(inputDocumentTag)),
            inputUrlTag ?? throw new ArgumentNullException(nameof(inputUrlTag)),
            inputGifTag ?? throw new ArgumentNullException(nameof(inputGifTag)),
            inputVoiceTag ?? throw new ArgumentNullException(nameof(inputVoiceTag)),
            inputMusicTag ?? throw new ArgumentNullException(nameof(inputMusicTag)),
            inputChatPhotosTag ?? throw new ArgumentNullException(nameof(inputChatPhotosTag)),
            inputPhoneCallsTag ?? throw new ArgumentNullException(nameof(inputPhoneCallsTag)),
            inputRoundVoiceTag ?? throw new ArgumentNullException(nameof(inputRoundVoiceTag)),
            inputRoundVideoTag ?? throw new ArgumentNullException(nameof(inputRoundVideoTag)),
            inputMyMentionsTag ?? throw new ArgumentNullException(nameof(inputMyMentionsTag)),
            inputGeoTag ?? throw new ArgumentNullException(nameof(inputGeoTag)),
            inputContactsTag ?? throw new ArgumentNullException(nameof(inputContactsTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case InputEmptyTag _: return 0;
                case InputPhotosTag _: return 1;
                case InputVideoTag _: return 2;
                case InputPhotoVideoTag _: return 3;
                case InputDocumentTag _: return 4;
                case InputUrlTag _: return 5;
                case InputGifTag _: return 6;
                case InputVoiceTag _: return 7;
                case InputMusicTag _: return 8;
                case InputChatPhotosTag _: return 9;
                case InputPhoneCallsTag _: return 10;
                case InputRoundVoiceTag _: return 11;
                case InputRoundVideoTag _: return 12;
                case InputMyMentionsTag _: return 13;
                case InputGeoTag _: return 14;
                case InputContactsTag _: return 15;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(MessagesFilter other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is MessagesFilter x && Equals(x);
        public static bool operator ==(MessagesFilter x, MessagesFilter y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MessagesFilter x, MessagesFilter y) => !(x == y);

        public int CompareTo(MessagesFilter other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is MessagesFilter x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MessagesFilter x, MessagesFilter y) => x.CompareTo(y) <= 0;
        public static bool operator <(MessagesFilter x, MessagesFilter y) => x.CompareTo(y) < 0;
        public static bool operator >(MessagesFilter x, MessagesFilter y) => x.CompareTo(y) > 0;
        public static bool operator >=(MessagesFilter x, MessagesFilter y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"MessagesFilter.{_tag.GetType().Name}{_tag}";
    }
}