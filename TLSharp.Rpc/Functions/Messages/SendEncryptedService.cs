using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SendEncryptedService : ITlFunc<T.Messages.SentEncryptedMessage>, IEquatable<SendEncryptedService>, IComparable<SendEncryptedService>, IComparable
    {
        public T.InputEncryptedChat Peer { get; }
        public long RandomId { get; }
        public Arr<byte> Data { get; }
        
        public SendEncryptedService(
            Some<T.InputEncryptedChat> peer,
            long randomId,
            Some<Arr<byte>> data
        ) {
            Peer = peer;
            RandomId = randomId;
            Data = data;
        }
        
        
        (T.InputEncryptedChat, long, Arr<byte>) CmpTuple =>
            (Peer, RandomId, Data);

        public bool Equals(SendEncryptedService other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SendEncryptedService x && Equals(x);
        public static bool operator ==(SendEncryptedService x, SendEncryptedService y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendEncryptedService x, SendEncryptedService y) => !(x == y);

        public int CompareTo(SendEncryptedService other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SendEncryptedService x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendEncryptedService x, SendEncryptedService y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendEncryptedService x, SendEncryptedService y) => x.CompareTo(y) < 0;
        public static bool operator >(SendEncryptedService x, SendEncryptedService y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendEncryptedService x, SendEncryptedService y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, RandomId: {RandomId}, Data: {Data})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x32d439a4);
            Write(Peer, bw, WriteSerializable);
            Write(RandomId, bw, WriteLong);
            Write(Data, bw, WriteBytes);
        }
        
        T.Messages.SentEncryptedMessage ITlFunc<T.Messages.SentEncryptedMessage>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.SentEncryptedMessage.Deserialize);
    }
}