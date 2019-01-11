using System.IO;
using System.Threading.Tasks;
using LanguageExt;
using TLSharp.Utils;

namespace TLSharp
{
    public class FileSessionStore : ISessionStore
    {
        readonly string _fileName;
        readonly TaskQueue _taskQueue = new TaskQueue();

        public FileSessionStore(Some<string> name) => _fileName = name;

        // TODO implement save with backup
        async Task SaveImpl(Session session)
        {
            var bts = session.ToBytes();
            File.WriteAllBytes(_fileName, bts);
        }

        public async Task Save(Session session) =>
            await _taskQueue.Put(() => SaveImpl(session));

        // TODO
        public async Task<Option<Session>> Load()
        {
            if (!File.Exists(_fileName)) return Prelude.None;

            var bts = File.ReadAllBytes(_fileName);
            return Session.FromBytes(bts);
        }
    }
}