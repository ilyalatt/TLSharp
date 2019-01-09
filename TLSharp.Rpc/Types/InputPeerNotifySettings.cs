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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x38935eb2;
            
            public bool ShowPreviews { get; }
            public bool Silent { get; }
            public int MuteUntil { get; }
            public string Sound { get; }
            
            public Tag(
                bool showPreviews,
                bool silent,
                int muteUntil,
                Some<string> sound
            ) {
                ShowPreviews = showPreviews;
                Silent = silent;
                MuteUntil = muteUntil;
                Sound = sound;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, ShowPreviews) | MaskBit(1, Silent), bw, WriteInt);
                Write(MuteUntil, bw, WriteInt);
                Write(Sound, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var showPreviews = Read(br, ReadOption(flags, 0));
                var silent = Read(br, ReadOption(flags, 1));
                var muteUntil = Read(br, ReadInt);
                var sound = Read(br, ReadString);
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
                case 0x38935eb2: return (InputPeerNotifySettings) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x38935eb2 });
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

        public bool Equals(InputPeerNotifySettings other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputPeerNotifySettings x && Equals(x);
        public static bool operator ==(InputPeerNotifySettings a, InputPeerNotifySettings b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputPeerNotifySettings a, InputPeerNotifySettings b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputPeerNotifySettings other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputPeerNotifySettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPeerNotifySettings a, InputPeerNotifySettings b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputPeerNotifySettings a, InputPeerNotifySettings b) => a.CompareTo(b) < 0;
        public static bool operator >(InputPeerNotifySettings a, InputPeerNotifySettings b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputPeerNotifySettings a, InputPeerNotifySettings b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}