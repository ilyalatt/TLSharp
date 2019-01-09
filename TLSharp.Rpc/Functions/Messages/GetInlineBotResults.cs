using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetInlineBotResults : Record<GetInlineBotResults>, ITlFunc<T.Messages.BotResults>
    {
        public T.InputUser Bot { get; }
        public T.InputPeer Peer { get; }
        public Option<T.InputGeoPoint> GeoPoint { get; }
        public string Query { get; }
        public string Offset { get; }
        
        public GetInlineBotResults(
            Some<T.InputUser> bot,
            Some<T.InputPeer> peer,
            Option<T.InputGeoPoint> geoPoint,
            Some<string> query,
            Some<string> offset
        ) {
            Bot = bot;
            Peer = peer;
            GeoPoint = geoPoint;
            Query = query;
            Offset = offset;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x514e999d);
            Write(MaskBit(0, GeoPoint), bw, WriteInt);
            Write(Bot, bw, WriteSerializable);
            Write(Peer, bw, WriteSerializable);
            Write(GeoPoint, bw, WriteOption<T.InputGeoPoint>(WriteSerializable));
            Write(Query, bw, WriteString);
            Write(Offset, bw, WriteString);
        }
        
        T.Messages.BotResults ITlFunc<T.Messages.BotResults>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.BotResults.Deserialize);
    }
}