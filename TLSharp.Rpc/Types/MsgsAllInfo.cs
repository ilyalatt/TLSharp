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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x8cc0d131;
            
            public Arr<long> MsgIds { get; }
            public string Info { get; }
            
            public Tag(
                Some<Arr<long>> msgIds,
                Some<string> info
            ) {
                MsgIds = msgIds;
                Info = info;
            }
            
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
                case 0x8cc0d131: return (MsgsAllInfo) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x8cc0d131 });
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

        public bool Equals(MsgsAllInfo other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is MsgsAllInfo x && Equals(x);
        public static bool operator ==(MsgsAllInfo a, MsgsAllInfo b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(MsgsAllInfo a, MsgsAllInfo b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(MsgsAllInfo other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is MsgsAllInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MsgsAllInfo a, MsgsAllInfo b) => a.CompareTo(b) <= 0;
        public static bool operator <(MsgsAllInfo a, MsgsAllInfo b) => a.CompareTo(b) < 0;
        public static bool operator >(MsgsAllInfo a, MsgsAllInfo b) => a.CompareTo(b) > 0;
        public static bool operator >=(MsgsAllInfo a, MsgsAllInfo b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}