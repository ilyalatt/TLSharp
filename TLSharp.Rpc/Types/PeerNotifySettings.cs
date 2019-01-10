using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PeerNotifySettings : ITlType, IEquatable<PeerNotifySettings>, IComparable<PeerNotifySettings>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x70a68512;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x9acda4c0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
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
        PeerNotifySettings(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PeerNotifySettings(EmptyTag tag) => new PeerNotifySettings(tag);
        public static explicit operator PeerNotifySettings(Tag tag) => new PeerNotifySettings(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PeerNotifySettings Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (PeerNotifySettings) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (PeerNotifySettings) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(PeerNotifySettings other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PeerNotifySettings x && Equals(x);
        public static bool operator ==(PeerNotifySettings a, PeerNotifySettings b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PeerNotifySettings a, PeerNotifySettings b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PeerNotifySettings other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PeerNotifySettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PeerNotifySettings a, PeerNotifySettings b) => a.CompareTo(b) <= 0;
        public static bool operator <(PeerNotifySettings a, PeerNotifySettings b) => a.CompareTo(b) < 0;
        public static bool operator >(PeerNotifySettings a, PeerNotifySettings b) => a.CompareTo(b) > 0;
        public static bool operator >=(PeerNotifySettings a, PeerNotifySettings b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}