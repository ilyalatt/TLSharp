using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class EditChatAdmin : ITlFunc<bool>, IEquatable<EditChatAdmin>, IComparable<EditChatAdmin>, IComparable
    {
        public int ChatId { get; }
        public T.InputUser UserId { get; }
        public bool IsAdmin { get; }
        
        public EditChatAdmin(
            int chatId,
            Some<T.InputUser> userId,
            bool isAdmin
        ) {
            ChatId = chatId;
            UserId = userId;
            IsAdmin = isAdmin;
        }
        
        
        (int, T.InputUser, bool) CmpTuple =>
            (ChatId, UserId, IsAdmin);

        public bool Equals(EditChatAdmin other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is EditChatAdmin x && Equals(x);
        public static bool operator ==(EditChatAdmin x, EditChatAdmin y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditChatAdmin x, EditChatAdmin y) => !(x == y);

        public int CompareTo(EditChatAdmin other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is EditChatAdmin x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditChatAdmin x, EditChatAdmin y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditChatAdmin x, EditChatAdmin y) => x.CompareTo(y) < 0;
        public static bool operator >(EditChatAdmin x, EditChatAdmin y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditChatAdmin x, EditChatAdmin y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ChatId: {ChatId}, UserId: {UserId}, IsAdmin: {IsAdmin})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa9e69f2e);
            Write(ChatId, bw, WriteInt);
            Write(UserId, bw, WriteSerializable);
            Write(IsAdmin, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}