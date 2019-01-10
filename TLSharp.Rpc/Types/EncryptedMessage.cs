using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class EncryptedMessage : ITlType, IEquatable<EncryptedMessage>, IComparable<EncryptedMessage>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xed18c118;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long RandomId { get; }
            public int ChatId { get; }
            public int Date { get; }
            public Arr<byte> Bytes { get; }
            public T.EncryptedFile File { get; }
            
            public Tag(
                long randomId,
                int chatId,
                int date,
                Some<Arr<byte>> bytes,
                Some<T.EncryptedFile> file
            ) {
                RandomId = randomId;
                ChatId = chatId;
                Date = date;
                Bytes = bytes;
                File = file;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(RandomId, bw, WriteLong);
                Write(ChatId, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(Bytes, bw, WriteBytes);
                Write(File, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var randomId = Read(br, ReadLong);
                var chatId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var bytes = Read(br, ReadBytes);
                var file = Read(br, T.EncryptedFile.Deserialize);
                return new Tag(randomId, chatId, date, bytes, file);
            }
        }

        public sealed class ServiceTag : Record<ServiceTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x23734b06;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long RandomId { get; }
            public int ChatId { get; }
            public int Date { get; }
            public Arr<byte> Bytes { get; }
            
            public ServiceTag(
                long randomId,
                int chatId,
                int date,
                Some<Arr<byte>> bytes
            ) {
                RandomId = randomId;
                ChatId = chatId;
                Date = date;
                Bytes = bytes;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(RandomId, bw, WriteLong);
                Write(ChatId, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(Bytes, bw, WriteBytes);
            }
            
            internal static ServiceTag DeserializeTag(BinaryReader br)
            {
                var randomId = Read(br, ReadLong);
                var chatId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var bytes = Read(br, ReadBytes);
                return new ServiceTag(randomId, chatId, date, bytes);
            }
        }

        readonly ITlTypeTag _tag;
        EncryptedMessage(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator EncryptedMessage(Tag tag) => new EncryptedMessage(tag);
        public static explicit operator EncryptedMessage(ServiceTag tag) => new EncryptedMessage(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static EncryptedMessage Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (EncryptedMessage) Tag.DeserializeTag(br);
                case ServiceTag.TypeNumber: return (EncryptedMessage) ServiceTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, ServiceTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<ServiceTag, T> serviceTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case ServiceTag x when serviceTag != null: return serviceTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<ServiceTag, T> serviceTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            serviceTag ?? throw new ArgumentNullException(nameof(serviceTag))
        );

        public bool Equals(EncryptedMessage other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is EncryptedMessage x && Equals(x);
        public static bool operator ==(EncryptedMessage a, EncryptedMessage b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(EncryptedMessage a, EncryptedMessage b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case ServiceTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(EncryptedMessage other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is EncryptedMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EncryptedMessage a, EncryptedMessage b) => a.CompareTo(b) <= 0;
        public static bool operator <(EncryptedMessage a, EncryptedMessage b) => a.CompareTo(b) < 0;
        public static bool operator >(EncryptedMessage a, EncryptedMessage b) => a.CompareTo(b) > 0;
        public static bool operator >=(EncryptedMessage a, EncryptedMessage b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}