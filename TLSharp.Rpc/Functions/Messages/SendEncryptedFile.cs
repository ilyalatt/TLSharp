using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SendEncryptedFile : ITlFunc<T.Messages.SentEncryptedMessage>, IEquatable<SendEncryptedFile>, IComparable<SendEncryptedFile>, IComparable
    {
        public T.InputEncryptedChat Peer { get; }
        public long RandomId { get; }
        public Arr<byte> Data { get; }
        public T.InputEncryptedFile File { get; }
        
        public SendEncryptedFile(
            Some<T.InputEncryptedChat> peer,
            long randomId,
            Some<Arr<byte>> data,
            Some<T.InputEncryptedFile> file
        ) {
            Peer = peer;
            RandomId = randomId;
            Data = data;
            File = file;
        }
        
        
        (T.InputEncryptedChat, long, Arr<byte>, T.InputEncryptedFile) CmpTuple =>
            (Peer, RandomId, Data, File);

        public bool Equals(SendEncryptedFile other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SendEncryptedFile x && Equals(x);
        public static bool operator ==(SendEncryptedFile x, SendEncryptedFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendEncryptedFile x, SendEncryptedFile y) => !(x == y);

        public int CompareTo(SendEncryptedFile other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SendEncryptedFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendEncryptedFile x, SendEncryptedFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendEncryptedFile x, SendEncryptedFile y) => x.CompareTo(y) < 0;
        public static bool operator >(SendEncryptedFile x, SendEncryptedFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendEncryptedFile x, SendEncryptedFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, RandomId: {RandomId}, Data: {Data}, File: {File})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9a901b66);
            Write(Peer, bw, WriteSerializable);
            Write(RandomId, bw, WriteLong);
            Write(Data, bw, WriteBytes);
            Write(File, bw, WriteSerializable);
        }
        
        T.Messages.SentEncryptedMessage ITlFunc<T.Messages.SentEncryptedMessage>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.SentEncryptedMessage.Deserialize);
    }
}