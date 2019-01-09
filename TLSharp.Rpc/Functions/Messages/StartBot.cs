using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class StartBot : Record<StartBot>, ITlFunc<T.UpdatesType>
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