using System.Threading.Tasks;

namespace TLSharp
{
    public interface ISessionStore
    {
        Task Save(Session session);
        Task<Session> Load(string sessionUserId);
    }
}