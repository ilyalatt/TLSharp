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
        public sealed class StatusTimestampTag : ITlTypeTag, IEquatable<StatusTimestampTag>, IComparable<StatusTimestampTag>, IComparable
        {
            internal const uint TypeNumber = 0xbc2eab30;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public StatusTimestampTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(StatusTimestampTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is StatusTimestampTag x && Equals(x);
            public static bool operator ==(StatusTimestampTag x, StatusTimestampTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(StatusTimestampTag x, StatusTimestampTag y) => !(x == y);

            public int CompareTo(StatusTimestampTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is StatusTimestampTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(StatusTimestampTag x, StatusTimestampTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(StatusTimestampTag x, StatusTimestampTag y) => x.CompareTo(y) < 0;
            public static bool operator >(StatusTimestampTag x, StatusTimestampTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(StatusTimestampTag x, StatusTimestampTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static StatusTimestampTag DeserializeTag(BinaryReader br)
            {

                return new StatusTimestampTag();
            }
        }

        public sealed class ChatInviteTag : ITlTypeTag, IEquatable<ChatInviteTag>, IComparable<ChatInviteTag>, IComparable
        {
            internal const uint TypeNumber = 0x500e6dfa;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ChatInviteTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ChatInviteTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChatInviteTag x && Equals(x);
            public static bool operator ==(ChatInviteTag x, ChatInviteTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatInviteTag x, ChatInviteTag y) => !(x == y);

            public int CompareTo(ChatInviteTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChatInviteTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatInviteTag x, ChatInviteTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatInviteTag x, ChatInviteTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatInviteTag x, ChatInviteTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatInviteTag x, ChatInviteTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChatInviteTag DeserializeTag(BinaryReader br)
            {

                return new ChatInviteTag();
            }
        }

        public sealed class PhoneCallTag : ITlTypeTag, IEquatable<PhoneCallTag>, IComparable<PhoneCallTag>, IComparable
        {
            internal const uint TypeNumber = 0x3d662b7b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PhoneCallTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PhoneCallTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PhoneCallTag x && Equals(x);
            public static bool operator ==(PhoneCallTag x, PhoneCallTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PhoneCallTag x, PhoneCallTag y) => !(x == y);

            public int CompareTo(PhoneCallTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PhoneCallTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
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

        public bool Equals(PrivacyKey other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is PrivacyKey x && Equals(x);
        public static bool operator ==(PrivacyKey x, PrivacyKey y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PrivacyKey x, PrivacyKey y) => !(x == y);

        public int CompareTo(PrivacyKey other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PrivacyKey x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PrivacyKey x, PrivacyKey y) => x.CompareTo(y) <= 0;
        public static bool operator <(PrivacyKey x, PrivacyKey y) => x.CompareTo(y) < 0;
        public static bool operator >(PrivacyKey x, PrivacyKey y) => x.CompareTo(y) > 0;
        public static bool operator >=(PrivacyKey x, PrivacyKey y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PrivacyKey.{_tag.GetType().Name}{_tag}";
    }
}