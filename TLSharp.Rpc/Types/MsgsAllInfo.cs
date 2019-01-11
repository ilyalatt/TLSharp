using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class MsgsAllInfo : ITlType, IEquatable<MsgsAllInfo>, IComparable<MsgsAllInfo>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x8cc0d131;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<long> MsgIds;
            public readonly string Info;
            
            public Tag(
                Some<Arr<long>> msgIds,
                Some<string> info
            ) {
                MsgIds = msgIds;
                Info = info;
            }
            
            (Arr<long>, string) CmpTuple =>
                (MsgIds, Info);

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

            public override string ToString() => $"(MsgIds: {MsgIds}, Info: {Info})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MsgIds, bw, WriteVector<long>(WriteLong));
                Write(Info, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var msgIds = Read(br, ReadVector(ReadLong));
                var info = Read(br, ReadString);
                return new Tag(msgIds, info);
            }
        }

        readonly ITlTypeTag _tag;
        MsgsAllInfo(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MsgsAllInfo(Tag tag) => new MsgsAllInfo(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static MsgsAllInfo Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (MsgsAllInfo) Tag.DeserializeTag(br);
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

        public bool Equals(MsgsAllInfo other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is MsgsAllInfo x && Equals(x);
        public static bool operator ==(MsgsAllInfo x, MsgsAllInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MsgsAllInfo x, MsgsAllInfo y) => !(x == y);

        public int CompareTo(MsgsAllInfo other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is MsgsAllInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MsgsAllInfo x, MsgsAllInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(MsgsAllInfo x, MsgsAllInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(MsgsAllInfo x, MsgsAllInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(MsgsAllInfo x, MsgsAllInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"MsgsAllInfo.{_tag.GetType().Name}{_tag}";
    }
}