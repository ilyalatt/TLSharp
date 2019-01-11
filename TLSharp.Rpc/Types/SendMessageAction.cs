using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class SendMessageAction : ITlType, IEquatable<SendMessageAction>, IComparable<SendMessageAction>, IComparable
    {
        public sealed class TypingTag : ITlTypeTag, IEquatable<TypingTag>, IComparable<TypingTag>, IComparable
        {
            internal const uint TypeNumber = 0x16bf744e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public TypingTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(TypingTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is TypingTag x && Equals(x);
            public static bool operator ==(TypingTag x, TypingTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TypingTag x, TypingTag y) => !(x == y);

            public int CompareTo(TypingTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is TypingTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TypingTag x, TypingTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TypingTag x, TypingTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TypingTag x, TypingTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TypingTag x, TypingTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static TypingTag DeserializeTag(BinaryReader br)
            {

                return new TypingTag();
            }
        }

        public sealed class CancelTag : ITlTypeTag, IEquatable<CancelTag>, IComparable<CancelTag>, IComparable
        {
            internal const uint TypeNumber = 0xfd5ec8f5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public CancelTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(CancelTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is CancelTag x && Equals(x);
            public static bool operator ==(CancelTag x, CancelTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CancelTag x, CancelTag y) => !(x == y);

            public int CompareTo(CancelTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is CancelTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CancelTag x, CancelTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CancelTag x, CancelTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CancelTag x, CancelTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CancelTag x, CancelTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static CancelTag DeserializeTag(BinaryReader br)
            {

                return new CancelTag();
            }
        }

        public sealed class RecordVideoTag : ITlTypeTag, IEquatable<RecordVideoTag>, IComparable<RecordVideoTag>, IComparable
        {
            internal const uint TypeNumber = 0xa187d66f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RecordVideoTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(RecordVideoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is RecordVideoTag x && Equals(x);
            public static bool operator ==(RecordVideoTag x, RecordVideoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RecordVideoTag x, RecordVideoTag y) => !(x == y);

            public int CompareTo(RecordVideoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is RecordVideoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RecordVideoTag x, RecordVideoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RecordVideoTag x, RecordVideoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RecordVideoTag x, RecordVideoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RecordVideoTag x, RecordVideoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RecordVideoTag DeserializeTag(BinaryReader br)
            {

                return new RecordVideoTag();
            }
        }

        public sealed class UploadVideoTag : ITlTypeTag, IEquatable<UploadVideoTag>, IComparable<UploadVideoTag>, IComparable
        {
            internal const uint TypeNumber = 0xe9763aec;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Progress { get; }
            
            public UploadVideoTag(
                int progress
            ) {
                Progress = progress;
            }
            
            int CmpTuple =>
                Progress;

            public bool Equals(UploadVideoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UploadVideoTag x && Equals(x);
            public static bool operator ==(UploadVideoTag x, UploadVideoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadVideoTag x, UploadVideoTag y) => !(x == y);

            public int CompareTo(UploadVideoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UploadVideoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadVideoTag x, UploadVideoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadVideoTag x, UploadVideoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadVideoTag x, UploadVideoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadVideoTag x, UploadVideoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Progress: {Progress})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Progress, bw, WriteInt);
            }
            
            internal static UploadVideoTag DeserializeTag(BinaryReader br)
            {
                var progress = Read(br, ReadInt);
                return new UploadVideoTag(progress);
            }
        }

        public sealed class RecordAudioTag : ITlTypeTag, IEquatable<RecordAudioTag>, IComparable<RecordAudioTag>, IComparable
        {
            internal const uint TypeNumber = 0xd52f73f7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RecordAudioTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(RecordAudioTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is RecordAudioTag x && Equals(x);
            public static bool operator ==(RecordAudioTag x, RecordAudioTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RecordAudioTag x, RecordAudioTag y) => !(x == y);

            public int CompareTo(RecordAudioTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is RecordAudioTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RecordAudioTag x, RecordAudioTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RecordAudioTag x, RecordAudioTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RecordAudioTag x, RecordAudioTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RecordAudioTag x, RecordAudioTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RecordAudioTag DeserializeTag(BinaryReader br)
            {

                return new RecordAudioTag();
            }
        }

        public sealed class UploadAudioTag : ITlTypeTag, IEquatable<UploadAudioTag>, IComparable<UploadAudioTag>, IComparable
        {
            internal const uint TypeNumber = 0xf351d7ab;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Progress { get; }
            
            public UploadAudioTag(
                int progress
            ) {
                Progress = progress;
            }
            
            int CmpTuple =>
                Progress;

            public bool Equals(UploadAudioTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UploadAudioTag x && Equals(x);
            public static bool operator ==(UploadAudioTag x, UploadAudioTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadAudioTag x, UploadAudioTag y) => !(x == y);

            public int CompareTo(UploadAudioTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UploadAudioTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadAudioTag x, UploadAudioTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadAudioTag x, UploadAudioTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadAudioTag x, UploadAudioTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadAudioTag x, UploadAudioTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Progress: {Progress})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Progress, bw, WriteInt);
            }
            
            internal static UploadAudioTag DeserializeTag(BinaryReader br)
            {
                var progress = Read(br, ReadInt);
                return new UploadAudioTag(progress);
            }
        }

        public sealed class UploadPhotoTag : ITlTypeTag, IEquatable<UploadPhotoTag>, IComparable<UploadPhotoTag>, IComparable
        {
            internal const uint TypeNumber = 0xd1d34a26;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Progress { get; }
            
            public UploadPhotoTag(
                int progress
            ) {
                Progress = progress;
            }
            
            int CmpTuple =>
                Progress;

            public bool Equals(UploadPhotoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UploadPhotoTag x && Equals(x);
            public static bool operator ==(UploadPhotoTag x, UploadPhotoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadPhotoTag x, UploadPhotoTag y) => !(x == y);

            public int CompareTo(UploadPhotoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UploadPhotoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadPhotoTag x, UploadPhotoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadPhotoTag x, UploadPhotoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadPhotoTag x, UploadPhotoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadPhotoTag x, UploadPhotoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Progress: {Progress})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Progress, bw, WriteInt);
            }
            
            internal static UploadPhotoTag DeserializeTag(BinaryReader br)
            {
                var progress = Read(br, ReadInt);
                return new UploadPhotoTag(progress);
            }
        }

        public sealed class UploadDocumentTag : ITlTypeTag, IEquatable<UploadDocumentTag>, IComparable<UploadDocumentTag>, IComparable
        {
            internal const uint TypeNumber = 0xaa0cd9e4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Progress { get; }
            
            public UploadDocumentTag(
                int progress
            ) {
                Progress = progress;
            }
            
            int CmpTuple =>
                Progress;

            public bool Equals(UploadDocumentTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UploadDocumentTag x && Equals(x);
            public static bool operator ==(UploadDocumentTag x, UploadDocumentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadDocumentTag x, UploadDocumentTag y) => !(x == y);

            public int CompareTo(UploadDocumentTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UploadDocumentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadDocumentTag x, UploadDocumentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadDocumentTag x, UploadDocumentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadDocumentTag x, UploadDocumentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadDocumentTag x, UploadDocumentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Progress: {Progress})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Progress, bw, WriteInt);
            }
            
            internal static UploadDocumentTag DeserializeTag(BinaryReader br)
            {
                var progress = Read(br, ReadInt);
                return new UploadDocumentTag(progress);
            }
        }

        public sealed class GeoLocationTag : ITlTypeTag, IEquatable<GeoLocationTag>, IComparable<GeoLocationTag>, IComparable
        {
            internal const uint TypeNumber = 0x176f8ba1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public GeoLocationTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(GeoLocationTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is GeoLocationTag x && Equals(x);
            public static bool operator ==(GeoLocationTag x, GeoLocationTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GeoLocationTag x, GeoLocationTag y) => !(x == y);

            public int CompareTo(GeoLocationTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is GeoLocationTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GeoLocationTag x, GeoLocationTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GeoLocationTag x, GeoLocationTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GeoLocationTag x, GeoLocationTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GeoLocationTag x, GeoLocationTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static GeoLocationTag DeserializeTag(BinaryReader br)
            {

                return new GeoLocationTag();
            }
        }

        public sealed class ChooseContactTag : ITlTypeTag, IEquatable<ChooseContactTag>, IComparable<ChooseContactTag>, IComparable
        {
            internal const uint TypeNumber = 0x628cbc6f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ChooseContactTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ChooseContactTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChooseContactTag x && Equals(x);
            public static bool operator ==(ChooseContactTag x, ChooseContactTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChooseContactTag x, ChooseContactTag y) => !(x == y);

            public int CompareTo(ChooseContactTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChooseContactTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChooseContactTag x, ChooseContactTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChooseContactTag x, ChooseContactTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChooseContactTag x, ChooseContactTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChooseContactTag x, ChooseContactTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChooseContactTag DeserializeTag(BinaryReader br)
            {

                return new ChooseContactTag();
            }
        }

        public sealed class GamePlayTag : ITlTypeTag, IEquatable<GamePlayTag>, IComparable<GamePlayTag>, IComparable
        {
            internal const uint TypeNumber = 0xdd6a8f48;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public GamePlayTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(GamePlayTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is GamePlayTag x && Equals(x);
            public static bool operator ==(GamePlayTag x, GamePlayTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GamePlayTag x, GamePlayTag y) => !(x == y);

            public int CompareTo(GamePlayTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is GamePlayTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GamePlayTag x, GamePlayTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GamePlayTag x, GamePlayTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GamePlayTag x, GamePlayTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GamePlayTag x, GamePlayTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static GamePlayTag DeserializeTag(BinaryReader br)
            {

                return new GamePlayTag();
            }
        }

        public sealed class RecordRoundTag : ITlTypeTag, IEquatable<RecordRoundTag>, IComparable<RecordRoundTag>, IComparable
        {
            internal const uint TypeNumber = 0x88f27fbc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RecordRoundTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(RecordRoundTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is RecordRoundTag x && Equals(x);
            public static bool operator ==(RecordRoundTag x, RecordRoundTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RecordRoundTag x, RecordRoundTag y) => !(x == y);

            public int CompareTo(RecordRoundTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is RecordRoundTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RecordRoundTag x, RecordRoundTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RecordRoundTag x, RecordRoundTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RecordRoundTag x, RecordRoundTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RecordRoundTag x, RecordRoundTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RecordRoundTag DeserializeTag(BinaryReader br)
            {

                return new RecordRoundTag();
            }
        }

        public sealed class UploadRoundTag : ITlTypeTag, IEquatable<UploadRoundTag>, IComparable<UploadRoundTag>, IComparable
        {
            internal const uint TypeNumber = 0xbb718624;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public UploadRoundTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(UploadRoundTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UploadRoundTag x && Equals(x);
            public static bool operator ==(UploadRoundTag x, UploadRoundTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadRoundTag x, UploadRoundTag y) => !(x == y);

            public int CompareTo(UploadRoundTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UploadRoundTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadRoundTag x, UploadRoundTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadRoundTag x, UploadRoundTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadRoundTag x, UploadRoundTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadRoundTag x, UploadRoundTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static UploadRoundTag DeserializeTag(BinaryReader br)
            {

                return new UploadRoundTag();
            }
        }

        readonly ITlTypeTag _tag;
        SendMessageAction(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SendMessageAction(TypingTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(CancelTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(RecordVideoTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(UploadVideoTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(RecordAudioTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(UploadAudioTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(UploadPhotoTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(UploadDocumentTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(GeoLocationTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(ChooseContactTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(GamePlayTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(RecordRoundTag tag) => new SendMessageAction(tag);
        public static explicit operator SendMessageAction(UploadRoundTag tag) => new SendMessageAction(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SendMessageAction Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case TypingTag.TypeNumber: return (SendMessageAction) TypingTag.DeserializeTag(br);
                case CancelTag.TypeNumber: return (SendMessageAction) CancelTag.DeserializeTag(br);
                case RecordVideoTag.TypeNumber: return (SendMessageAction) RecordVideoTag.DeserializeTag(br);
                case UploadVideoTag.TypeNumber: return (SendMessageAction) UploadVideoTag.DeserializeTag(br);
                case RecordAudioTag.TypeNumber: return (SendMessageAction) RecordAudioTag.DeserializeTag(br);
                case UploadAudioTag.TypeNumber: return (SendMessageAction) UploadAudioTag.DeserializeTag(br);
                case UploadPhotoTag.TypeNumber: return (SendMessageAction) UploadPhotoTag.DeserializeTag(br);
                case UploadDocumentTag.TypeNumber: return (SendMessageAction) UploadDocumentTag.DeserializeTag(br);
                case GeoLocationTag.TypeNumber: return (SendMessageAction) GeoLocationTag.DeserializeTag(br);
                case ChooseContactTag.TypeNumber: return (SendMessageAction) ChooseContactTag.DeserializeTag(br);
                case GamePlayTag.TypeNumber: return (SendMessageAction) GamePlayTag.DeserializeTag(br);
                case RecordRoundTag.TypeNumber: return (SendMessageAction) RecordRoundTag.DeserializeTag(br);
                case UploadRoundTag.TypeNumber: return (SendMessageAction) UploadRoundTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { TypingTag.TypeNumber, CancelTag.TypeNumber, RecordVideoTag.TypeNumber, UploadVideoTag.TypeNumber, RecordAudioTag.TypeNumber, UploadAudioTag.TypeNumber, UploadPhotoTag.TypeNumber, UploadDocumentTag.TypeNumber, GeoLocationTag.TypeNumber, ChooseContactTag.TypeNumber, GamePlayTag.TypeNumber, RecordRoundTag.TypeNumber, UploadRoundTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<TypingTag, T> typingTag = null,
            Func<CancelTag, T> cancelTag = null,
            Func<RecordVideoTag, T> recordVideoTag = null,
            Func<UploadVideoTag, T> uploadVideoTag = null,
            Func<RecordAudioTag, T> recordAudioTag = null,
            Func<UploadAudioTag, T> uploadAudioTag = null,
            Func<UploadPhotoTag, T> uploadPhotoTag = null,
            Func<UploadDocumentTag, T> uploadDocumentTag = null,
            Func<GeoLocationTag, T> geoLocationTag = null,
            Func<ChooseContactTag, T> chooseContactTag = null,
            Func<GamePlayTag, T> gamePlayTag = null,
            Func<RecordRoundTag, T> recordRoundTag = null,
            Func<UploadRoundTag, T> uploadRoundTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case TypingTag x when typingTag != null: return typingTag(x);
                case CancelTag x when cancelTag != null: return cancelTag(x);
                case RecordVideoTag x when recordVideoTag != null: return recordVideoTag(x);
                case UploadVideoTag x when uploadVideoTag != null: return uploadVideoTag(x);
                case RecordAudioTag x when recordAudioTag != null: return recordAudioTag(x);
                case UploadAudioTag x when uploadAudioTag != null: return uploadAudioTag(x);
                case UploadPhotoTag x when uploadPhotoTag != null: return uploadPhotoTag(x);
                case UploadDocumentTag x when uploadDocumentTag != null: return uploadDocumentTag(x);
                case GeoLocationTag x when geoLocationTag != null: return geoLocationTag(x);
                case ChooseContactTag x when chooseContactTag != null: return chooseContactTag(x);
                case GamePlayTag x when gamePlayTag != null: return gamePlayTag(x);
                case RecordRoundTag x when recordRoundTag != null: return recordRoundTag(x);
                case UploadRoundTag x when uploadRoundTag != null: return uploadRoundTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<TypingTag, T> typingTag,
            Func<CancelTag, T> cancelTag,
            Func<RecordVideoTag, T> recordVideoTag,
            Func<UploadVideoTag, T> uploadVideoTag,
            Func<RecordAudioTag, T> recordAudioTag,
            Func<UploadAudioTag, T> uploadAudioTag,
            Func<UploadPhotoTag, T> uploadPhotoTag,
            Func<UploadDocumentTag, T> uploadDocumentTag,
            Func<GeoLocationTag, T> geoLocationTag,
            Func<ChooseContactTag, T> chooseContactTag,
            Func<GamePlayTag, T> gamePlayTag,
            Func<RecordRoundTag, T> recordRoundTag,
            Func<UploadRoundTag, T> uploadRoundTag
        ) => Match(
            () => throw new Exception("WTF"),
            typingTag ?? throw new ArgumentNullException(nameof(typingTag)),
            cancelTag ?? throw new ArgumentNullException(nameof(cancelTag)),
            recordVideoTag ?? throw new ArgumentNullException(nameof(recordVideoTag)),
            uploadVideoTag ?? throw new ArgumentNullException(nameof(uploadVideoTag)),
            recordAudioTag ?? throw new ArgumentNullException(nameof(recordAudioTag)),
            uploadAudioTag ?? throw new ArgumentNullException(nameof(uploadAudioTag)),
            uploadPhotoTag ?? throw new ArgumentNullException(nameof(uploadPhotoTag)),
            uploadDocumentTag ?? throw new ArgumentNullException(nameof(uploadDocumentTag)),
            geoLocationTag ?? throw new ArgumentNullException(nameof(geoLocationTag)),
            chooseContactTag ?? throw new ArgumentNullException(nameof(chooseContactTag)),
            gamePlayTag ?? throw new ArgumentNullException(nameof(gamePlayTag)),
            recordRoundTag ?? throw new ArgumentNullException(nameof(recordRoundTag)),
            uploadRoundTag ?? throw new ArgumentNullException(nameof(uploadRoundTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case TypingTag _: return 0;
                case CancelTag _: return 1;
                case RecordVideoTag _: return 2;
                case UploadVideoTag _: return 3;
                case RecordAudioTag _: return 4;
                case UploadAudioTag _: return 5;
                case UploadPhotoTag _: return 6;
                case UploadDocumentTag _: return 7;
                case GeoLocationTag _: return 8;
                case ChooseContactTag _: return 9;
                case GamePlayTag _: return 10;
                case RecordRoundTag _: return 11;
                case UploadRoundTag _: return 12;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(SendMessageAction other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is SendMessageAction x && Equals(x);
        public static bool operator ==(SendMessageAction x, SendMessageAction y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendMessageAction x, SendMessageAction y) => !(x == y);

        public int CompareTo(SendMessageAction other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SendMessageAction x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendMessageAction x, SendMessageAction y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendMessageAction x, SendMessageAction y) => x.CompareTo(y) < 0;
        public static bool operator >(SendMessageAction x, SendMessageAction y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendMessageAction x, SendMessageAction y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SendMessageAction.{_tag.GetType().Name}{_tag}";
    }
}