using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChannelAdminLogEventAction : ITlType, IEquatable<ChannelAdminLogEventAction>, IComparable<ChannelAdminLogEventAction>, IComparable
    {
        public sealed class ChangeTitleTag : ITlTypeTag, IEquatable<ChangeTitleTag>, IComparable<ChangeTitleTag>, IComparable
        {
            internal const uint TypeNumber = 0xe6dfb825;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string PrevValue;
            public readonly string NewValue;
            
            public ChangeTitleTag(
                Some<string> prevValue,
                Some<string> newValue
            ) {
                PrevValue = prevValue;
                NewValue = newValue;
            }
            
            (string, string) CmpTuple =>
                (PrevValue, NewValue);

            public bool Equals(ChangeTitleTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChangeTitleTag x && Equals(x);
            public static bool operator ==(ChangeTitleTag x, ChangeTitleTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChangeTitleTag x, ChangeTitleTag y) => !(x == y);

            public int CompareTo(ChangeTitleTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChangeTitleTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChangeTitleTag x, ChangeTitleTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChangeTitleTag x, ChangeTitleTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChangeTitleTag x, ChangeTitleTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChangeTitleTag x, ChangeTitleTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PrevValue: {PrevValue}, NewValue: {NewValue})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PrevValue, bw, WriteString);
                Write(NewValue, bw, WriteString);
            }
            
            internal static ChangeTitleTag DeserializeTag(BinaryReader br)
            {
                var prevValue = Read(br, ReadString);
                var newValue = Read(br, ReadString);
                return new ChangeTitleTag(prevValue, newValue);
            }
        }

        public sealed class ChangeAboutTag : ITlTypeTag, IEquatable<ChangeAboutTag>, IComparable<ChangeAboutTag>, IComparable
        {
            internal const uint TypeNumber = 0x55188a2e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string PrevValue;
            public readonly string NewValue;
            
            public ChangeAboutTag(
                Some<string> prevValue,
                Some<string> newValue
            ) {
                PrevValue = prevValue;
                NewValue = newValue;
            }
            
            (string, string) CmpTuple =>
                (PrevValue, NewValue);

            public bool Equals(ChangeAboutTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChangeAboutTag x && Equals(x);
            public static bool operator ==(ChangeAboutTag x, ChangeAboutTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChangeAboutTag x, ChangeAboutTag y) => !(x == y);

            public int CompareTo(ChangeAboutTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChangeAboutTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChangeAboutTag x, ChangeAboutTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChangeAboutTag x, ChangeAboutTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChangeAboutTag x, ChangeAboutTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChangeAboutTag x, ChangeAboutTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PrevValue: {PrevValue}, NewValue: {NewValue})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PrevValue, bw, WriteString);
                Write(NewValue, bw, WriteString);
            }
            
            internal static ChangeAboutTag DeserializeTag(BinaryReader br)
            {
                var prevValue = Read(br, ReadString);
                var newValue = Read(br, ReadString);
                return new ChangeAboutTag(prevValue, newValue);
            }
        }

        public sealed class ChangeUsernameTag : ITlTypeTag, IEquatable<ChangeUsernameTag>, IComparable<ChangeUsernameTag>, IComparable
        {
            internal const uint TypeNumber = 0x6a4afc38;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string PrevValue;
            public readonly string NewValue;
            
            public ChangeUsernameTag(
                Some<string> prevValue,
                Some<string> newValue
            ) {
                PrevValue = prevValue;
                NewValue = newValue;
            }
            
            (string, string) CmpTuple =>
                (PrevValue, NewValue);

            public bool Equals(ChangeUsernameTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChangeUsernameTag x && Equals(x);
            public static bool operator ==(ChangeUsernameTag x, ChangeUsernameTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChangeUsernameTag x, ChangeUsernameTag y) => !(x == y);

            public int CompareTo(ChangeUsernameTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChangeUsernameTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChangeUsernameTag x, ChangeUsernameTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChangeUsernameTag x, ChangeUsernameTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChangeUsernameTag x, ChangeUsernameTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChangeUsernameTag x, ChangeUsernameTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PrevValue: {PrevValue}, NewValue: {NewValue})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PrevValue, bw, WriteString);
                Write(NewValue, bw, WriteString);
            }
            
            internal static ChangeUsernameTag DeserializeTag(BinaryReader br)
            {
                var prevValue = Read(br, ReadString);
                var newValue = Read(br, ReadString);
                return new ChangeUsernameTag(prevValue, newValue);
            }
        }

        public sealed class ChangePhotoTag : ITlTypeTag, IEquatable<ChangePhotoTag>, IComparable<ChangePhotoTag>, IComparable
        {
            internal const uint TypeNumber = 0xb82f55c3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.ChatPhoto PrevPhoto;
            public readonly T.ChatPhoto NewPhoto;
            
            public ChangePhotoTag(
                Some<T.ChatPhoto> prevPhoto,
                Some<T.ChatPhoto> newPhoto
            ) {
                PrevPhoto = prevPhoto;
                NewPhoto = newPhoto;
            }
            
            (T.ChatPhoto, T.ChatPhoto) CmpTuple =>
                (PrevPhoto, NewPhoto);

            public bool Equals(ChangePhotoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChangePhotoTag x && Equals(x);
            public static bool operator ==(ChangePhotoTag x, ChangePhotoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChangePhotoTag x, ChangePhotoTag y) => !(x == y);

            public int CompareTo(ChangePhotoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChangePhotoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChangePhotoTag x, ChangePhotoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChangePhotoTag x, ChangePhotoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChangePhotoTag x, ChangePhotoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChangePhotoTag x, ChangePhotoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PrevPhoto: {PrevPhoto}, NewPhoto: {NewPhoto})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PrevPhoto, bw, WriteSerializable);
                Write(NewPhoto, bw, WriteSerializable);
            }
            
            internal static ChangePhotoTag DeserializeTag(BinaryReader br)
            {
                var prevPhoto = Read(br, T.ChatPhoto.Deserialize);
                var newPhoto = Read(br, T.ChatPhoto.Deserialize);
                return new ChangePhotoTag(prevPhoto, newPhoto);
            }
        }

        public sealed class ToggleInvitesTag : ITlTypeTag, IEquatable<ToggleInvitesTag>, IComparable<ToggleInvitesTag>, IComparable
        {
            internal const uint TypeNumber = 0x1b7907ae;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool NewValue;
            
            public ToggleInvitesTag(
                bool newValue
            ) {
                NewValue = newValue;
            }
            
            bool CmpTuple =>
                NewValue;

            public bool Equals(ToggleInvitesTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ToggleInvitesTag x && Equals(x);
            public static bool operator ==(ToggleInvitesTag x, ToggleInvitesTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ToggleInvitesTag x, ToggleInvitesTag y) => !(x == y);

            public int CompareTo(ToggleInvitesTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ToggleInvitesTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ToggleInvitesTag x, ToggleInvitesTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ToggleInvitesTag x, ToggleInvitesTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ToggleInvitesTag x, ToggleInvitesTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ToggleInvitesTag x, ToggleInvitesTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(NewValue: {NewValue})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(NewValue, bw, WriteBool);
            }
            
            internal static ToggleInvitesTag DeserializeTag(BinaryReader br)
            {
                var newValue = Read(br, ReadBool);
                return new ToggleInvitesTag(newValue);
            }
        }

        public sealed class ToggleSignaturesTag : ITlTypeTag, IEquatable<ToggleSignaturesTag>, IComparable<ToggleSignaturesTag>, IComparable
        {
            internal const uint TypeNumber = 0x26ae0971;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool NewValue;
            
            public ToggleSignaturesTag(
                bool newValue
            ) {
                NewValue = newValue;
            }
            
            bool CmpTuple =>
                NewValue;

            public bool Equals(ToggleSignaturesTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ToggleSignaturesTag x && Equals(x);
            public static bool operator ==(ToggleSignaturesTag x, ToggleSignaturesTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ToggleSignaturesTag x, ToggleSignaturesTag y) => !(x == y);

            public int CompareTo(ToggleSignaturesTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ToggleSignaturesTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ToggleSignaturesTag x, ToggleSignaturesTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ToggleSignaturesTag x, ToggleSignaturesTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ToggleSignaturesTag x, ToggleSignaturesTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ToggleSignaturesTag x, ToggleSignaturesTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(NewValue: {NewValue})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(NewValue, bw, WriteBool);
            }
            
            internal static ToggleSignaturesTag DeserializeTag(BinaryReader br)
            {
                var newValue = Read(br, ReadBool);
                return new ToggleSignaturesTag(newValue);
            }
        }

        public sealed class UpdatePinnedTag : ITlTypeTag, IEquatable<UpdatePinnedTag>, IComparable<UpdatePinnedTag>, IComparable
        {
            internal const uint TypeNumber = 0xe9e82c18;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.Message Message;
            
            public UpdatePinnedTag(
                Some<T.Message> message
            ) {
                Message = message;
            }
            
            T.Message CmpTuple =>
                Message;

            public bool Equals(UpdatePinnedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UpdatePinnedTag x && Equals(x);
            public static bool operator ==(UpdatePinnedTag x, UpdatePinnedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UpdatePinnedTag x, UpdatePinnedTag y) => !(x == y);

            public int CompareTo(UpdatePinnedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UpdatePinnedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UpdatePinnedTag x, UpdatePinnedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UpdatePinnedTag x, UpdatePinnedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UpdatePinnedTag x, UpdatePinnedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UpdatePinnedTag x, UpdatePinnedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Message: {Message})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Message, bw, WriteSerializable);
            }
            
            internal static UpdatePinnedTag DeserializeTag(BinaryReader br)
            {
                var message = Read(br, T.Message.Deserialize);
                return new UpdatePinnedTag(message);
            }
        }

        public sealed class EditMessageTag : ITlTypeTag, IEquatable<EditMessageTag>, IComparable<EditMessageTag>, IComparable
        {
            internal const uint TypeNumber = 0x709b2405;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.Message PrevMessage;
            public readonly T.Message NewMessage;
            
            public EditMessageTag(
                Some<T.Message> prevMessage,
                Some<T.Message> newMessage
            ) {
                PrevMessage = prevMessage;
                NewMessage = newMessage;
            }
            
            (T.Message, T.Message) CmpTuple =>
                (PrevMessage, NewMessage);

            public bool Equals(EditMessageTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EditMessageTag x && Equals(x);
            public static bool operator ==(EditMessageTag x, EditMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EditMessageTag x, EditMessageTag y) => !(x == y);

            public int CompareTo(EditMessageTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EditMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EditMessageTag x, EditMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EditMessageTag x, EditMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EditMessageTag x, EditMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EditMessageTag x, EditMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PrevMessage: {PrevMessage}, NewMessage: {NewMessage})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PrevMessage, bw, WriteSerializable);
                Write(NewMessage, bw, WriteSerializable);
            }
            
            internal static EditMessageTag DeserializeTag(BinaryReader br)
            {
                var prevMessage = Read(br, T.Message.Deserialize);
                var newMessage = Read(br, T.Message.Deserialize);
                return new EditMessageTag(prevMessage, newMessage);
            }
        }

        public sealed class DeleteMessageTag : ITlTypeTag, IEquatable<DeleteMessageTag>, IComparable<DeleteMessageTag>, IComparable
        {
            internal const uint TypeNumber = 0x42e047bb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.Message Message;
            
            public DeleteMessageTag(
                Some<T.Message> message
            ) {
                Message = message;
            }
            
            T.Message CmpTuple =>
                Message;

            public bool Equals(DeleteMessageTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DeleteMessageTag x && Equals(x);
            public static bool operator ==(DeleteMessageTag x, DeleteMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DeleteMessageTag x, DeleteMessageTag y) => !(x == y);

            public int CompareTo(DeleteMessageTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DeleteMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DeleteMessageTag x, DeleteMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DeleteMessageTag x, DeleteMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DeleteMessageTag x, DeleteMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DeleteMessageTag x, DeleteMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Message: {Message})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Message, bw, WriteSerializable);
            }
            
            internal static DeleteMessageTag DeserializeTag(BinaryReader br)
            {
                var message = Read(br, T.Message.Deserialize);
                return new DeleteMessageTag(message);
            }
        }

        public sealed class ParticipantJoinTag : ITlTypeTag, IEquatable<ParticipantJoinTag>, IComparable<ParticipantJoinTag>, IComparable
        {
            internal const uint TypeNumber = 0x183040d3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ParticipantJoinTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ParticipantJoinTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ParticipantJoinTag x && Equals(x);
            public static bool operator ==(ParticipantJoinTag x, ParticipantJoinTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ParticipantJoinTag x, ParticipantJoinTag y) => !(x == y);

            public int CompareTo(ParticipantJoinTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ParticipantJoinTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ParticipantJoinTag x, ParticipantJoinTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ParticipantJoinTag x, ParticipantJoinTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ParticipantJoinTag x, ParticipantJoinTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ParticipantJoinTag x, ParticipantJoinTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ParticipantJoinTag DeserializeTag(BinaryReader br)
            {

                return new ParticipantJoinTag();
            }
        }

        public sealed class ParticipantLeaveTag : ITlTypeTag, IEquatable<ParticipantLeaveTag>, IComparable<ParticipantLeaveTag>, IComparable
        {
            internal const uint TypeNumber = 0xf89777f2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ParticipantLeaveTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ParticipantLeaveTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ParticipantLeaveTag x && Equals(x);
            public static bool operator ==(ParticipantLeaveTag x, ParticipantLeaveTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ParticipantLeaveTag x, ParticipantLeaveTag y) => !(x == y);

            public int CompareTo(ParticipantLeaveTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ParticipantLeaveTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ParticipantLeaveTag x, ParticipantLeaveTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ParticipantLeaveTag x, ParticipantLeaveTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ParticipantLeaveTag x, ParticipantLeaveTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ParticipantLeaveTag x, ParticipantLeaveTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ParticipantLeaveTag DeserializeTag(BinaryReader br)
            {

                return new ParticipantLeaveTag();
            }
        }

        public sealed class ParticipantInviteTag : ITlTypeTag, IEquatable<ParticipantInviteTag>, IComparable<ParticipantInviteTag>, IComparable
        {
            internal const uint TypeNumber = 0xe31c34d8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.ChannelParticipant Participant;
            
            public ParticipantInviteTag(
                Some<T.ChannelParticipant> participant
            ) {
                Participant = participant;
            }
            
            T.ChannelParticipant CmpTuple =>
                Participant;

            public bool Equals(ParticipantInviteTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ParticipantInviteTag x && Equals(x);
            public static bool operator ==(ParticipantInviteTag x, ParticipantInviteTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ParticipantInviteTag x, ParticipantInviteTag y) => !(x == y);

            public int CompareTo(ParticipantInviteTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ParticipantInviteTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ParticipantInviteTag x, ParticipantInviteTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ParticipantInviteTag x, ParticipantInviteTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ParticipantInviteTag x, ParticipantInviteTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ParticipantInviteTag x, ParticipantInviteTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Participant: {Participant})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Participant, bw, WriteSerializable);
            }
            
            internal static ParticipantInviteTag DeserializeTag(BinaryReader br)
            {
                var participant = Read(br, T.ChannelParticipant.Deserialize);
                return new ParticipantInviteTag(participant);
            }
        }

        public sealed class ParticipantToggleBanTag : ITlTypeTag, IEquatable<ParticipantToggleBanTag>, IComparable<ParticipantToggleBanTag>, IComparable
        {
            internal const uint TypeNumber = 0xe6d83d7e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.ChannelParticipant PrevParticipant;
            public readonly T.ChannelParticipant NewParticipant;
            
            public ParticipantToggleBanTag(
                Some<T.ChannelParticipant> prevParticipant,
                Some<T.ChannelParticipant> newParticipant
            ) {
                PrevParticipant = prevParticipant;
                NewParticipant = newParticipant;
            }
            
            (T.ChannelParticipant, T.ChannelParticipant) CmpTuple =>
                (PrevParticipant, NewParticipant);

            public bool Equals(ParticipantToggleBanTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ParticipantToggleBanTag x && Equals(x);
            public static bool operator ==(ParticipantToggleBanTag x, ParticipantToggleBanTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ParticipantToggleBanTag x, ParticipantToggleBanTag y) => !(x == y);

            public int CompareTo(ParticipantToggleBanTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ParticipantToggleBanTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ParticipantToggleBanTag x, ParticipantToggleBanTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ParticipantToggleBanTag x, ParticipantToggleBanTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ParticipantToggleBanTag x, ParticipantToggleBanTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ParticipantToggleBanTag x, ParticipantToggleBanTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PrevParticipant: {PrevParticipant}, NewParticipant: {NewParticipant})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PrevParticipant, bw, WriteSerializable);
                Write(NewParticipant, bw, WriteSerializable);
            }
            
            internal static ParticipantToggleBanTag DeserializeTag(BinaryReader br)
            {
                var prevParticipant = Read(br, T.ChannelParticipant.Deserialize);
                var newParticipant = Read(br, T.ChannelParticipant.Deserialize);
                return new ParticipantToggleBanTag(prevParticipant, newParticipant);
            }
        }

        public sealed class ParticipantToggleAdminTag : ITlTypeTag, IEquatable<ParticipantToggleAdminTag>, IComparable<ParticipantToggleAdminTag>, IComparable
        {
            internal const uint TypeNumber = 0xd5676710;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.ChannelParticipant PrevParticipant;
            public readonly T.ChannelParticipant NewParticipant;
            
            public ParticipantToggleAdminTag(
                Some<T.ChannelParticipant> prevParticipant,
                Some<T.ChannelParticipant> newParticipant
            ) {
                PrevParticipant = prevParticipant;
                NewParticipant = newParticipant;
            }
            
            (T.ChannelParticipant, T.ChannelParticipant) CmpTuple =>
                (PrevParticipant, NewParticipant);

            public bool Equals(ParticipantToggleAdminTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ParticipantToggleAdminTag x && Equals(x);
            public static bool operator ==(ParticipantToggleAdminTag x, ParticipantToggleAdminTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ParticipantToggleAdminTag x, ParticipantToggleAdminTag y) => !(x == y);

            public int CompareTo(ParticipantToggleAdminTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ParticipantToggleAdminTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ParticipantToggleAdminTag x, ParticipantToggleAdminTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ParticipantToggleAdminTag x, ParticipantToggleAdminTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ParticipantToggleAdminTag x, ParticipantToggleAdminTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ParticipantToggleAdminTag x, ParticipantToggleAdminTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PrevParticipant: {PrevParticipant}, NewParticipant: {NewParticipant})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PrevParticipant, bw, WriteSerializable);
                Write(NewParticipant, bw, WriteSerializable);
            }
            
            internal static ParticipantToggleAdminTag DeserializeTag(BinaryReader br)
            {
                var prevParticipant = Read(br, T.ChannelParticipant.Deserialize);
                var newParticipant = Read(br, T.ChannelParticipant.Deserialize);
                return new ParticipantToggleAdminTag(prevParticipant, newParticipant);
            }
        }

        public sealed class ChangeStickerSetTag : ITlTypeTag, IEquatable<ChangeStickerSetTag>, IComparable<ChangeStickerSetTag>, IComparable
        {
            internal const uint TypeNumber = 0xb1c3caa7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputStickerSet PrevStickerset;
            public readonly T.InputStickerSet NewStickerset;
            
            public ChangeStickerSetTag(
                Some<T.InputStickerSet> prevStickerset,
                Some<T.InputStickerSet> newStickerset
            ) {
                PrevStickerset = prevStickerset;
                NewStickerset = newStickerset;
            }
            
            (T.InputStickerSet, T.InputStickerSet) CmpTuple =>
                (PrevStickerset, NewStickerset);

            public bool Equals(ChangeStickerSetTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChangeStickerSetTag x && Equals(x);
            public static bool operator ==(ChangeStickerSetTag x, ChangeStickerSetTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChangeStickerSetTag x, ChangeStickerSetTag y) => !(x == y);

            public int CompareTo(ChangeStickerSetTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChangeStickerSetTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChangeStickerSetTag x, ChangeStickerSetTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChangeStickerSetTag x, ChangeStickerSetTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChangeStickerSetTag x, ChangeStickerSetTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChangeStickerSetTag x, ChangeStickerSetTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PrevStickerset: {PrevStickerset}, NewStickerset: {NewStickerset})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PrevStickerset, bw, WriteSerializable);
                Write(NewStickerset, bw, WriteSerializable);
            }
            
            internal static ChangeStickerSetTag DeserializeTag(BinaryReader br)
            {
                var prevStickerset = Read(br, T.InputStickerSet.Deserialize);
                var newStickerset = Read(br, T.InputStickerSet.Deserialize);
                return new ChangeStickerSetTag(prevStickerset, newStickerset);
            }
        }

        public sealed class TogglePreHistoryHiddenTag : ITlTypeTag, IEquatable<TogglePreHistoryHiddenTag>, IComparable<TogglePreHistoryHiddenTag>, IComparable
        {
            internal const uint TypeNumber = 0x5f5c95f1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool NewValue;
            
            public TogglePreHistoryHiddenTag(
                bool newValue
            ) {
                NewValue = newValue;
            }
            
            bool CmpTuple =>
                NewValue;

            public bool Equals(TogglePreHistoryHiddenTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is TogglePreHistoryHiddenTag x && Equals(x);
            public static bool operator ==(TogglePreHistoryHiddenTag x, TogglePreHistoryHiddenTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TogglePreHistoryHiddenTag x, TogglePreHistoryHiddenTag y) => !(x == y);

            public int CompareTo(TogglePreHistoryHiddenTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is TogglePreHistoryHiddenTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TogglePreHistoryHiddenTag x, TogglePreHistoryHiddenTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TogglePreHistoryHiddenTag x, TogglePreHistoryHiddenTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TogglePreHistoryHiddenTag x, TogglePreHistoryHiddenTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TogglePreHistoryHiddenTag x, TogglePreHistoryHiddenTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(NewValue: {NewValue})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(NewValue, bw, WriteBool);
            }
            
            internal static TogglePreHistoryHiddenTag DeserializeTag(BinaryReader br)
            {
                var newValue = Read(br, ReadBool);
                return new TogglePreHistoryHiddenTag(newValue);
            }
        }

        readonly ITlTypeTag _tag;
        ChannelAdminLogEventAction(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelAdminLogEventAction(ChangeTitleTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ChangeAboutTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ChangeUsernameTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ChangePhotoTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ToggleInvitesTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ToggleSignaturesTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(UpdatePinnedTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(EditMessageTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(DeleteMessageTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ParticipantJoinTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ParticipantLeaveTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ParticipantInviteTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ParticipantToggleBanTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ParticipantToggleAdminTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(ChangeStickerSetTag tag) => new ChannelAdminLogEventAction(tag);
        public static explicit operator ChannelAdminLogEventAction(TogglePreHistoryHiddenTag tag) => new ChannelAdminLogEventAction(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelAdminLogEventAction Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case ChangeTitleTag.TypeNumber: return (ChannelAdminLogEventAction) ChangeTitleTag.DeserializeTag(br);
                case ChangeAboutTag.TypeNumber: return (ChannelAdminLogEventAction) ChangeAboutTag.DeserializeTag(br);
                case ChangeUsernameTag.TypeNumber: return (ChannelAdminLogEventAction) ChangeUsernameTag.DeserializeTag(br);
                case ChangePhotoTag.TypeNumber: return (ChannelAdminLogEventAction) ChangePhotoTag.DeserializeTag(br);
                case ToggleInvitesTag.TypeNumber: return (ChannelAdminLogEventAction) ToggleInvitesTag.DeserializeTag(br);
                case ToggleSignaturesTag.TypeNumber: return (ChannelAdminLogEventAction) ToggleSignaturesTag.DeserializeTag(br);
                case UpdatePinnedTag.TypeNumber: return (ChannelAdminLogEventAction) UpdatePinnedTag.DeserializeTag(br);
                case EditMessageTag.TypeNumber: return (ChannelAdminLogEventAction) EditMessageTag.DeserializeTag(br);
                case DeleteMessageTag.TypeNumber: return (ChannelAdminLogEventAction) DeleteMessageTag.DeserializeTag(br);
                case ParticipantJoinTag.TypeNumber: return (ChannelAdminLogEventAction) ParticipantJoinTag.DeserializeTag(br);
                case ParticipantLeaveTag.TypeNumber: return (ChannelAdminLogEventAction) ParticipantLeaveTag.DeserializeTag(br);
                case ParticipantInviteTag.TypeNumber: return (ChannelAdminLogEventAction) ParticipantInviteTag.DeserializeTag(br);
                case ParticipantToggleBanTag.TypeNumber: return (ChannelAdminLogEventAction) ParticipantToggleBanTag.DeserializeTag(br);
                case ParticipantToggleAdminTag.TypeNumber: return (ChannelAdminLogEventAction) ParticipantToggleAdminTag.DeserializeTag(br);
                case ChangeStickerSetTag.TypeNumber: return (ChannelAdminLogEventAction) ChangeStickerSetTag.DeserializeTag(br);
                case TogglePreHistoryHiddenTag.TypeNumber: return (ChannelAdminLogEventAction) TogglePreHistoryHiddenTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { ChangeTitleTag.TypeNumber, ChangeAboutTag.TypeNumber, ChangeUsernameTag.TypeNumber, ChangePhotoTag.TypeNumber, ToggleInvitesTag.TypeNumber, ToggleSignaturesTag.TypeNumber, UpdatePinnedTag.TypeNumber, EditMessageTag.TypeNumber, DeleteMessageTag.TypeNumber, ParticipantJoinTag.TypeNumber, ParticipantLeaveTag.TypeNumber, ParticipantInviteTag.TypeNumber, ParticipantToggleBanTag.TypeNumber, ParticipantToggleAdminTag.TypeNumber, ChangeStickerSetTag.TypeNumber, TogglePreHistoryHiddenTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<ChangeTitleTag, T> changeTitleTag = null,
            Func<ChangeAboutTag, T> changeAboutTag = null,
            Func<ChangeUsernameTag, T> changeUsernameTag = null,
            Func<ChangePhotoTag, T> changePhotoTag = null,
            Func<ToggleInvitesTag, T> toggleInvitesTag = null,
            Func<ToggleSignaturesTag, T> toggleSignaturesTag = null,
            Func<UpdatePinnedTag, T> updatePinnedTag = null,
            Func<EditMessageTag, T> editMessageTag = null,
            Func<DeleteMessageTag, T> deleteMessageTag = null,
            Func<ParticipantJoinTag, T> participantJoinTag = null,
            Func<ParticipantLeaveTag, T> participantLeaveTag = null,
            Func<ParticipantInviteTag, T> participantInviteTag = null,
            Func<ParticipantToggleBanTag, T> participantToggleBanTag = null,
            Func<ParticipantToggleAdminTag, T> participantToggleAdminTag = null,
            Func<ChangeStickerSetTag, T> changeStickerSetTag = null,
            Func<TogglePreHistoryHiddenTag, T> togglePreHistoryHiddenTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case ChangeTitleTag x when changeTitleTag != null: return changeTitleTag(x);
                case ChangeAboutTag x when changeAboutTag != null: return changeAboutTag(x);
                case ChangeUsernameTag x when changeUsernameTag != null: return changeUsernameTag(x);
                case ChangePhotoTag x when changePhotoTag != null: return changePhotoTag(x);
                case ToggleInvitesTag x when toggleInvitesTag != null: return toggleInvitesTag(x);
                case ToggleSignaturesTag x when toggleSignaturesTag != null: return toggleSignaturesTag(x);
                case UpdatePinnedTag x when updatePinnedTag != null: return updatePinnedTag(x);
                case EditMessageTag x when editMessageTag != null: return editMessageTag(x);
                case DeleteMessageTag x when deleteMessageTag != null: return deleteMessageTag(x);
                case ParticipantJoinTag x when participantJoinTag != null: return participantJoinTag(x);
                case ParticipantLeaveTag x when participantLeaveTag != null: return participantLeaveTag(x);
                case ParticipantInviteTag x when participantInviteTag != null: return participantInviteTag(x);
                case ParticipantToggleBanTag x when participantToggleBanTag != null: return participantToggleBanTag(x);
                case ParticipantToggleAdminTag x when participantToggleAdminTag != null: return participantToggleAdminTag(x);
                case ChangeStickerSetTag x when changeStickerSetTag != null: return changeStickerSetTag(x);
                case TogglePreHistoryHiddenTag x when togglePreHistoryHiddenTag != null: return togglePreHistoryHiddenTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<ChangeTitleTag, T> changeTitleTag,
            Func<ChangeAboutTag, T> changeAboutTag,
            Func<ChangeUsernameTag, T> changeUsernameTag,
            Func<ChangePhotoTag, T> changePhotoTag,
            Func<ToggleInvitesTag, T> toggleInvitesTag,
            Func<ToggleSignaturesTag, T> toggleSignaturesTag,
            Func<UpdatePinnedTag, T> updatePinnedTag,
            Func<EditMessageTag, T> editMessageTag,
            Func<DeleteMessageTag, T> deleteMessageTag,
            Func<ParticipantJoinTag, T> participantJoinTag,
            Func<ParticipantLeaveTag, T> participantLeaveTag,
            Func<ParticipantInviteTag, T> participantInviteTag,
            Func<ParticipantToggleBanTag, T> participantToggleBanTag,
            Func<ParticipantToggleAdminTag, T> participantToggleAdminTag,
            Func<ChangeStickerSetTag, T> changeStickerSetTag,
            Func<TogglePreHistoryHiddenTag, T> togglePreHistoryHiddenTag
        ) => Match(
            () => throw new Exception("WTF"),
            changeTitleTag ?? throw new ArgumentNullException(nameof(changeTitleTag)),
            changeAboutTag ?? throw new ArgumentNullException(nameof(changeAboutTag)),
            changeUsernameTag ?? throw new ArgumentNullException(nameof(changeUsernameTag)),
            changePhotoTag ?? throw new ArgumentNullException(nameof(changePhotoTag)),
            toggleInvitesTag ?? throw new ArgumentNullException(nameof(toggleInvitesTag)),
            toggleSignaturesTag ?? throw new ArgumentNullException(nameof(toggleSignaturesTag)),
            updatePinnedTag ?? throw new ArgumentNullException(nameof(updatePinnedTag)),
            editMessageTag ?? throw new ArgumentNullException(nameof(editMessageTag)),
            deleteMessageTag ?? throw new ArgumentNullException(nameof(deleteMessageTag)),
            participantJoinTag ?? throw new ArgumentNullException(nameof(participantJoinTag)),
            participantLeaveTag ?? throw new ArgumentNullException(nameof(participantLeaveTag)),
            participantInviteTag ?? throw new ArgumentNullException(nameof(participantInviteTag)),
            participantToggleBanTag ?? throw new ArgumentNullException(nameof(participantToggleBanTag)),
            participantToggleAdminTag ?? throw new ArgumentNullException(nameof(participantToggleAdminTag)),
            changeStickerSetTag ?? throw new ArgumentNullException(nameof(changeStickerSetTag)),
            togglePreHistoryHiddenTag ?? throw new ArgumentNullException(nameof(togglePreHistoryHiddenTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case ChangeTitleTag _: return 0;
                case ChangeAboutTag _: return 1;
                case ChangeUsernameTag _: return 2;
                case ChangePhotoTag _: return 3;
                case ToggleInvitesTag _: return 4;
                case ToggleSignaturesTag _: return 5;
                case UpdatePinnedTag _: return 6;
                case EditMessageTag _: return 7;
                case DeleteMessageTag _: return 8;
                case ParticipantJoinTag _: return 9;
                case ParticipantLeaveTag _: return 10;
                case ParticipantInviteTag _: return 11;
                case ParticipantToggleBanTag _: return 12;
                case ParticipantToggleAdminTag _: return 13;
                case ChangeStickerSetTag _: return 14;
                case TogglePreHistoryHiddenTag _: return 15;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ChannelAdminLogEventAction other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChannelAdminLogEventAction x && Equals(x);
        public static bool operator ==(ChannelAdminLogEventAction x, ChannelAdminLogEventAction y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelAdminLogEventAction x, ChannelAdminLogEventAction y) => !(x == y);

        public int CompareTo(ChannelAdminLogEventAction other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChannelAdminLogEventAction x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelAdminLogEventAction x, ChannelAdminLogEventAction y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelAdminLogEventAction x, ChannelAdminLogEventAction y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelAdminLogEventAction x, ChannelAdminLogEventAction y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelAdminLogEventAction x, ChannelAdminLogEventAction y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelAdminLogEventAction.{_tag.GetType().Name}{_tag}";
    }
}