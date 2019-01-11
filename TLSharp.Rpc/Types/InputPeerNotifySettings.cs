using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputPeerNotifySettings : ITlType, IEquatable<InputPeerNotifySettings>, IComparable<InputPeerNotifySettings>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x9c3d198e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Option<bool> ShowPreviews;
            public readonly Option<bool> Silent;
            public readonly Option<int> MuteUntil;
            public readonly Option<string> Sound;
            
            public Tag(
                Option<bool> showPreviews,
                Option<bool> silent,
                Option<int> muteUntil,
                Option<string> sound
            ) {
                ShowPreviews = showPreviews;
                Silent = silent;
                MuteUntil = muteUntil;
                Sound = sound;
            }
            
            (Option<bool>, Option<bool>, Option<int>, Option<string>) CmpTuple =>
                (ShowPreviews, Silent, MuteUntil, Sound);

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

            public override string ToString() => $"(ShowPreviews: {ShowPreviews}, Silent: {Silent}, MuteUntil: {MuteUntil}, Sound: {Sound})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, ShowPreviews) | MaskBit(1, Silent) | MaskBit(2, MuteUntil) | MaskBit(3, Sound), bw, WriteInt);
                Write(ShowPreviews, bw, WriteOption<bool>(WriteBool));
                Write(Silent, bw, WriteOption<bool>(WriteBool));
                Write(MuteUntil, bw, WriteOption<int>(WriteInt));
                Write(Sound, bw, WriteOption<string>(WriteString));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var showPreviews = Read(br, ReadOption(flags, 0, ReadBool));
                var silent = Read(br, ReadOption(flags, 1, ReadBool));
                var muteUntil = Read(br, ReadOption(flags, 2, ReadInt));
                var sound = Read(br, ReadOption(flags, 3, ReadString));
                return new Tag(showPreviews, silent, muteUntil, sound);
            }
        }

        readonly ITlTypeTag _tag;
        InputPeerNotifySettings(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputPeerNotifySettings(Tag tag) => new InputPeerNotifySettings(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputPeerNotifySettings Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputPeerNotifySettings) Tag.DeserializeTag(br);
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

        public bool Equals(InputPeerNotifySettings other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputPeerNotifySettings x && Equals(x);
        public static bool operator ==(InputPeerNotifySettings x, InputPeerNotifySettings y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputPeerNotifySettings x, InputPeerNotifySettings y) => !(x == y);

        public int CompareTo(InputPeerNotifySettings other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputPeerNotifySettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPeerNotifySettings x, InputPeerNotifySettings y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputPeerNotifySettings x, InputPeerNotifySettings y) => x.CompareTo(y) < 0;
        public static bool operator >(InputPeerNotifySettings x, InputPeerNotifySettings y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputPeerNotifySettings x, InputPeerNotifySettings y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputPeerNotifySettings.{_tag.GetType().Name}{_tag}";
    }
}