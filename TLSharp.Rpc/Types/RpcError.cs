using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class RpcError : ITlType, IEquatable<RpcError>, IComparable<RpcError>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x2144ca19;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ErrorCode { get; }
            public string ErrorMessage { get; }
            
            public Tag(
                int errorCode,
                Some<string> errorMessage
            ) {
                ErrorCode = errorCode;
                ErrorMessage = errorMessage;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ErrorCode, bw, WriteInt);
                Write(ErrorMessage, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var errorCode = Read(br, ReadInt);
                var errorMessage = Read(br, ReadString);
                return new Tag(errorCode, errorMessage);
            }
        }

        readonly ITlTypeTag _tag;
        RpcError(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator RpcError(Tag tag) => new RpcError(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static RpcError Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (RpcError) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(RpcError other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is RpcError x && Equals(x);
        public static bool operator ==(RpcError a, RpcError b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(RpcError a, RpcError b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(RpcError other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is RpcError x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RpcError a, RpcError b) => a.CompareTo(b) <= 0;
        public static bool operator <(RpcError a, RpcError b) => a.CompareTo(b) < 0;
        public static bool operator >(RpcError a, RpcError b) => a.CompareTo(b) > 0;
        public static bool operator >=(RpcError a, RpcError b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}