using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetEncryptedTyping : ITlFunc<bool>, IEquatable<SetEncryptedTyping>, IComparable<SetEncryptedTyping>, IComparable
    {
        public T.InputEncryptedChat Peer { get; }
        public bool Typing { get; }
        
        public SetEncryptedTyping(
            Some<T.InputEncryptedChat> peer,
            bool typing
        ) {
            Peer = peer;
            Typing = typing;
        }
        
        
        (T.InputEncryptedChat, bool) CmpTuple =>
            (Peer, Typing);

        public bool Equals(SetEncryptedTyping other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SetEncryptedTyping x && Equals(x);
        public static bool operator ==(SetEncryptedTyping x, SetEncryptedTyping y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetEncryptedTyping x, SetEncryptedTyping y) => !(x == y);

        public int CompareTo(SetEncryptedTyping other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SetEncryptedTyping x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetEncryptedTyping x, SetEncryptedTyping y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetEncryptedTyping x, SetEncryptedTyping y) => x.CompareTo(y) < 0;
        public static bool operator >(SetEncryptedTyping x, SetEncryptedTyping y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetEncryptedTyping x, SetEncryptedTyping y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Typing: {Typing})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x791451ed);
            Write(Peer, bw, WriteSerializable);
            Write(Typing, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}