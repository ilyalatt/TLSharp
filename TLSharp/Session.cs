using System;
using System.IO;
using System.Linq;
using TLSharp.Auth;
using TLSharp.Rpc;
using TLSharp.Rpc.Types;
using TLSharp.Utils;

namespace TLSharp
{
    public interface ISessionStore
    {
        void Save(Session session);
        Session Load(string sessionUserId);
    }

    public class FileSessionStore : ISessionStore
    {
        public void Save(Session session)
        {
            using (var stream = new FileStream($"{session.SessionUserId}.dat", FileMode.OpenOrCreate))
            {
                var result = session.ToBytes();
                stream.Write(result, 0, result.Length);
            }
        }

        public Session Load(string sessionUserId)
        {
            var sessionFileName = $"{sessionUserId}.dat";
            if (!File.Exists(sessionFileName))
                return null;

            using (var stream = new FileStream(sessionFileName, FileMode.Open))
            {
                var buffer = new byte[2048];
                stream.Read(buffer, 0, 2048);

                return Session.FromBytes(buffer, this, sessionUserId);
            }
        }
    }

    public class FakeSessionStore : ISessionStore
    {
        public void Save(Session session)
        {

        }

        public Session Load(string sessionUserId)
        {
            return null;
        }
    }

    public class Session
    {
	    private const string DefaultConnectionAddress = "149.154.175.100";//"149.154.167.50";

		private const int DefaultConnectionPort = 443;

        public string SessionUserId { get; set; }
        public string ServerAddress { get; set; }
        public int Port { get; set; }
        public AuthKey AuthKey { get; set; }
        public long Id { get; set; }
        public int Sequence { get; set; }
        public long Salt { get; set; }
        public int TimeOffset { get; set; }
        public long LastMessageId { get; set; }
        public int SessionExpires { get; set; }
        public User TlUser { get; set; }
        private readonly Random _random;

        private readonly ISessionStore _store;

        public Session(ISessionStore store)
        {
            _random = new Random();
            _store = store;
        }

        public byte[] ToBytes()
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(Id);
                writer.Write(Sequence);
                writer.Write(Salt);
                writer.Write(LastMessageId);
                writer.Write(TimeOffset);
                TlMarshal.WriteString(writer, ServerAddress);
                writer.Write(Port);

                if (TlUser != null)
                {
                    writer.Write(1);
                    writer.Write(SessionExpires);
                    TlMarshal.WriteSerializable(writer, TlUser);
                }
                else
                {
                    writer.Write(0);
                }

                TlMarshal.WriteBytes(writer, AuthKey.Key);
                return stream.ToArray();
            }
        }

        public static Session FromBytes(byte[] buffer, ISessionStore store, string sessionUserId)
        {
            using (var stream = new MemoryStream(buffer))
            using (var reader = new BinaryReader(stream))
            {
                var id = reader.ReadInt64();
                var sequence = reader.ReadInt32();
                var salt = reader.ReadInt64();
                var lastMessageId = reader.ReadInt64();
                var timeOffset = reader.ReadInt32();
                var serverAddress = TlMarshal.ReadString(reader);
                var port = reader.ReadInt32();

                var isAuthExists = reader.ReadInt32() == 1;
                var sessionExpires = 0;
                User tlUser = null;
                if (isAuthExists)
                {
                    sessionExpires = reader.ReadInt32();
                    tlUser = User.Deserialize(reader);
                }

                var authData = TlMarshal.ReadBytes(reader).ToArray();

                return new Session(store)
                {
                    AuthKey = AuthKey.Deserialize(authData),
                    Id = id,
                    Salt = salt,
                    Sequence = sequence,
                    LastMessageId = lastMessageId,
                    TimeOffset = timeOffset,
                    SessionExpires = sessionExpires,
                    TlUser = tlUser,
                    SessionUserId = sessionUserId,
                    ServerAddress = serverAddress,
                    Port = port
                };
            }
        }

        public void Save()
        {
            _store.Save(this);
        }

        public static Session TryLoad(ISessionStore store, string sessionUserId)
        {
            return store.Load(sessionUserId);
        }

        public static Session Create(
            ISessionStore store,
            string sessionUserId,
            string serverAddress = DefaultConnectionAddress,
            int serverPort = DefaultConnectionPort
        )
        {
            return new Session(store)
            {
                Id = GenerateRandomLong(),
                SessionUserId = sessionUserId,
                ServerAddress = serverAddress,
                Port = serverPort
            };
        }

        private static long GenerateRandomLong()
        {
            var random = new Random();
            var rand = ((long)random.Next() << 32) | (long)random.Next();
            return rand;
        }

        public long GetNewMessageId() =>
            LastMessageId = Helpers.GetNewMessageId(LastMessageId, TimeOffset);
    }
}
