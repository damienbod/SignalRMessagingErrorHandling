using Damienbod.SignalR.IHubSync.Client.Dto;

namespace Damienbod.SignalR.IHubSync.Client
{
    public interface IRecieveHubSync
    {
        void Recieve_AddMessage(string name, string message);

        void Recieve_Heartbeat();

        void Recieve_SendHelloObject(HelloModel hello);

    }
}
