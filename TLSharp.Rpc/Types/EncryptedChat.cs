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
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xab7ec0a0;
            
            public int Id { get; }
            
            public EmptyTag(
                int id
            ) {
                Id = id;
            }
            
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

        public sealed class WaitingTag : Record<WaitingTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3bf703dc;
            
            public int Id { get; }
            public long AccessHash { get; }
            public int Date { get; }
            public int AdminId { get; }
            public int ParticipantId { get; }
            
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

        public sealed class RequestedTag : Record<RequestedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xc878527e;
            
            public int Id { get; }
            public long AccessHash { get; }
            public int Date { get; }
            public int AdminId { get; }
            public int ParticipantId { get; }
            public Arr<byte> Ga { get; }
            
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

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfa56ce36;
            
            public int Id { get; }
            public long AccessHash { get; }
            public int Date { get; }
            public int AdminId { get; }
            public int ParticipantId { get; }
            public Arr<byte> GaOrB { get; }
            public long KeyFingerprint { get; }
            
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

        public sealed class DiscardedTag : Record<DiscardedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x13d6dd27;
            
            public int Id { get; }
            
            public DiscardedTag(
                int id
            ) {
                Id = id;
            }
            
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
                case 0xab7ec0a0: return (EncryptedChat) EmptyTag.DeserializeTag(br);
                case 0x3bf703dc: return (EncryptedChat) WaitingTag.DeserializeTag(br);
                case 0xc878527e: return (EncryptedChat) RequestedTag.DeserializeTag(br);
                case 0xfa56ce36: return (EncryptedChat) Tag.DeserializeTag(br);
                case 0x13d6dd27: return (EncryptedChat) DiscardedTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xab7ec0a0, 0x3bf703dc, 0xc878527e, 0xfa56ce36, 0x13d6dd27 });
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

        public bool Equals(EncryptedChat other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is EncryptedChat x && Equals(x);
        public static bool operator ==(EncryptedChat a, EncryptedChat b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(EncryptedChat a, EncryptedChat b) => !(a == b);

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

        public int CompareTo(EncryptedChat other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is EncryptedChat x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EncryptedChat a, EncryptedChat b) => a.CompareTo(b) <= 0;
        public static bool operator <(EncryptedChat a, EncryptedChat b) => a.CompareTo(b) < 0;
        public static bool operator >(EncryptedChat a, EncryptedChat b) => a.CompareTo(b) > 0;
        public static bool operator >=(EncryptedChat a, EncryptedChat b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}