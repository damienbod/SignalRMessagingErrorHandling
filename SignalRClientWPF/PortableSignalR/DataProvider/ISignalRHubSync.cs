using System;
using System.Threading.Tasks;
using PortableSignalR.Model;

namespace PortableSignalR.DataProvider
{
    public interface ISignalRHubSync
    {
        event Action<bool> ConnectionEvent;

        event Action<MyMessage> RecieveMessageEvent;

        void Connect();

        void Disconnect();

        void AddMessage(MyMessage message);

        void Heartbeat();

        void SendHelloObject(MyMessage message);
    }
}
