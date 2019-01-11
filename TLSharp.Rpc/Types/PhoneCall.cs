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
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x5366c915;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            
            public EmptyTag(
                long id
            ) {
                Id = id;
            }
            
            long CmpTuple =>
                Id;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id})";
            
            
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

        public sealed class WaitingTag : ITlTypeTag, IEquatable<WaitingTag>, IComparable<WaitingTag>, IComparable
        {
            internal const uint TypeNumber = 0x1b8f4ad1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly long AccessHash;
            public readonly int Date;
            public readonly int AdminId;
            public readonly int ParticipantId;
            public readonly T.PhoneCallProtocol Protocol;
            public readonly Option<int> ReceiveDate;
            
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
            
            (long, long, int, int, int, T.PhoneCallProtocol, Option<int>) CmpTuple =>
                (Id, AccessHash, Date, AdminId, ParticipantId, Protocol, ReceiveDate);

            public bool Equals(WaitingTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is WaitingTag x && Equals(x);
            public static bool operator ==(WaitingTag x, WaitingTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(WaitingTag x, WaitingTag y) => !(x == y);

            public int CompareTo(WaitingTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is WaitingTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(WaitingTag x, WaitingTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(WaitingTag x, WaitingTag y) => x.CompareTo(y) < 0;
            public static bool operator >(WaitingTag x, WaitingTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(WaitingTag x, WaitingTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash}, Date: {Date}, AdminId: {AdminId}, ParticipantId: {ParticipantId}, Protocol: {Protocol}, ReceiveDate: {ReceiveDate})";
            
            
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

        public sealed class RequestedTag : ITlTypeTag, IEquatable<RequestedTag>, IComparable<RequestedTag>, IComparable
        {
            internal const uint TypeNumber = 0x83761ce4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly long AccessHash;
            public readonly int Date;
            public readonly int AdminId;
            public readonly int ParticipantId;
            public readonly Arr<byte> GaHash;
            public readonly T.PhoneCallProtocol Protocol;
            
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
            
            (long, long, int, int, int, Arr<byte>, T.PhoneCallProtocol) CmpTuple =>
                (Id, AccessHash, Date, AdminId, ParticipantId, GaHash, Protocol);

            public bool Equals(RequestedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is RequestedTag x && Equals(x);
            public static bool operator ==(RequestedTag x, RequestedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RequestedTag x, RequestedTag y) => !(x == y);

            public int CompareTo(RequestedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is RequestedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RequestedTag x, RequestedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RequestedTag x, RequestedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RequestedTag x, RequestedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RequestedTag x, RequestedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash}, Date: {Date}, AdminId: {AdminId}, ParticipantId: {ParticipantId}, GaHash: {GaHash}, Protocol: {Protocol})";
            
            
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

        public sealed class AcceptedTag : ITlTypeTag, IEquatable<AcceptedTag>, IComparable<AcceptedTag>, IComparable
        {
            internal const uint TypeNumber = 0x6d003d3f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly long AccessHash;
            public readonly int Date;
            public readonly int AdminId;
            public readonly int ParticipantId;
            public readonly Arr<byte> Gb;
            public readonly T.PhoneCallProtocol Protocol;
            
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
            
            (long, long, int, int, int, Arr<byte>, T.PhoneCallProtocol) CmpTuple =>
                (Id, AccessHash, Date, AdminId, ParticipantId, Gb, Protocol);

            public bool Equals(AcceptedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AcceptedTag x && Equals(x);
            public static bool operator ==(AcceptedTag x, AcceptedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AcceptedTag x, AcceptedTag y) => !(x == y);

            public int CompareTo(AcceptedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AcceptedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AcceptedTag x, AcceptedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AcceptedTag x, AcceptedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AcceptedTag x, AcceptedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AcceptedTag x, AcceptedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash}, Date: {Date}, AdminId: {AdminId}, ParticipantId: {ParticipantId}, Gb: {Gb}, Protocol: {Protocol})";
            
            
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

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xffe6ab67;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly long AccessHash;
            public readonly int Date;
            public readonly int AdminId;
            public readonly int ParticipantId;
            public readonly Arr<byte> GaOrB;
            public readonly long KeyFingerprint;
            public readonly T.PhoneCallProtocol Protocol;
            public readonly T.PhoneConnection Connection;
            public readonly Arr<T.PhoneConnection> AlternativeConnections;
            public readonly int StartDate;
            
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
            
            (long, long, int, int, int, Arr<byte>, long, T.PhoneCallProtocol, T.PhoneConnection, Arr<T.PhoneConnection>, int) CmpTuple =>
                (Id, AccessHash, Date, AdminId, ParticipantId, GaOrB, KeyFingerprint, Protocol, Connection, AlternativeConnections, StartDate);

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

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash}, Date: {Date}, AdminId: {AdminId}, ParticipantId: {ParticipantId}, GaOrB: {GaOrB}, KeyFingerprint: {KeyFingerprint}, Protocol: {Protocol}, Connection: {Connection}, AlternativeConnections: {AlternativeConnections}, StartDate: {StartDate})";
            
            
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

        public sealed class DiscardedTag : ITlTypeTag, IEquatable<DiscardedTag>, IComparable<DiscardedTag>, IComparable
        {
            internal const uint TypeNumber = 0x50ca4de1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool NeedRating;
            public readonly bool NeedDebug;
            public readonly long Id;
            public readonly Option<T.PhoneCallDiscardReason> Reason;
            public readonly Option<int> Duration;
            
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
            
            (bool, bool, long, Option<T.PhoneCallDiscardReason>, Option<int>) CmpTuple =>
                (NeedRating, NeedDebug, Id, Reason, Duration);

            public bool Equals(DiscardedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DiscardedTag x && Equals(x);
            public static bool operator ==(DiscardedTag x, DiscardedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DiscardedTag x, DiscardedTag y) => !(x == y);

            public int CompareTo(DiscardedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DiscardedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DiscardedTag x, DiscardedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DiscardedTag x, DiscardedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DiscardedTag x, DiscardedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DiscardedTag x, DiscardedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(NeedRating: {NeedRating}, NeedDebug: {NeedDebug}, Id: {Id}, Reason: {Reason}, Duration: {Duration})";
            
            
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

        public bool Equals(PhoneCall other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is PhoneCall x && Equals(x);
        public static bool operator ==(PhoneCall x, PhoneCall y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PhoneCall x, PhoneCall y) => !(x == y);

        public int CompareTo(PhoneCall other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is PhoneCall x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PhoneCall x, PhoneCall y) => x.CompareTo(y) <= 0;
        public static bool operator <(PhoneCall x, PhoneCall y) => x.CompareTo(y) < 0;
        public static bool operator >(PhoneCall x, PhoneCall y) => x.CompareTo(y) > 0;
        public static bool operator >=(PhoneCall x, PhoneCall y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PhoneCall.{_tag.GetType().Name}{_tag}";
    }
}