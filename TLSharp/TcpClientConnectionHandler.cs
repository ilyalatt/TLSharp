using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TLSharp
{
    public delegate Task<TcpClient> TcpClientConnectionHandler(IPEndPoint endpoint);
}
