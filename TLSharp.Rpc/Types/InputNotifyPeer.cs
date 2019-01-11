using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputNotifyPeer : ITlType, IEquatable<InputNotifyPeer>, IComparable<InputNotifyPeer>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xb8bc5b0c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputPeer Peer;
            
            public Tag(
                Some<T.InputPeer> peer
            ) {
                Peer = peer;
            }
            
            T.InputPeer CmpTuple =>
                Peer;

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

            public override string ToString() => $"(Peer: {Peer})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Peer, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var peer = Read(br, T.InputPeer.Deserialize);
                return new Tag(peer);
            }
        }

        public sealed class UsersTag : ITlTypeTag, IEquatable<UsersTag>, IComparable<UsersTag>, IComparable
        {
            internal const uint TypeNumber = 0x193b4417;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public UsersTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(UsersTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UsersTag x && Equals(x);
            public static bool operator ==(UsersTag x, UsersTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UsersTag x, UsersTag y) => !(x == y);

            public int CompareTo(UsersTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UsersTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UsersTag x, UsersTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UsersTag x, UsersTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UsersTag x, UsersTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UsersTag x, UsersTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static UsersTag DeserializeTag(BinaryReader br)
            {

                return new UsersTag();
            }
        }

        public sealed class ChatsTag : ITlTypeTag, IEquatable<ChatsTag>, IComparable<ChatsTag>, IComparable
        {
            internal const uint TypeNumber = 0x4a95e84e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ChatsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ChatsTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatsTag x && Equals(x);
            public static bool operator ==(ChatsTag x, ChatsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatsTag x, ChatsTag y) => !(x == y);

            public int CompareTo(ChatsTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatsTag x, ChatsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatsTag x, ChatsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatsTag x, ChatsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatsTag x, ChatsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChatsTag DeserializeTag(BinaryReader br)
            {

                return new ChatsTag();
            }
        }

        public sealed class AllTag : ITlTypeTag, IEquatable<AllTag>, IComparable<AllTag>, IComparable
        {
            internal const uint TypeNumber = 0xa429b886;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public AllTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(AllTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AllTag x && Equals(x);
            public static bool operator ==(AllTag x, AllTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AllTag x, AllTag y) => !(x == y);

            public int CompareTo(AllTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AllTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AllTag x, AllTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AllTag x, AllTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AllTag x, AllTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AllTag x, AllTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static AllTag DeserializeTag(BinaryReader br)
            {

                return new AllTag();
            }
        }

        readonly ITlTypeTag _tag;
        InputNotifyPeer(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputNotifyPeer(Tag tag) => new InputNotifyPeer(tag);
        public static explicit operator InputNotifyPeer(UsersTag tag) => new InputNotifyPeer(tag);
        public static explicit operator InputNotifyPeer(ChatsTag tag) => new InputNotifyPeer(tag);
        public static explicit operator InputNotifyPeer(AllTag tag) => new InputNotifyPeer(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputNotifyPeer Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputNotifyPeer) Tag.DeserializeTag(br);
                case UsersTag.TypeNumber: return (InputNotifyPeer) UsersTag.DeserializeTag(br);
                case ChatsTag.TypeNumber: return (InputNotifyPeer) ChatsTag.DeserializeTag(br);
                case AllTag.TypeNumber: return (InputNotifyPeer) AllTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, UsersTag.TypeNumber, ChatsTag.TypeNumber, AllTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<UsersTag, T> usersTag = null,
            Func<ChatsTag, T> chatsTag = null,
            Func<AllTag, T> allTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case UsersTag x when usersTag != null: return usersTag(x);
                case ChatsTag x when chatsTag != null: return chatsTag(x);
                case AllTag x when allTag != null: return allTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<UsersTag, T> usersTag,
            Func<ChatsTag, T> chatsTag,
            Func<AllTag, T> allTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            usersTag ?? throw new ArgumentNullException(nameof(usersTag)),
            chatsTag ?? throw new ArgumentNullException(nameof(chatsTag)),
            allTag ?? throw new ArgumentNullException(nameof(allTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case UsersTag _: return 1;
                case ChatsTag _: return 2;
                case AllTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputNotifyPeer other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputNotifyPeer x && Equals(x);
        public static bool operator ==(InputNotifyPeer x, InputNotifyPeer y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputNotifyPeer x, InputNotifyPeer y) => !(x == y);

        public int CompareTo(InputNotifyPeer other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputNotifyPeer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputNotifyPeer x, InputNotifyPeer y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputNotifyPeer x, InputNotifyPeer y) => x.CompareTo(y) < 0;
        public static bool operator >(InputNotifyPeer x, InputNotifyPeer y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputNotifyPeer x, InputNotifyPeer y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputNotifyPeer.{_tag.GetType().Name}{_tag}";
    }
}