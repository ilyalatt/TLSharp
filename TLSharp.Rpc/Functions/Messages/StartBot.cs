using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class StartBot : ITlFunc<T.UpdatesType>, IEquatable<StartBot>, IComparable<StartBot>, IComparable
    {
        public T.InputUser Bot { get; }
        public T.InputPeer Peer { get; }
        public long RandomId { get; }
        public string StartParam { get; }
        
        public StartBot(
            Some<T.InputUser> bot,
            Some<T.InputPeer> peer,
            long randomId,
            Some<string> startParam
        ) {
            Bot = bot;
            Peer = peer;
            RandomId = randomId;
            StartParam = startParam;
        }
        
        
        (T.InputUser, T.InputPeer, long, string) CmpTuple =>
            (Bot, Peer, RandomId, StartParam);

        public bool Equals(StartBot other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is StartBot x && Equals(x);
        public static bool operator ==(StartBot x, StartBot y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(StartBot x, StartBot y) => !(x == y);

        public int CompareTo(StartBot other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is StartBot x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StartBot x, StartBot y) => x.CompareTo(y) <= 0;
        public static bool operator <(StartBot x, StartBot y) => x.CompareTo(y) < 0;
        public static bool operator >(StartBot x, StartBot y) => x.CompareTo(y) > 0;
        public static bool operator >=(StartBot x, StartBot y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Bot: {Bot}, Peer: {Peer}, RandomId: {RandomId}, StartParam: {StartParam})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe6df7378);
            Write(Bot, bw, WriteSerializable);
            Write(Peer, bw, WriteSerializable);
            Write(RandomId, bw, WriteLong);
            Write(StartParam, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}