using Damienbod.SignalR.IHubSync.Client.Dto;

namespace Damienbod.SignalR.IHubSync.Client
{
    public interface ISendHubSync
    {
        void AddMessage(string name, string message);

        void Heartbeat();

        void SendHelloObject(HelloModel hello);

    }
}
