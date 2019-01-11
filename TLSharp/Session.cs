using System.IO;
using System.Net;
using LanguageExt;
using TLSharp.Auth;
using TLSharp.Rpc;
using TLSharp.Utils;

namespace TLSharp
{
    // will be changed soon
    public sealed class Session
    {
        public long Id { get; set; }
        public AuthKey AuthKey { get; set; }
        public bool IsAuthenticated { get; set; }
        public int Sequence { get; set; }
        public long Salt { get; set; }
        public int TimeOffset { get; set; }
        public long LastMessageId { get; set; }
        public IPEndPoint Endpoint { get; set; }


        public static Session New() => new Session
        {
            Id = Helpers.GenerateRandomLong()
        };

        public long GetNewMessageId() =>
            LastMessageId = Helpers.GetNewMessageId(LastMessageId, TimeOffset);


        public void Serialize(BinaryWriter bw)
        {
            TlMarshal.WriteLong(bw, Id);
            TlMarshal.WriteInt(bw, Sequence);
            TlMarshal.WriteLong(bw, Salt);
            TlMarshal.WriteLong(bw, LastMessageId);
            TlMarshal.WriteInt(bw, TimeOffset);
            TlMarshal.WriteBytes(bw, Endpoint.Address.GetAddressBytes());
            TlMarshal.WriteInt(bw, Endpoint.Port);
            TlMarshal.WriteBytes(bw, AuthKey.Key);
            TlMarshal.WriteBool(bw, IsAuthenticated);
        }

        public static Session Deserialize(BinaryReader br)
        {
            var id = TlMarshal.ReadLong(br);
            var sequence = TlMarshal.ReadInt(br);
            var salt = TlMarshal.ReadLong(br);
            var lastMessageId = TlMarshal.ReadLong(br);
            var timeOffset = TlMarshal.ReadInt(br);

            var serverAddress = TlMarshal.ReadRawBytes(br).Apply(bts => new IPAddress(bts));
            var port = TlMarshal.ReadInt(br);
            var ep = new IPEndPoint(serverAddress, port);

            var authData = TlMarshal.ReadBytes(br);
            var isAuthenticated = TlMarshal.ReadBool(br);

            return new Session
            {
                Id = id,
                Salt = salt,
                Sequence = sequence,
                LastMessageId = lastMessageId,
                TimeOffset = timeOffset,
                Endpoint = ep,
                AuthKey = AuthKey.Deserialize(authData),
                IsAuthenticated = isAuthenticated
            };
        }
    }
}
