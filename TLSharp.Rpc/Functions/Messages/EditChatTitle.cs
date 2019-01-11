using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class EditChatTitle : ITlFunc<T.UpdatesType>, IEquatable<EditChatTitle>, IComparable<EditChatTitle>, IComparable
    {
        public int ChatId { get; }
        public string Title { get; }
        
        public EditChatTitle(
            int chatId,
            Some<string> title
        ) {
            ChatId = chatId;
            Title = title;
        }
        
        
        (int, string) CmpTuple =>
            (ChatId, Title);

        public bool Equals(EditChatTitle other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is EditChatTitle x && Equals(x);
        public static bool operator ==(EditChatTitle x, EditChatTitle y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditChatTitle x, EditChatTitle y) => !(x == y);

        public int CompareTo(EditChatTitle other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is EditChatTitle x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditChatTitle x, EditChatTitle y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditChatTitle x, EditChatTitle y) => x.CompareTo(y) < 0;
        public static bool operator >(EditChatTitle x, EditChatTitle y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditChatTitle x, EditChatTitle y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ChatId: {ChatId}, Title: {Title})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xdc452855);
            Write(ChatId, bw, WriteInt);
            Write(Title, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}