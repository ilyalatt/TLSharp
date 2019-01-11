using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class MsgsStateInfo : ITlType, IEquatable<MsgsStateInfo>, IComparable<MsgsStateInfo>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x04deb57d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long ReqMsgId { get; }
            public string Info { get; }
            
            public Tag(
                long reqMsgId,
                Some<string> info
            ) {
                ReqMsgId = reqMsgId;
                Info = info;
            }
            
            (long, string) CmpTuple =>
                (ReqMsgId, Info);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ReqMsgId: {ReqMsgId}, Info: {Info})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ReqMsgId, bw, WriteLong);
                Write(Info, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var reqMsgId = Read(br, ReadLong);
                var info = Read(br, ReadString);
                return new Tag(reqMsgId, info);
            }
        }

        readonly ITlTypeTag _tag;
        MsgsStateInfo(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MsgsStateInfo(Tag tag) => new MsgsStateInfo(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static MsgsStateInfo Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (MsgsStateInfo) Tag.DeserializeTag(br);
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

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(MsgsStateInfo other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is MsgsStateInfo x && Equals(x);
        public static bool operator ==(MsgsStateInfo x, MsgsStateInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MsgsStateInfo x, MsgsStateInfo y) => !(x == y);

        public int CompareTo(MsgsStateInfo other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is MsgsStateInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MsgsStateInfo x, MsgsStateInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(MsgsStateInfo x, MsgsStateInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(MsgsStateInfo x, MsgsStateInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(MsgsStateInfo x, MsgsStateInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"MsgsStateInfo.{_tag.GetType().Name}{_tag}";
    }
}