using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PrivacyKey : ITlType, IEquatable<PrivacyKey>, IComparable<PrivacyKey>, IComparable
    {
        public sealed class StatusTimestampTag : Record<StatusTimestampTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xbc2eab30;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
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
            internal const uint TypeNumber = 0x500e6dfa;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
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
            internal const uint TypeNumber = 0x3d662b7b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
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
        PrivacyKey(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PrivacyKey(StatusTimestampTag tag) => new PrivacyKey(tag);
        public static explicit operator PrivacyKey(ChatInviteTag tag) => new PrivacyKey(tag);
        public static explicit operator PrivacyKey(PhoneCallTag tag) => new PrivacyKey(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PrivacyKey Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case StatusTimestampTag.TypeNumber: return (PrivacyKey) StatusTimestampTag.DeserializeTag(br);
                case ChatInviteTag.TypeNumber: return (PrivacyKey) ChatInviteTag.DeserializeTag(br);
                case PhoneCallTag.TypeNumber: return (PrivacyKey) PhoneCallTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { StatusTimestampTag.TypeNumber, ChatInviteTag.TypeNumber, PhoneCallTag.TypeNumber });
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

        public bool Equals(PrivacyKey other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PrivacyKey x && Equals(x);
        public static bool operator ==(PrivacyKey a, PrivacyKey b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PrivacyKey a, PrivacyKey b) => !(a == b);

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

        public int CompareTo(PrivacyKey other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PrivacyKey x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PrivacyKey a, PrivacyKey b) => a.CompareTo(b) <= 0;
        public static bool operator <(PrivacyKey a, PrivacyKey b) => a.CompareTo(b) < 0;
        public static bool operator >(PrivacyKey a, PrivacyKey b) => a.CompareTo(b) > 0;
        public static bool operator >=(PrivacyKey a, PrivacyKey b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}