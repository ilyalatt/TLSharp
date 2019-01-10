using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class DraftMessage : ITlType, IEquatable<DraftMessage>, IComparable<DraftMessage>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xba4baec5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xfd8e711f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool NoWebpage { get; }
            public Option<int> ReplyToMsgId { get; }
            public string Message { get; }
            public Option<Arr<T.MessageEntity>> Entities { get; }
            public int Date { get; }
            
            public Tag(
                bool noWebpage,
                Option<int> replyToMsgId,
                Some<string> message,
                Option<Arr<T.MessageEntity>> entities,
                int date
            ) {
                NoWebpage = noWebpage;
                ReplyToMsgId = replyToMsgId;
                Message = message;
                Entities = entities;
                Date = date;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, NoWebpage) | MaskBit(0, ReplyToMsgId) | MaskBit(3, Entities), bw, WriteInt);
                Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
                Write(Message, bw, WriteString);
                Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
                Write(Date, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var noWebpage = Read(br, ReadOption(flags, 1));
                var replyToMsgId = Read(br, ReadOption(flags, 0, ReadInt));
                var message = Read(br, ReadString);
                var entities = Read(br, ReadOption(flags, 3, ReadVector(T.MessageEntity.Deserialize)));
                var date = Read(br, ReadInt);
                return new Tag(noWebpage, replyToMsgId, message, entities, date);
            }
        }

        readonly ITlTypeTag _tag;
        DraftMessage(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator DraftMessage(EmptyTag tag) => new DraftMessage(tag);
        public static explicit operator DraftMessage(Tag tag) => new DraftMessage(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static DraftMessage Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (DraftMessage) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (DraftMessage) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(DraftMessage other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is DraftMessage x && Equals(x);
        public static bool operator ==(DraftMessage a, DraftMessage b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(DraftMessage a, DraftMessage b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(DraftMessage other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DraftMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DraftMessage a, DraftMessage b) => a.CompareTo(b) <= 0;
        public static bool operator <(DraftMessage a, DraftMessage b) => a.CompareTo(b) < 0;
        public static bool operator >(DraftMessage a, DraftMessage b) => a.CompareTo(b) > 0;
        public static bool operator >=(DraftMessage a, DraftMessage b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}