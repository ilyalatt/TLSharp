using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetFullChat : ITlFunc<T.Messages.ChatFull>, IEquatable<GetFullChat>, IComparable<GetFullChat>, IComparable
    {
        public int ChatId { get; }
        
        public GetFullChat(
            int chatId
        ) {
            ChatId = chatId;
        }
        
        
        int CmpTuple =>
            ChatId;

        public bool Equals(GetFullChat other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetFullChat x && Equals(x);
        public static bool operator ==(GetFullChat x, GetFullChat y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetFullChat x, GetFullChat y) => !(x == y);

        public int CompareTo(GetFullChat other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetFullChat x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetFullChat x, GetFullChat y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetFullChat x, GetFullChat y) => x.CompareTo(y) < 0;
        public static bool operator >(GetFullChat x, GetFullChat y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetFullChat x, GetFullChat y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ChatId: {ChatId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3b831c66);
            Write(ChatId, bw, WriteInt);
        }
        
        T.Messages.ChatFull ITlFunc<T.Messages.ChatFull>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.ChatFull.Deserialize);
    }
}