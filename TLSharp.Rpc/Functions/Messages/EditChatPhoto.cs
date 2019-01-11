using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class EditChatPhoto : ITlFunc<T.UpdatesType>, IEquatable<EditChatPhoto>, IComparable<EditChatPhoto>, IComparable
    {
        public int ChatId { get; }
        public T.InputChatPhoto Photo { get; }
        
        public EditChatPhoto(
            int chatId,
            Some<T.InputChatPhoto> photo
        ) {
            ChatId = chatId;
            Photo = photo;
        }
        
        
        (int, T.InputChatPhoto) CmpTuple =>
            (ChatId, Photo);

        public bool Equals(EditChatPhoto other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is EditChatPhoto x && Equals(x);
        public static bool operator ==(EditChatPhoto x, EditChatPhoto y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditChatPhoto x, EditChatPhoto y) => !(x == y);

        public int CompareTo(EditChatPhoto other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is EditChatPhoto x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditChatPhoto x, EditChatPhoto y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditChatPhoto x, EditChatPhoto y) => x.CompareTo(y) < 0;
        public static bool operator >(EditChatPhoto x, EditChatPhoto y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditChatPhoto x, EditChatPhoto y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ChatId: {ChatId}, Photo: {Photo})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xca4c79d8);
            Write(ChatId, bw, WriteInt);
            Write(Photo, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}