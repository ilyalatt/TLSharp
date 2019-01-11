using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Updates
{
    public sealed class Difference : ITlType, IEquatable<Difference>, IComparable<Difference>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x5d75a138;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Date { get; }
            public int Seq { get; }
            
            public EmptyTag(
                int date,
                int seq
            ) {
                Date = date;
                Seq = seq;
            }
            
            (int, int) CmpTuple =>
                (Date, Seq);

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Date: {Date}, Seq: {Seq})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Date, bw, WriteInt);
                Write(Seq, bw, WriteInt);
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var date = Read(br, ReadInt);
                var seq = Read(br, ReadInt);
                return new EmptyTag(date, seq);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x00f49ca0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.Message> NewMessages { get; }
            public Arr<T.EncryptedMessage> NewEncryptedMessages { get; }
            public Arr<T.Update> OtherUpdates { get; }
            public Arr<T.Chat> Chats { get; }
            public Arr<T.User> Users { get; }
            public T.Updates.State State { get; }
            
            public Tag(
                Some<Arr<T.Message>> newMessages,
                Some<Arr<T.EncryptedMessage>> newEncryptedMessages,
                Some<Arr<T.Update>> otherUpdates,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users,
                Some<T.Updates.State> state
            ) {
                NewMessages = newMessages;
                NewEncryptedMessages = newEncryptedMessages;
                OtherUpdates = otherUpdates;
                Chats = chats;
                Users = users;
                State = state;
            }
            
            (Arr<T.Message>, Arr<T.EncryptedMessage>, Arr<T.Update>, Arr<T.Chat>, Arr<T.User>, T.Updates.State) CmpTuple =>
                (NewMessages, NewEncryptedMessages, OtherUpdates, Chats, Users, State);

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

            public override string ToString() => $"(NewMessages: {NewMessages}, NewEncryptedMessages: {NewEncryptedMessages}, OtherUpdates: {OtherUpdates}, Chats: {Chats}, Users: {Users}, State: {State})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(NewMessages, bw, WriteVector<T.Message>(WriteSerializable));
                Write(NewEncryptedMessages, bw, WriteVector<T.EncryptedMessage>(WriteSerializable));
                Write(OtherUpdates, bw, WriteVector<T.Update>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
                Write(State, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var newMessages = Read(br, ReadVector(T.Message.Deserialize));
                var newEncryptedMessages = Read(br, ReadVector(T.EncryptedMessage.Deserialize));
                var otherUpdates = Read(br, ReadVector(T.Update.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                var state = Read(br, T.Updates.State.Deserialize);
                return new Tag(newMessages, newEncryptedMessages, otherUpdates, chats, users, state);
            }
        }

        public sealed class SliceTag : ITlTypeTag, IEquatable<SliceTag>, IComparable<SliceTag>, IComparable
        {
            internal const uint TypeNumber = 0xa8fb1981;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.Message> NewMessages { get; }
            public Arr<T.EncryptedMessage> NewEncryptedMessages { get; }
            public Arr<T.Update> OtherUpdates { get; }
            public Arr<T.Chat> Chats { get; }
            public Arr<T.User> Users { get; }
            public T.Updates.State IntermediateState { get; }
            
            public SliceTag(
                Some<Arr<T.Message>> newMessages,
                Some<Arr<T.EncryptedMessage>> newEncryptedMessages,
                Some<Arr<T.Update>> otherUpdates,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users,
                Some<T.Updates.State> intermediateState
            ) {
                NewMessages = newMessages;
                NewEncryptedMessages = newEncryptedMessages;
                OtherUpdates = otherUpdates;
                Chats = chats;
                Users = users;
                IntermediateState = intermediateState;
            }
            
            (Arr<T.Message>, Arr<T.EncryptedMessage>, Arr<T.Update>, Arr<T.Chat>, Arr<T.User>, T.Updates.State) CmpTuple =>
                (NewMessages, NewEncryptedMessages, OtherUpdates, Chats, Users, IntermediateState);

            public bool Equals(SliceTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is SliceTag x && Equals(x);
            public static bool operator ==(SliceTag x, SliceTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SliceTag x, SliceTag y) => !(x == y);

            public int CompareTo(SliceTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is SliceTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SliceTag x, SliceTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SliceTag x, SliceTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SliceTag x, SliceTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SliceTag x, SliceTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(NewMessages: {NewMessages}, NewEncryptedMessages: {NewEncryptedMessages}, OtherUpdates: {OtherUpdates}, Chats: {Chats}, Users: {Users}, IntermediateState: {IntermediateState})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(NewMessages, bw, WriteVector<T.Message>(WriteSerializable));
                Write(NewEncryptedMessages, bw, WriteVector<T.EncryptedMessage>(WriteSerializable));
                Write(OtherUpdates, bw, WriteVector<T.Update>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
                Write(IntermediateState, bw, WriteSerializable);
            }
            
            internal static SliceTag DeserializeTag(BinaryReader br)
            {
                var newMessages = Read(br, ReadVector(T.Message.Deserialize));
                var newEncryptedMessages = Read(br, ReadVector(T.EncryptedMessage.Deserialize));
                var otherUpdates = Read(br, ReadVector(T.Update.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                var intermediateState = Read(br, T.Updates.State.Deserialize);
                return new SliceTag(newMessages, newEncryptedMessages, otherUpdates, chats, users, intermediateState);
            }
        }

        public sealed class TooLongTag : ITlTypeTag, IEquatable<TooLongTag>, IComparable<TooLongTag>, IComparable
        {
            internal const uint TypeNumber = 0x4afe8f6d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Pts { get; }
            
            public TooLongTag(
                int pts
            ) {
                Pts = pts;
            }
            
            int CmpTuple =>
                Pts;

            public bool Equals(TooLongTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is TooLongTag x && Equals(x);
            public static bool operator ==(TooLongTag x, TooLongTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TooLongTag x, TooLongTag y) => !(x == y);

            public int CompareTo(TooLongTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is TooLongTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TooLongTag x, TooLongTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TooLongTag x, TooLongTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TooLongTag x, TooLongTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TooLongTag x, TooLongTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Pts: {Pts})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Pts, bw, WriteInt);
            }
            
            internal static TooLongTag DeserializeTag(BinaryReader br)
            {
                var pts = Read(br, ReadInt);
                return new TooLongTag(pts);
            }
        }

        readonly ITlTypeTag _tag;
        Difference(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Difference(EmptyTag tag) => new Difference(tag);
        public static explicit operator Difference(Tag tag) => new Difference(tag);
        public static explicit operator Difference(SliceTag tag) => new Difference(tag);
        public static explicit operator Difference(TooLongTag tag) => new Difference(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Difference Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (Difference) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (Difference) Tag.DeserializeTag(br);
                case SliceTag.TypeNumber: return (Difference) SliceTag.DeserializeTag(br);
                case TooLongTag.TypeNumber: return (Difference) TooLongTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, Tag.TypeNumber, SliceTag.TypeNumber, TooLongTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null,
            Func<SliceTag, T> sliceTag = null,
            Func<TooLongTag, T> tooLongTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                case SliceTag x when sliceTag != null: return sliceTag(x);
                case TooLongTag x when tooLongTag != null: return tooLongTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag,
            Func<SliceTag, T> sliceTag,
            Func<TooLongTag, T> tooLongTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            sliceTag ?? throw new ArgumentNullException(nameof(sliceTag)),
            tooLongTag ?? throw new ArgumentNullException(nameof(tooLongTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                case SliceTag _: return 2;
                case TooLongTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(Difference other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is Difference x && Equals(x);
        public static bool operator ==(Difference x, Difference y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Difference x, Difference y) => !(x == y);

        public int CompareTo(Difference other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Difference x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Difference x, Difference y) => x.CompareTo(y) <= 0;
        public static bool operator <(Difference x, Difference y) => x.CompareTo(y) < 0;
        public static bool operator >(Difference x, Difference y) => x.CompareTo(y) > 0;
        public static bool operator >=(Difference x, Difference y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Difference.{_tag.GetType().Name}{_tag}";
    }
}