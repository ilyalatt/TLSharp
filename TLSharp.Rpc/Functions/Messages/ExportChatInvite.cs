using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ExportChatInvite : ITlFunc<T.ExportedChatInvite>, IEquatable<ExportChatInvite>, IComparable<ExportChatInvite>, IComparable
    {
        public int ChatId { get; }
        
        public ExportChatInvite(
            int chatId
        ) {
            ChatId = chatId;
        }
        
        
        int CmpTuple =>
            ChatId;

        public bool Equals(ExportChatInvite other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ExportChatInvite x && Equals(x);
        public static bool operator ==(ExportChatInvite x, ExportChatInvite y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ExportChatInvite x, ExportChatInvite y) => !(x == y);

        public int CompareTo(ExportChatInvite other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ExportChatInvite x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ExportChatInvite x, ExportChatInvite y) => x.CompareTo(y) <= 0;
        public static bool operator <(ExportChatInvite x, ExportChatInvite y) => x.CompareTo(y) < 0;
        public static bool operator >(ExportChatInvite x, ExportChatInvite y) => x.CompareTo(y) > 0;
        public static bool operator >=(ExportChatInvite x, ExportChatInvite y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ChatId: {ChatId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x7d885289);
            Write(ChatId, bw, WriteInt);
        }
        
        T.ExportedChatInvite ITlFunc<T.ExportedChatInvite>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ExportedChatInvite.Deserialize);
    }
}