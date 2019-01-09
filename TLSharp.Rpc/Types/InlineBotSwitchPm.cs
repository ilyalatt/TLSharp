using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InlineBotSwitchPm : ITlType, IEquatable<InlineBotSwitchPm>, IComparable<InlineBotSwitchPm>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3c20629f;
            
            public string Text { get; }
            public string StartParam { get; }
            
            public Tag(
                Some<string> text,
                Some<string> startParam
            ) {
                Text = text;
                StartParam = startParam;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteString);
                Write(StartParam, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, ReadString);
                var startParam = Read(br, ReadString);
                return new Tag(text, startParam);
            }
        }

        readonly ITlTypeTag _tag;
        InlineBotSwitchPm(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InlineBotSwitchPm(Tag tag) => new InlineBotSwitchPm(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InlineBotSwitchPm Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x3c20629f: return (InlineBotSwitchPm) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x3c20629f });
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

        public bool Equals(InlineBotSwitchPm other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InlineBotSwitchPm x && Equals(x);
        public static bool operator ==(InlineBotSwitchPm a, InlineBotSwitchPm b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InlineBotSwitchPm a, InlineBotSwitchPm b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InlineBotSwitchPm other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InlineBotSwitchPm x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InlineBotSwitchPm a, InlineBotSwitchPm b) => a.CompareTo(b) <= 0;
        public static bool operator <(InlineBotSwitchPm a, InlineBotSwitchPm b) => a.CompareTo(b) < 0;
        public static bool operator >(InlineBotSwitchPm a, InlineBotSwitchPm b) => a.CompareTo(b) > 0;
        public static bool operator >=(InlineBotSwitchPm a, InlineBotSwitchPm b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}