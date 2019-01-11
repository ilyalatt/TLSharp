using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class AcceptEncryption : ITlFunc<T.EncryptedChat>, IEquatable<AcceptEncryption>, IComparable<AcceptEncryption>, IComparable
    {
        public T.InputEncryptedChat Peer { get; }
        public Arr<byte> Gb { get; }
        public long KeyFingerprint { get; }
        
        public AcceptEncryption(
            Some<T.InputEncryptedChat> peer,
            Some<Arr<byte>> gb,
            long keyFingerprint
        ) {
            Peer = peer;
            Gb = gb;
            KeyFingerprint = keyFingerprint;
        }
        
        
        (T.InputEncryptedChat, Arr<byte>, long) CmpTuple =>
            (Peer, Gb, KeyFingerprint);

        public bool Equals(AcceptEncryption other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is AcceptEncryption x && Equals(x);
        public static bool operator ==(AcceptEncryption x, AcceptEncryption y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AcceptEncryption x, AcceptEncryption y) => !(x == y);

        public int CompareTo(AcceptEncryption other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is AcceptEncryption x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AcceptEncryption x, AcceptEncryption y) => x.CompareTo(y) <= 0;
        public static bool operator <(AcceptEncryption x, AcceptEncryption y) => x.CompareTo(y) < 0;
        public static bool operator >(AcceptEncryption x, AcceptEncryption y) => x.CompareTo(y) > 0;
        public static bool operator >=(AcceptEncryption x, AcceptEncryption y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Gb: {Gb}, KeyFingerprint: {KeyFingerprint})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3dbc0415);
            Write(Peer, bw, WriteSerializable);
            Write(Gb, bw, WriteBytes);
            Write(KeyFingerprint, bw, WriteLong);
        }
        
        T.EncryptedChat ITlFunc<T.EncryptedChat>.DeserializeResult(BinaryReader br) =>
            Read(br, T.EncryptedChat.Deserialize);
    }
}