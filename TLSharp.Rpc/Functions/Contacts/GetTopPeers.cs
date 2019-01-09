using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class GetTopPeers : Record<GetTopPeers>, ITlFunc<T.Contacts.TopPeers>
    {
        public bool Correspondents { get; }
        public bool BotsPm { get; }
        public bool BotsInline { get; }
        public bool Groups { get; }
        public bool Channels { get; }
        public int Offset { get; }
        public int Limit { get; }
        public int Hash { get; }
        
        public GetTopPeers(
            bool correspondents,
            bool botsPm,
            bool botsInline,
            bool groups,
            bool channels,
            int offset,
            int limit,
            int hash
        ) {
            Correspondents = correspondents;
            BotsPm = botsPm;
            BotsInline = botsInline;
            Groups = groups;
            Channels = channels;
            Offset = offset;
            Limit = limit;
            Hash = hash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd4982db5);
            Write(MaskBit(0, Correspondents) | MaskBit(1, BotsPm) | MaskBit(2, BotsInline) | MaskBit(10, Groups) | MaskBit(15, Channels), bw, WriteInt);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
            Write(Hash, bw, WriteInt);
        }
        
        T.Contacts.TopPeers ITlFunc<T.Contacts.TopPeers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.TopPeers.Deserialize);
    }
}