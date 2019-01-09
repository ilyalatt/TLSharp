using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputPrivacyKey : ITlType, IEquatable<InputPrivacyKey>, IComparable<InputPrivacyKey>, IComparable
    {
        public sealed class StatusTimestampTag : Record<StatusTimestampTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x4f96cb18;
            

            
            public StatusTimestampTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static StatusTimestampTag DeserializeTag(BinaryReader br)
            {

                return new StatusTimestampTag();
            }
        }

        public sealed class ChatInviteTag : Record<ChatInviteTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xbdfb0426;
            

            
            public ChatInviteTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChatInviteTag DeserializeTag(BinaryReader br)
            {

                return new ChatInviteTag();
            }
        }

        public sealed class PhoneCallTag : Record<PhoneCallTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfabadc5f;
            

            
            public PhoneCallTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PhoneCallTag DeserializeTag(BinaryReader br)
            {

                return new PhoneCallTag();
            }
        }

        readonly ITlTypeTag _tag;
        InputPrivacyKey(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputPrivacyKey(StatusTimestampTag tag) => new InputPrivacyKey(tag);
        public static explicit operator InputPrivacyKey(ChatInviteTag tag) => new InputPrivacyKey(tag);
        public static explicit operator InputPrivacyKey(PhoneCallTag tag) => new InputPrivacyKey(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputPrivacyKey Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x4f96cb18: return (InputPrivacyKey) StatusTimestampTag.DeserializeTag(br);
                case 0xbdfb0426: return (InputPrivacyKey) ChatInviteTag.DeserializeTag(br);
                case 0xfabadc5f: return (InputPrivacyKey) PhoneCallTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x4f96cb18, 0xbdfb0426, 0xfabadc5f });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<StatusTimestampTag, T> statusTimestampTag = null,
            Func<ChatInviteTag, T> chatInviteTag = null,
            Func<PhoneCallTag, T> phoneCallTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case StatusTimestampTag x when statusTimestampTag != null: return statusTimestampTag(x);
                case ChatInviteTag x when chatInviteTag != null: return chatInviteTag(x);
                case PhoneCallTag x when phoneCallTag != null: return phoneCallTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<StatusTimestampTag, T> statusTimestampTag,
            Func<ChatInviteTag, T> chatInviteTag,
            Func<PhoneCallTag, T> phoneCallTag
        ) => Match(
            () => throw new Exception("WTF"),
            statusTimestampTag ?? throw new ArgumentNullException(nameof(statusTimestampTag)),
            chatInviteTag ?? throw new ArgumentNullException(nameof(chatInviteTag)),
            phoneCallTag ?? throw new ArgumentNullException(nameof(phoneCallTag))
        );

        public bool Equals(InputPrivacyKey other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputPrivacyKey x && Equals(x);
        public static bool operator ==(InputPrivacyKey a, InputPrivacyKey b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputPrivacyKey a, InputPrivacyKey b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case StatusTimestampTag _: return 0;
                case ChatInviteTag _: return 1;
                case PhoneCallTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputPrivacyKey other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputPrivacyKey x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPrivacyKey a, InputPrivacyKey b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputPrivacyKey a, InputPrivacyKey b) => a.CompareTo(b) < 0;
        public static bool operator >(InputPrivacyKey a, InputPrivacyKey b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputPrivacyKey a, InputPrivacyKey b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}