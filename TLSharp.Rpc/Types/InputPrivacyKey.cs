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
        public sealed class StatusTimestampTag : ITlTypeTag, IEquatable<StatusTimestampTag>, IComparable<StatusTimestampTag>, IComparable
        {
            internal const uint TypeNumber = 0x4f96cb18;
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
            internal const uint TypeNumber = 0xbdfb0426;
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
            internal const uint TypeNumber = 0xfabadc5f;
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
                case StatusTimestampTag.TypeNumber: return (InputPrivacyKey) StatusTimestampTag.DeserializeTag(br);
                case ChatInviteTag.TypeNumber: return (InputPrivacyKey) ChatInviteTag.DeserializeTag(br);
                case PhoneCallTag.TypeNumber: return (InputPrivacyKey) PhoneCallTag.DeserializeTag(br);
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

        public bool Equals(InputPrivacyKey other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is InputPrivacyKey x && Equals(x);
        public static bool operator ==(InputPrivacyKey x, InputPrivacyKey y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputPrivacyKey x, InputPrivacyKey y) => !(x == y);

        public int CompareTo(InputPrivacyKey other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputPrivacyKey x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPrivacyKey x, InputPrivacyKey y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputPrivacyKey x, InputPrivacyKey y) => x.CompareTo(y) < 0;
        public static bool operator >(InputPrivacyKey x, InputPrivacyKey y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputPrivacyKey x, InputPrivacyKey y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputPrivacyKey.{_tag.GetType().Name}{_tag}";
    }
}