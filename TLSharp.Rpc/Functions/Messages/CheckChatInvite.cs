using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class CheckChatInvite : ITlFunc<T.ChatInvite>, IEquatable<CheckChatInvite>, IComparable<CheckChatInvite>, IComparable
    {
        public string Hash { get; }
        
        public CheckChatInvite(
            Some<string> hash
        ) {
            Hash = hash;
        }
        
        
        string CmpTuple =>
            Hash;

        public bool Equals(CheckChatInvite other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is CheckChatInvite x && Equals(x);
        public static bool operator ==(CheckChatInvite x, CheckChatInvite y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CheckChatInvite x, CheckChatInvite y) => !(x == y);

        public int CompareTo(CheckChatInvite other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is CheckChatInvite x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CheckChatInvite x, CheckChatInvite y) => x.CompareTo(y) <= 0;
        public static bool operator <(CheckChatInvite x, CheckChatInvite y) => x.CompareTo(y) < 0;
        public static bool operator >(CheckChatInvite x, CheckChatInvite y) => x.CompareTo(y) > 0;
        public static bool operator >=(CheckChatInvite x, CheckChatInvite y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3eadb1bb);
            Write(Hash, bw, WriteString);
        }
        
        T.ChatInvite ITlFunc<T.ChatInvite>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ChatInvite.Deserialize);
    }
}