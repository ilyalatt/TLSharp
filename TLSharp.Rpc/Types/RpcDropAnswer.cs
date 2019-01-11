using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class RpcDropAnswer : ITlType, IEquatable<RpcDropAnswer>, IComparable<RpcDropAnswer>, IComparable
    {
        public sealed class AnswerUnknownTag : ITlTypeTag, IEquatable<AnswerUnknownTag>, IComparable<AnswerUnknownTag>, IComparable
        {
            internal const uint TypeNumber = 0x5e2ad36e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public AnswerUnknownTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(AnswerUnknownTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AnswerUnknownTag x && Equals(x);
            public static bool operator ==(AnswerUnknownTag x, AnswerUnknownTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AnswerUnknownTag x, AnswerUnknownTag y) => !(x == y);

            public int CompareTo(AnswerUnknownTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AnswerUnknownTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AnswerUnknownTag x, AnswerUnknownTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AnswerUnknownTag x, AnswerUnknownTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AnswerUnknownTag x, AnswerUnknownTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AnswerUnknownTag x, AnswerUnknownTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static AnswerUnknownTag DeserializeTag(BinaryReader br)
            {

                return new AnswerUnknownTag();
            }
        }

        public sealed class AnswerDroppedRunningTag : ITlTypeTag, IEquatable<AnswerDroppedRunningTag>, IComparable<AnswerDroppedRunningTag>, IComparable
        {
            internal const uint TypeNumber = 0xcd78e586;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public AnswerDroppedRunningTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(AnswerDroppedRunningTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AnswerDroppedRunningTag x && Equals(x);
            public static bool operator ==(AnswerDroppedRunningTag x, AnswerDroppedRunningTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AnswerDroppedRunningTag x, AnswerDroppedRunningTag y) => !(x == y);

            public int CompareTo(AnswerDroppedRunningTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AnswerDroppedRunningTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AnswerDroppedRunningTag x, AnswerDroppedRunningTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AnswerDroppedRunningTag x, AnswerDroppedRunningTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AnswerDroppedRunningTag x, AnswerDroppedRunningTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AnswerDroppedRunningTag x, AnswerDroppedRunningTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static AnswerDroppedRunningTag DeserializeTag(BinaryReader br)
            {

                return new AnswerDroppedRunningTag();
            }
        }

        public sealed class AnswerDroppedTag : ITlTypeTag, IEquatable<AnswerDroppedTag>, IComparable<AnswerDroppedTag>, IComparable
        {
            internal const uint TypeNumber = 0xa43ad8b7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long MsgId;
            public readonly int SeqNo;
            public readonly int Bytes;
            
            public AnswerDroppedTag(
                long msgId,
                int seqNo,
                int bytes
            ) {
                MsgId = msgId;
                SeqNo = seqNo;
                Bytes = bytes;
            }
            
            (long, int, int) CmpTuple =>
                (MsgId, SeqNo, Bytes);

            public bool Equals(AnswerDroppedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AnswerDroppedTag x && Equals(x);
            public static bool operator ==(AnswerDroppedTag x, AnswerDroppedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AnswerDroppedTag x, AnswerDroppedTag y) => !(x == y);

            public int CompareTo(AnswerDroppedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AnswerDroppedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AnswerDroppedTag x, AnswerDroppedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AnswerDroppedTag x, AnswerDroppedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AnswerDroppedTag x, AnswerDroppedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AnswerDroppedTag x, AnswerDroppedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(MsgId: {MsgId}, SeqNo: {SeqNo}, Bytes: {Bytes})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MsgId, bw, WriteLong);
                Write(SeqNo, bw, WriteInt);
                Write(Bytes, bw, WriteInt);
            }
            
            internal static AnswerDroppedTag DeserializeTag(BinaryReader br)
            {
                var msgId = Read(br, ReadLong);
                var seqNo = Read(br, ReadInt);
                var bytes = Read(br, ReadInt);
                return new AnswerDroppedTag(msgId, seqNo, bytes);
            }
        }

        readonly ITlTypeTag _tag;
        RpcDropAnswer(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator RpcDropAnswer(AnswerUnknownTag tag) => new RpcDropAnswer(tag);
        public static explicit operator RpcDropAnswer(AnswerDroppedRunningTag tag) => new RpcDropAnswer(tag);
        public static explicit operator RpcDropAnswer(AnswerDroppedTag tag) => new RpcDropAnswer(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static RpcDropAnswer Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case AnswerUnknownTag.TypeNumber: return (RpcDropAnswer) AnswerUnknownTag.DeserializeTag(br);
                case AnswerDroppedRunningTag.TypeNumber: return (RpcDropAnswer) AnswerDroppedRunningTag.DeserializeTag(br);
                case AnswerDroppedTag.TypeNumber: return (RpcDropAnswer) AnswerDroppedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { AnswerUnknownTag.TypeNumber, AnswerDroppedRunningTag.TypeNumber, AnswerDroppedTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<AnswerUnknownTag, T> answerUnknownTag = null,
            Func<AnswerDroppedRunningTag, T> answerDroppedRunningTag = null,
            Func<AnswerDroppedTag, T> answerDroppedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case AnswerUnknownTag x when answerUnknownTag != null: return answerUnknownTag(x);
                case AnswerDroppedRunningTag x when answerDroppedRunningTag != null: return answerDroppedRunningTag(x);
                case AnswerDroppedTag x when answerDroppedTag != null: return answerDroppedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<AnswerUnknownTag, T> answerUnknownTag,
            Func<AnswerDroppedRunningTag, T> answerDroppedRunningTag,
            Func<AnswerDroppedTag, T> answerDroppedTag
        ) => Match(
            () => throw new Exception("WTF"),
            answerUnknownTag ?? throw new ArgumentNullException(nameof(answerUnknownTag)),
            answerDroppedRunningTag ?? throw new ArgumentNullException(nameof(answerDroppedRunningTag)),
            answerDroppedTag ?? throw new ArgumentNullException(nameof(answerDroppedTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case AnswerUnknownTag _: return 0;
                case AnswerDroppedRunningTag _: return 1;
                case AnswerDroppedTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(RpcDropAnswer other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is RpcDropAnswer x && Equals(x);
        public static bool operator ==(RpcDropAnswer x, RpcDropAnswer y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(RpcDropAnswer x, RpcDropAnswer y) => !(x == y);

        public int CompareTo(RpcDropAnswer other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is RpcDropAnswer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RpcDropAnswer x, RpcDropAnswer y) => x.CompareTo(y) <= 0;
        public static bool operator <(RpcDropAnswer x, RpcDropAnswer y) => x.CompareTo(y) < 0;
        public static bool operator >(RpcDropAnswer x, RpcDropAnswer y) => x.CompareTo(y) > 0;
        public static bool operator >=(RpcDropAnswer x, RpcDropAnswer y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"RpcDropAnswer.{_tag.GetType().Name}{_tag}";
    }
}