using Damienbod.SignalR.MyHub.Dto;

namespace Damienbod.SignalR.MyHub
{
    public interface IMyHub
    {
        void AddMessage(string name, string message);

        void Heartbeat();

        void SendHelloObject(HelloModel hello);
    }
}
