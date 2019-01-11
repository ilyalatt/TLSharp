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


        // TODO
        public async Task<Option<Session>> Load()
        {
            if (!File.Exists(_fileName)) return Prelude.None;

            var bts = File.ReadAllBytes(_fileName);
            return bts.Apply(BtHelpers.Deserialize(Session.Deserialize));
        }


        // TODO implement save with backup
        async Task SaveImpl(Session session)
        {
            var bts = BtHelpers.UsingMemBinWriter(session.Serialize);
            File.WriteAllBytes(_fileName, bts);
        }

        public async Task Save(Some<Session> someSession) =>
            await _taskQueue.Put(() => SaveImpl(someSession));
    }
}
