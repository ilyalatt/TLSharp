using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetCommonChats : ITlFunc<T.Messages.Chats>, IEquatable<GetCommonChats>, IComparable<GetCommonChats>, IComparable
    {
        public T.InputUser UserId { get; }
        public int MaxId { get; }
        public int Limit { get; }
        
        public GetCommonChats(
            Some<T.InputUser> userId,
            int maxId,
            int limit
        ) {
            UserId = userId;
            MaxId = maxId;
            Limit = limit;
        }
        
        
        (T.InputUser, int, int) CmpTuple =>
            (UserId, MaxId, Limit);

        public bool Equals(GetCommonChats other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetCommonChats x && Equals(x);
        public static bool operator ==(GetCommonChats x, GetCommonChats y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetCommonChats x, GetCommonChats y) => !(x == y);

        public int CompareTo(GetCommonChats other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetCommonChats x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetCommonChats x, GetCommonChats y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetCommonChats x, GetCommonChats y) => x.CompareTo(y) < 0;
        public static bool operator >(GetCommonChats x, GetCommonChats y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetCommonChats x, GetCommonChats y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(UserId: {UserId}, MaxId: {MaxId}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0d0a48c4);
            Write(UserId, bw, WriteSerializable);
            Write(MaxId, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Messages.Chats ITlFunc<T.Messages.Chats>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Chats.Deserialize);
    }
}