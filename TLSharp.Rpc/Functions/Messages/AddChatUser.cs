using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class AddChatUser : ITlFunc<T.UpdatesType>, IEquatable<AddChatUser>, IComparable<AddChatUser>, IComparable
    {
        public int ChatId { get; }
        public T.InputUser UserId { get; }
        public int FwdLimit { get; }
        
        public AddChatUser(
            int chatId,
            Some<T.InputUser> userId,
            int fwdLimit
        ) {
            ChatId = chatId;
            UserId = userId;
            FwdLimit = fwdLimit;
        }
        
        
        (int, T.InputUser, int) CmpTuple =>
            (ChatId, UserId, FwdLimit);

        public bool Equals(AddChatUser other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is AddChatUser x && Equals(x);
        public static bool operator ==(AddChatUser x, AddChatUser y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AddChatUser x, AddChatUser y) => !(x == y);

        public int CompareTo(AddChatUser other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is AddChatUser x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AddChatUser x, AddChatUser y) => x.CompareTo(y) <= 0;
        public static bool operator <(AddChatUser x, AddChatUser y) => x.CompareTo(y) < 0;
        public static bool operator >(AddChatUser x, AddChatUser y) => x.CompareTo(y) > 0;
        public static bool operator >=(AddChatUser x, AddChatUser y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ChatId: {ChatId}, UserId: {UserId}, FwdLimit: {FwdLimit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf9a0aa09);
            Write(ChatId, bw, WriteInt);
            Write(UserId, bw, WriteSerializable);
            Write(FwdLimit, bw, WriteInt);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}