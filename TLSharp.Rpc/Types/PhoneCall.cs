using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PhoneCall : ITlType, IEquatable<PhoneCall>, IComparable<PhoneCall>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x5366c915;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            
            public EmptyTag(
                long id
            ) {
                Id = id;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                return new EmptyTag(id);
            }
        }

        public sealed class WaitingTag : Record<WaitingTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x1b8f4ad1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public long AccessHash { get; }
            public int Date { get; }
            public int AdminId { get; }
            public int ParticipantId { get; }
            public T.PhoneCallProtocol Protocol { get; }
            public Option<int> ReceiveDate { get; }
            
            public WaitingTag(
                long id,
                long accessHash,
                int date,
                int adminId,
                int participantId,
                Some<T.PhoneCallProtocol> protocol,
                Option<int> receiveDate
            ) {
                Id = id;
                AccessHash = accessHash;
                Date = date;
                AdminId = adminId;
                ParticipantId = participantId;
                Protocol = protocol;
                ReceiveDate = receiveDate;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, ReceiveDate), bw, WriteInt);
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(Date, bw, WriteInt);
                Write(AdminId, bw, WriteInt);
                Write(ParticipantId, bw, WriteInt);
                Write(Protocol, bw, WriteSerializable);
                Write(ReceiveDate, bw, WriteOption<int>(WriteInt));
            }
            
            internal static WaitingTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                var adminId = Read(br, ReadInt);
                var participantId = Read(br, ReadInt);
                var protocol = Read(br, T.PhoneCallProtocol.Deserialize);
                var receiveDate = Read(br, ReadOption(flags, 0, ReadInt));
                return new WaitingTag(id, accessHash, date, adminId, participantId, protocol, receiveDate);
            }
        }

        public sealed class RequestedTag : Record<RequestedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x83761ce4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public long AccessHash { get; }
            public int Date { get; }
            public int AdminId { get; }
            public int ParticipantId { get; }
            public Arr<byte> GaHash { get; }
            public T.PhoneCallProtocol Protocol { get; }
            
            public RequestedTag(
                long id,
                long accessHash,
                int date,
                int adminId,
                int participantId,
                Some<Arr<byte>> gaHash,
                Some<T.PhoneCallProtocol> protocol
            ) {
                Id = id;
                AccessHash = accessHash;
                Date = date;
                AdminId = adminId;
                ParticipantId = participantId;
                GaHash = gaHash;
                Protocol = protocol;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(Date, bw, WriteInt);
                Write(AdminId, bw, WriteInt);
                Write(ParticipantId, bw, WriteInt);
                Write(GaHash, bw, WriteBytes);
                Write(Protocol, bw, WriteSerializable);
            }
            
            internal static RequestedTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                var adminId = Read(br, ReadInt);
                var participantId = Read(br, ReadInt);
                var gaHash = Read(br, ReadBytes);
                var protocol = Read(br, T.PhoneCallProtocol.Deserialize);
                return new RequestedTag(id, accessHash, date, adminId, participantId, gaHash, protocol);
            }
        }

        public sealed class AcceptedTag : Record<AcceptedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x6d003d3f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public long AccessHash { get; }
            public int Date { get; }
            public int AdminId { get; }
            public int ParticipantId { get; }
            public Arr<byte> Gb { get; }
            public T.PhoneCallProtocol Protocol { get; }
            
            public AcceptedTag(
                long id,
                long accessHash,
                int date,
                int adminId,
                int participantId,
                Some<Arr<byte>> gb,
                Some<T.PhoneCallProtocol> protocol
            ) {
                Id = id;
                AccessHash = accessHash;
                Date = date;
                AdminId = adminId;
                ParticipantId = participantId;
                Gb = gb;
                Protocol = protocol;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(Date, bw, WriteInt);
                Write(AdminId, bw, WriteInt);
                Write(ParticipantId, bw, WriteInt);
                Write(Gb, bw, WriteBytes);
                Write(Protocol, bw, WriteSerializable);
            }
            
            internal static AcceptedTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                var adminId = Read(br, ReadInt);
                var participantId = Read(br, ReadInt);
                var gb = Read(br, ReadBytes);
                var protocol = Read(br, T.PhoneCallProtocol.Deserialize);
                return new AcceptedTag(id, accessHash, date, adminId, participantId, gb, protocol);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xffe6ab67;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public long AccessHash { get; }
            public int Date { get; }
            public int AdminId { get; }
            public int ParticipantId { get; }
            public Arr<byte> GaOrB { get; }
            public long KeyFingerprint { get; }
            public T.PhoneCallProtocol Protocol { get; }
            public T.PhoneConnection Connection { get; }
            public Arr<T.PhoneConnection> AlternativeConnections { get; }
            public int StartDate { get; }
            
            public Tag(
                long id,
                long accessHash,
                int date,
                int adminId,
                int participantId,
                Some<Arr<byte>> gaOrB,
                long keyFingerprint,
                Some<T.PhoneCallProtocol> protocol,
                Some<T.PhoneConnection> connection,
                Some<Arr<T.PhoneConnection>> alternativeConnections,
                int startDate
            ) {
                Id = id;
                AccessHash = accessHash;
                Date = date;
                AdminId = adminId;
                ParticipantId = participantId;
                GaOrB = gaOrB;
                KeyFingerprint = keyFingerprint;
                Protocol = protocol;
                Connection = connection;
                AlternativeConnections = alternativeConnections;
                StartDate = startDate;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(Date, bw, WriteInt);
                Write(AdminId, bw, WriteInt);
                Write(ParticipantId, bw, WriteInt);
                Write(GaOrB, bw, WriteBytes);
                Write(KeyFingerprint, bw, WriteLong);
                Write(Protocol, bw, WriteSerializable);
                Write(Connection, bw, WriteSerializable);
                Write(AlternativeConnections, bw, WriteVector<T.PhoneConnection>(WriteSerializable));
                Write(StartDate, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                var adminId = Read(br, ReadInt);
                var participantId = Read(br, ReadInt);
                var gaOrB = Read(br, ReadBytes);
                var keyFingerprint = Read(br, ReadLong);
                var protocol = Read(br, T.PhoneCallProtocol.Deserialize);
                var connection = Read(br, T.PhoneConnection.Deserialize);
                var alternativeConnections = Read(br, ReadVector(T.PhoneConnection.Deserialize));
                var startDate = Read(br, ReadInt);
                return new Tag(id, accessHash, date, adminId, participantId, gaOrB, keyFingerprint, protocol, connection, alternativeConnections, startDate);
            }
        }

        public sealed class DiscardedTag : Record<DiscardedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x50ca4de1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool NeedRating { get; }
            public bool NeedDebug { get; }
            public long Id { get; }
            public Option<T.PhoneCallDiscardReason> Reason { get; }
            public Option<int> Duration { get; }
            
            public DiscardedTag(
                bool needRating,
                bool needDebug,
                long id,
                Option<T.PhoneCallDiscardReason> reason,
                Option<int> duration
            ) {
                NeedRating = needRating;
                NeedDebug = needDebug;
                Id = id;
                Reason = reason;
                Duration = duration;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(2, NeedRating) | MaskBit(3, NeedDebug) | MaskBit(0, Reason) | MaskBit(1, Duration), bw, WriteInt);
                Write(Id, bw, WriteLong);
                Write(Reason, bw, WriteOption<T.PhoneCallDiscardReason>(WriteSerializable));
                Write(Duration, bw, WriteOption<int>(WriteInt));
            }
            
            internal static DiscardedTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var needRating = Read(br, ReadOption(flags, 2));
                var needDebug = Read(br, ReadOption(flags, 3));
                var id = Read(br, ReadLong);
                var reason = Read(br, ReadOption(flags, 0, T.PhoneCallDiscardReason.Deserialize));
                var duration = Read(br, ReadOption(flags, 1, ReadInt));
                return new DiscardedTag(needRating, needDebug, id, reason, duration);
            }
        }

        readonly ITlTypeTag _tag;
        PhoneCall(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PhoneCall(EmptyTag tag) => new PhoneCall(tag);
        public static explicit operator PhoneCall(WaitingTag tag) => new PhoneCall(tag);
        public static explicit operator PhoneCall(RequestedTag tag) => new PhoneCall(tag);
        public static explicit operator PhoneCall(AcceptedTag tag) => new PhoneCall(tag);
        public static explicit operator PhoneCall(Tag tag) => new PhoneCall(tag);
        public static explicit operator PhoneCall(DiscardedTag tag) => new PhoneCall(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PhoneCall Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (PhoneCall) EmptyTag.DeserializeTag(br);
                case WaitingTag.TypeNumber: return (PhoneCall) WaitingTag.DeserializeTag(br);
                case RequestedTag.TypeNumber: return (PhoneCall) RequestedTag.DeserializeTag(br);
                case AcceptedTag.TypeNumber: return (PhoneCall) AcceptedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (PhoneCall) Tag.DeserializeTag(br);
                case DiscardedTag.TypeNumber: return (PhoneCall) DiscardedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, WaitingTag.TypeNumber, RequestedTag.TypeNumber, AcceptedTag.TypeNumber, Tag.TypeNumber, DiscardedTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<WaitingTag, T> waitingTag = null,
            Func<RequestedTag, T> requestedTag = null,
            Func<AcceptedTag, T> acceptedTag = null,
            Func<Tag, T> tag = null,
            Func<DiscardedTag, T> discardedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case WaitingTag x when waitingTag != null: return waitingTag(x);
                case RequestedTag x when requestedTag != null: return requestedTag(x);
                case AcceptedTag x when acceptedTag != null: return acceptedTag(x);
                case Tag x when tag != null: return tag(x);
                case DiscardedTag x when discardedTag != null: return discardedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<WaitingTag, T> waitingTag,
            Func<RequestedTag, T> requestedTag,
            Func<AcceptedTag, T> acceptedTag,
            Func<Tag, T> tag,
            Func<DiscardedTag, T> discardedTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            waitingTag ?? throw new ArgumentNullException(nameof(waitingTag)),
            requestedTag ?? throw new ArgumentNullException(nameof(requestedTag)),
            acceptedTag ?? throw new ArgumentNullException(nameof(acceptedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            discardedTag ?? throw new ArgumentNullException(nameof(discardedTag))
        );

        public bool Equals(PhoneCall other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PhoneCall x && Equals(x);
        public static bool operator ==(PhoneCall a, PhoneCall b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PhoneCall a, PhoneCall b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case WaitingTag _: return 1;
                case RequestedTag _: return 2;
                case AcceptedTag _: return 3;
                case Tag _: return 4;
                case DiscardedTag _: return 5;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PhoneCall other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PhoneCall x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PhoneCall a, PhoneCall b) => a.CompareTo(b) <= 0;
        public static bool operator <(PhoneCall a, PhoneCall b) => a.CompareTo(b) < 0;
        public static bool operator >(PhoneCall a, PhoneCall b) => a.CompareTo(b) > 0;
        public static bool operator >=(PhoneCall a, PhoneCall b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}