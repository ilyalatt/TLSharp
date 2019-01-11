using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class DeleteChatUser : ITlFunc<T.UpdatesType>, IEquatable<DeleteChatUser>, IComparable<DeleteChatUser>, IComparable
    {
        public int ChatId { get; }
        public T.InputUser UserId { get; }
        
        public DeleteChatUser(
            int chatId,
            Some<T.InputUser> userId
        ) {
            ChatId = chatId;
            UserId = userId;
        }
        
        
        (int, T.InputUser) CmpTuple =>
            (ChatId, UserId);

        public bool Equals(DeleteChatUser other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DeleteChatUser x && Equals(x);
        public static bool operator ==(DeleteChatUser x, DeleteChatUser y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeleteChatUser x, DeleteChatUser y) => !(x == y);

        public int CompareTo(DeleteChatUser other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DeleteChatUser x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeleteChatUser x, DeleteChatUser y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeleteChatUser x, DeleteChatUser y) => x.CompareTo(y) < 0;
        public static bool operator >(DeleteChatUser x, DeleteChatUser y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeleteChatUser x, DeleteChatUser y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ChatId: {ChatId}, UserId: {UserId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe0611f16);
            Write(ChatId, bw, WriteInt);
            Write(UserId, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}