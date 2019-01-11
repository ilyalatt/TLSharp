using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetBotCallbackAnswer : ITlFunc<T.Messages.BotCallbackAnswer>, IEquatable<GetBotCallbackAnswer>, IComparable<GetBotCallbackAnswer>, IComparable
    {
        public bool Game { get; }
        public T.InputPeer Peer { get; }
        public int MsgId { get; }
        public Option<Arr<byte>> Data { get; }
        
        public GetBotCallbackAnswer(
            bool game,
            Some<T.InputPeer> peer,
            int msgId,
            Option<Arr<byte>> data
        ) {
            Game = game;
            Peer = peer;
            MsgId = msgId;
            Data = data;
        }
        
        
        (bool, T.InputPeer, int, Option<Arr<byte>>) CmpTuple =>
            (Game, Peer, MsgId, Data);

        public bool Equals(GetBotCallbackAnswer other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetBotCallbackAnswer x && Equals(x);
        public static bool operator ==(GetBotCallbackAnswer x, GetBotCallbackAnswer y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetBotCallbackAnswer x, GetBotCallbackAnswer y) => !(x == y);

        public int CompareTo(GetBotCallbackAnswer other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetBotCallbackAnswer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetBotCallbackAnswer x, GetBotCallbackAnswer y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetBotCallbackAnswer x, GetBotCallbackAnswer y) => x.CompareTo(y) < 0;
        public static bool operator >(GetBotCallbackAnswer x, GetBotCallbackAnswer y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetBotCallbackAnswer x, GetBotCallbackAnswer y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Game: {Game}, Peer: {Peer}, MsgId: {MsgId}, Data: {Data})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x810a9fec);
            Write(MaskBit(1, Game) | MaskBit(0, Data), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(MsgId, bw, WriteInt);
            Write(Data, bw, WriteOption<Arr<byte>>(WriteBytes));
        }
        
        T.Messages.BotCallbackAnswer ITlFunc<T.Messages.BotCallbackAnswer>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.BotCallbackAnswer.Deserialize);
    }
}