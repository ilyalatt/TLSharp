using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ToggleChatAdmins : ITlFunc<T.UpdatesType>, IEquatable<ToggleChatAdmins>, IComparable<ToggleChatAdmins>, IComparable
    {
        public int ChatId { get; }
        public bool Enabled { get; }
        
        public ToggleChatAdmins(
            int chatId,
            bool enabled
        ) {
            ChatId = chatId;
            Enabled = enabled;
        }
        
        
        (int, bool) CmpTuple =>
            (ChatId, Enabled);

        public bool Equals(ToggleChatAdmins other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ToggleChatAdmins x && Equals(x);
        public static bool operator ==(ToggleChatAdmins x, ToggleChatAdmins y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ToggleChatAdmins x, ToggleChatAdmins y) => !(x == y);

        public int CompareTo(ToggleChatAdmins other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ToggleChatAdmins x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ToggleChatAdmins x, ToggleChatAdmins y) => x.CompareTo(y) <= 0;
        public static bool operator <(ToggleChatAdmins x, ToggleChatAdmins y) => x.CompareTo(y) < 0;
        public static bool operator >(ToggleChatAdmins x, ToggleChatAdmins y) => x.CompareTo(y) > 0;
        public static bool operator >=(ToggleChatAdmins x, ToggleChatAdmins y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ChatId: {ChatId}, Enabled: {Enabled})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xec8bd9e1);
            Write(ChatId, bw, WriteInt);
            Write(Enabled, bw, WriteBool);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}