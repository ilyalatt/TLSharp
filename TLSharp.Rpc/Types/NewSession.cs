using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class NewSession : ITlType, IEquatable<NewSession>, IComparable<NewSession>, IComparable
    {
        public sealed class CreatedTag : ITlTypeTag, IEquatable<CreatedTag>, IComparable<CreatedTag>, IComparable
        {
            internal const uint TypeNumber = 0x9ec20908;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long FirstMsgId;
            public readonly long UniqueId;
            public readonly long ServerSalt;
            
            public CreatedTag(
                long firstMsgId,
                long uniqueId,
                long serverSalt
            ) {
                FirstMsgId = firstMsgId;
                UniqueId = uniqueId;
                ServerSalt = serverSalt;
            }
            
            (long, long, long) CmpTuple =>
                (FirstMsgId, UniqueId, ServerSalt);

            public bool Equals(CreatedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is CreatedTag x && Equals(x);
            public static bool operator ==(CreatedTag x, CreatedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CreatedTag x, CreatedTag y) => !(x == y);

            public int CompareTo(CreatedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is CreatedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CreatedTag x, CreatedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CreatedTag x, CreatedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CreatedTag x, CreatedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CreatedTag x, CreatedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(FirstMsgId: {FirstMsgId}, UniqueId: {UniqueId}, ServerSalt: {ServerSalt})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(FirstMsgId, bw, WriteLong);
                Write(UniqueId, bw, WriteLong);
                Write(ServerSalt, bw, WriteLong);
            }
            
            internal static CreatedTag DeserializeTag(BinaryReader br)
            {
                var firstMsgId = Read(br, ReadLong);
                var uniqueId = Read(br, ReadLong);
                var serverSalt = Read(br, ReadLong);
                return new CreatedTag(firstMsgId, uniqueId, serverSalt);
            }
        }

        readonly ITlTypeTag _tag;
        NewSession(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator NewSession(CreatedTag tag) => new NewSession(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static NewSession Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case CreatedTag.TypeNumber: return (NewSession) CreatedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { CreatedTag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<CreatedTag, T> createdTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case CreatedTag x when createdTag != null: return createdTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<CreatedTag, T> createdTag
        ) => Match(
            () => throw new Exception("WTF"),
            createdTag ?? throw new ArgumentNullException(nameof(createdTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case CreatedTag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(NewSession other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is NewSession x && Equals(x);
        public static bool operator ==(NewSession x, NewSession y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(NewSession x, NewSession y) => !(x == y);

        public int CompareTo(NewSession other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is NewSession x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(NewSession x, NewSession y) => x.CompareTo(y) <= 0;
        public static bool operator <(NewSession x, NewSession y) => x.CompareTo(y) < 0;
        public static bool operator >(NewSession x, NewSession y) => x.CompareTo(y) > 0;
        public static bool operator >=(NewSession x, NewSession y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"NewSession.{_tag.GetType().Name}{_tag}";
    }
}