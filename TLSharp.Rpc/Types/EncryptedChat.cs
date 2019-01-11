using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class EncryptedChat : ITlType, IEquatable<EncryptedChat>, IComparable<EncryptedChat>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0xab7ec0a0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Id;
            
            public EmptyTag(
                int id
            ) {
                Id = id;
            }
            
            int CmpTuple =>
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
                Write(Id, bw, WriteInt);
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                return new EmptyTag(id);
            }
        }

        public sealed class WaitingTag : ITlTypeTag, IEquatable<WaitingTag>, IComparable<WaitingTag>, IComparable
        {
            internal const uint TypeNumber = 0x3bf703dc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Id;
            public readonly long AccessHash;
            public readonly int Date;
            public readonly int AdminId;
            public readonly int ParticipantId;
            
            public WaitingTag(
                int id,
                long accessHash,
                int date,
                int adminId,
                int participantId
            ) {
                Id = id;
                AccessHash = accessHash;
                Date = date;
                AdminId = adminId;
                ParticipantId = participantId;
            }
            
            (int, long, int, int, int) CmpTuple =>
                (Id, AccessHash, Date, AdminId, ParticipantId);

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

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash}, Date: {Date}, AdminId: {AdminId}, ParticipantId: {ParticipantId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
                Write(AccessHash, bw, WriteLong);
                Write(Date, bw, WriteInt);
                Write(AdminId, bw, WriteInt);
                Write(ParticipantId, bw, WriteInt);
            }
            
            internal static WaitingTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                var accessHash = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                var adminId = Read(br, ReadInt);
                var participantId = Read(br, ReadInt);
                return new WaitingTag(id, accessHash, date, adminId, participantId);
            }
        }

        public sealed class RequestedTag : ITlTypeTag, IEquatable<RequestedTag>, IComparable<RequestedTag>, IComparable
        {
            internal const uint TypeNumber = 0xc878527e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Id;
            public readonly long AccessHash;
            public readonly int Date;
            public readonly int AdminId;
            public readonly int ParticipantId;
            public readonly Arr<byte> Ga;
            
            public RequestedTag(
                int id,
                long accessHash,
                int date,
                int adminId,
                int participantId,
                Some<Arr<byte>> ga
            ) {
                Id = id;
                AccessHash = accessHash;
                Date = date;
                AdminId = adminId;
                ParticipantId = participantId;
                Ga = ga;
            }
            
            (int, long, int, int, int, Arr<byte>) CmpTuple =>
                (Id, AccessHash, Date, AdminId, ParticipantId, Ga);

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

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash}, Date: {Date}, AdminId: {AdminId}, ParticipantId: {ParticipantId}, Ga: {Ga})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
                Write(AccessHash, bw, WriteLong);
                Write(Date, bw, WriteInt);
                Write(AdminId, bw, WriteInt);
                Write(ParticipantId, bw, WriteInt);
                Write(Ga, bw, WriteBytes);
            }
            
            internal static RequestedTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                var accessHash = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                var adminId = Read(br, ReadInt);
                var participantId = Read(br, ReadInt);
                var ga = Read(br, ReadBytes);
                return new RequestedTag(id, accessHash, date, adminId, participantId, ga);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xfa56ce36;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Id;
            public readonly long AccessHash;
            public readonly int Date;
            public readonly int AdminId;
            public readonly int ParticipantId;
            public readonly Arr<byte> GaOrB;
            public readonly long KeyFingerprint;
            
            public Tag(
                int id,
                long accessHash,
                int date,
                int adminId,
                int participantId,
                Some<Arr<byte>> gaOrB,
                long keyFingerprint
            ) {
                Id = id;
                AccessHash = accessHash;
                Date = date;
                AdminId = adminId;
                ParticipantId = participantId;
                GaOrB = gaOrB;
                KeyFingerprint = keyFingerprint;
            }
            
            (int, long, int, int, int, Arr<byte>, long) CmpTuple =>
                (Id, AccessHash, Date, AdminId, ParticipantId, GaOrB, KeyFingerprint);

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

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash}, Date: {Date}, AdminId: {AdminId}, ParticipantId: {ParticipantId}, GaOrB: {GaOrB}, KeyFingerprint: {KeyFingerprint})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
                Write(AccessHash, bw, WriteLong);
                Write(Date, bw, WriteInt);
                Write(AdminId, bw, WriteInt);
                Write(ParticipantId, bw, WriteInt);
                Write(GaOrB, bw, WriteBytes);
                Write(KeyFingerprint, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                var accessHash = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                var adminId = Read(br, ReadInt);
                var participantId = Read(br, ReadInt);
                var gaOrB = Read(br, ReadBytes);
                var keyFingerprint = Read(br, ReadLong);
                return new Tag(id, accessHash, date, adminId, participantId, gaOrB, keyFingerprint);
            }
        }

        public sealed class DiscardedTag : ITlTypeTag, IEquatable<DiscardedTag>, IComparable<DiscardedTag>, IComparable
        {
            internal const uint TypeNumber = 0x13d6dd27;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Id;
            
            public DiscardedTag(
                int id
            ) {
                Id = id;
            }
            
            int CmpTuple =>
                Id;

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

            public override string ToString() => $"(Id: {Id})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
            }
            
            internal static DiscardedTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                return new DiscardedTag(id);
            }
        }

        readonly ITlTypeTag _tag;
        EncryptedChat(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator EncryptedChat(EmptyTag tag) => new EncryptedChat(tag);
        public static explicit operator EncryptedChat(WaitingTag tag) => new EncryptedChat(tag);
        public static explicit operator EncryptedChat(RequestedTag tag) => new EncryptedChat(tag);
        public static explicit operator EncryptedChat(Tag tag) => new EncryptedChat(tag);
        public static explicit operator EncryptedChat(DiscardedTag tag) => new EncryptedChat(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static EncryptedChat Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (EncryptedChat) EmptyTag.DeserializeTag(br);
                case WaitingTag.TypeNumber: return (EncryptedChat) WaitingTag.DeserializeTag(br);
                case RequestedTag.TypeNumber: return (EncryptedChat) RequestedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (EncryptedChat) Tag.DeserializeTag(br);
                case DiscardedTag.TypeNumber: return (EncryptedChat) DiscardedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, WaitingTag.TypeNumber, RequestedTag.TypeNumber, Tag.TypeNumber, DiscardedTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<WaitingTag, T> waitingTag = null,
            Func<RequestedTag, T> requestedTag = null,
            Func<Tag, T> tag = null,
            Func<DiscardedTag, T> discardedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case WaitingTag x when waitingTag != null: return waitingTag(x);
                case RequestedTag x when requestedTag != null: return requestedTag(x);
                case Tag x when tag != null: return tag(x);
                case DiscardedTag x when discardedTag != null: return discardedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<WaitingTag, T> waitingTag,
            Func<RequestedTag, T> requestedTag,
            Func<Tag, T> tag,
            Func<DiscardedTag, T> discardedTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            waitingTag ?? throw new ArgumentNullException(nameof(waitingTag)),
            requestedTag ?? throw new ArgumentNullException(nameof(requestedTag)),
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
                case Tag _: return 3;
                case DiscardedTag _: return 4;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(EncryptedChat other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is EncryptedChat x && Equals(x);
        public static bool operator ==(EncryptedChat x, EncryptedChat y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EncryptedChat x, EncryptedChat y) => !(x == y);

        public int CompareTo(EncryptedChat other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is EncryptedChat x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EncryptedChat x, EncryptedChat y) => x.CompareTo(y) <= 0;
        public static bool operator <(EncryptedChat x, EncryptedChat y) => x.CompareTo(y) < 0;
        public static bool operator >(EncryptedChat x, EncryptedChat y) => x.CompareTo(y) > 0;
        public static bool operator >=(EncryptedChat x, EncryptedChat y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"EncryptedChat.{_tag.GetType().Name}{_tag}";
    }
}