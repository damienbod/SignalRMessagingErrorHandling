using System.Threading.Tasks;
using PortableSignalR.Model;

namespace PortableSignalR.DataProvider
{
    public interface ISignalRHubSync
    {
        Task<MyMessage> Recieve_AddMessage();

        Task<MyMessage> Recieve_Heartbeat();

        Task<MyMessage> Recieve_SendHelloObject();

        Task<bool> ConnectionStateActive();

        void Connect();

        void Disconnect();

        void AddMessage(MyMessage message);

        void Heartbeat();

        void SendHelloObject(MyMessage message);
    }
}
