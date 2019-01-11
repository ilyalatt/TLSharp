using System.Threading.Tasks;
using LanguageExt;

namespace TLSharp
{
    public interface ISessionStore
    {
        Task<Option<Session>> Load();
        Task Save(Some<Session> someSession);
    }
}
