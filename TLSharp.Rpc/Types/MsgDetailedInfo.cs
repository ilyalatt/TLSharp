using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class MsgDetailedInfo : ITlType, IEquatable<MsgDetailedInfo>, IComparable<MsgDetailedInfo>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x276d3ec6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long MsgId { get; }
            public long AnswerMsgId { get; }
            public int Bytes { get; }
            public int Status { get; }
            
            public Tag(
                long msgId,
                long answerMsgId,
                int bytes,
                int status
            ) {
                MsgId = msgId;
                AnswerMsgId = answerMsgId;
                Bytes = bytes;
                Status = status;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MsgId, bw, WriteLong);
                Write(AnswerMsgId, bw, WriteLong);
                Write(Bytes, bw, WriteInt);
                Write(Status, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var msgId = Read(br, ReadLong);
                var answerMsgId = Read(br, ReadLong);
                var bytes = Read(br, ReadInt);
                var status = Read(br, ReadInt);
                return new Tag(msgId, answerMsgId, bytes, status);
            }
        }

        public sealed class NewTag : Record<NewTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x809db6df;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long AnswerMsgId { get; }
            public int Bytes { get; }
            public int Status { get; }
            
            public NewTag(
                long answerMsgId,
                int bytes,
                int status
            ) {
                AnswerMsgId = answerMsgId;
                Bytes = bytes;
                Status = status;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(AnswerMsgId, bw, WriteLong);
                Write(Bytes, bw, WriteInt);
                Write(Status, bw, WriteInt);
            }
            
            internal static NewTag DeserializeTag(BinaryReader br)
            {
                var answerMsgId = Read(br, ReadLong);
                var bytes = Read(br, ReadInt);
                var status = Read(br, ReadInt);
                return new NewTag(answerMsgId, bytes, status);
            }
        }

        readonly ITlTypeTag _tag;
        MsgDetailedInfo(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MsgDetailedInfo(Tag tag) => new MsgDetailedInfo(tag);
        public static explicit operator MsgDetailedInfo(NewTag tag) => new MsgDetailedInfo(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static MsgDetailedInfo Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (MsgDetailedInfo) Tag.DeserializeTag(br);
                case NewTag.TypeNumber: return (MsgDetailedInfo) NewTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, NewTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<NewTag, T> newTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case NewTag x when newTag != null: return newTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<NewTag, T> newTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            newTag ?? throw new ArgumentNullException(nameof(newTag))
        );

        public bool Equals(MsgDetailedInfo other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is MsgDetailedInfo x && Equals(x);
        public static bool operator ==(MsgDetailedInfo a, MsgDetailedInfo b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(MsgDetailedInfo a, MsgDetailedInfo b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case NewTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(MsgDetailedInfo other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is MsgDetailedInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MsgDetailedInfo a, MsgDetailedInfo b) => a.CompareTo(b) <= 0;
        public static bool operator <(MsgDetailedInfo a, MsgDetailedInfo b) => a.CompareTo(b) < 0;
        public static bool operator >(MsgDetailedInfo a, MsgDetailedInfo b) => a.CompareTo(b) > 0;
        public static bool operator >=(MsgDetailedInfo a, MsgDetailedInfo b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}