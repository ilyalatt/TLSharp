using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Help
{
    public sealed class ProxyData : ITlType, IEquatable<ProxyData>, IComparable<ProxyData>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0xe09e1fb8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Expires;
            
            public EmptyTag(
                int expires
            ) {
                Expires = expires;
            }
            
            int CmpTuple =>
                Expires;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Expires: {Expires})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Expires, bw, WriteInt);
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var expires = Read(br, ReadInt);
                return new EmptyTag(expires);
            }
        }

        public sealed class PromoTag : ITlTypeTag, IEquatable<PromoTag>, IComparable<PromoTag>, IComparable
        {
            internal const uint TypeNumber = 0x2bf7ee23;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Expires;
            public readonly T.Peer Peer;
            public readonly Arr<T.Chat> Chats;
            public readonly Arr<T.User> Users;
            
            public PromoTag(
                int expires,
                Some<T.Peer> peer,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users
            ) {
                Expires = expires;
                Peer = peer;
                Chats = chats;
                Users = users;
            }
            
            (int, T.Peer, Arr<T.Chat>, Arr<T.User>) CmpTuple =>
                (Expires, Peer, Chats, Users);

            public bool Equals(PromoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PromoTag x && Equals(x);
            public static bool operator ==(PromoTag x, PromoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PromoTag x, PromoTag y) => !(x == y);

            public int CompareTo(PromoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PromoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PromoTag x, PromoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PromoTag x, PromoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PromoTag x, PromoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PromoTag x, PromoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Expires: {Expires}, Peer: {Peer}, Chats: {Chats}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Expires, bw, WriteInt);
                Write(Peer, bw, WriteSerializable);
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static PromoTag DeserializeTag(BinaryReader br)
            {
                var expires = Read(br, ReadInt);
                var peer = Read(br, T.Peer.Deserialize);
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new PromoTag(expires, peer, chats, users);
            }
        }

        readonly ITlTypeTag _tag;
        ProxyData(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ProxyData(EmptyTag tag) => new ProxyData(tag);
        public static explicit operator ProxyData(PromoTag tag) => new ProxyData(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ProxyData Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (ProxyData) EmptyTag.DeserializeTag(br);
                case PromoTag.TypeNumber: return (ProxyData) PromoTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, PromoTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<PromoTag, T> promoTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case PromoTag x when promoTag != null: return promoTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<PromoTag, T> promoTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            promoTag ?? throw new ArgumentNullException(nameof(promoTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case PromoTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ProxyData other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ProxyData x && Equals(x);
        public static bool operator ==(ProxyData x, ProxyData y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ProxyData x, ProxyData y) => !(x == y);

        public int CompareTo(ProxyData other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ProxyData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ProxyData x, ProxyData y) => x.CompareTo(y) <= 0;
        public static bool operator <(ProxyData x, ProxyData y) => x.CompareTo(y) < 0;
        public static bool operator >(ProxyData x, ProxyData y) => x.CompareTo(y) > 0;
        public static bool operator >=(ProxyData x, ProxyData y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ProxyData.{_tag.GetType().Name}{_tag}";
    }
}