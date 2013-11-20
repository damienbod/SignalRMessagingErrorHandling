using System.Threading.Tasks;
using Damienbod.SignalR.IHubSync.Client.Dto;
using Microsoft.AspNet.SignalR.Client;
using PortableSignalR.DataProvider;
using PortableSignalR.Model;
using SignalRDataProvider.HubClients;
using SignalRDataProvider.Logging;

namespace SignalRDataProvider.DataProvider
{
    public class SignalRHubSync : ISignalRHubSync
    {
        private MyHubClient _myHubClient;

        public SignalRHubSync()
        {
            _myHubClient = new MyHubClient();
        }

        public Task<MyMessage> Recieve_AddMessage()
        {
            throw new System.NotImplementedException();
        }

        public Task<MyMessage> Recieve_Heartbeat()
        {
            throw new System.NotImplementedException();
        }

        public Task<MyMessage> Recieve_SendHelloObject()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ConnectionStateActive()
        {
            throw new System.NotImplementedException();
        }

        public void Connect()
        {
            _myHubClient.StartHub();
            HubClientEvents.Log.Informational("Started the Hub");
        }

        public void Disconnect()
        {
            _myHubClient.CloseHub();
            HubClientEvents.Log.Informational("Closed Hub");
        }

        public void AddMessage(MyMessage message)
        {
            if (_myHubClient.State == ConnectionState.Connected)
            {
                _myHubClient.AddMessage(message.Name, message.Message);
            }
            else
            {
                HubClientEvents.Log.Warning("Can't send message, connectionState= " + _myHubClient.State);
            }
        }

        public void Heartbeat()
        {
             _myHubClient.Heartbeat();
        }

        public void SendHelloObject(MyMessage message)
        {
            if (_myHubClient.State == ConnectionState.Connected)
            {
                _myHubClient.SendHelloObject(new HelloModel { Age = int.Parse(message.Name), Molly = message.Message });
            }
            else
            {
                HubClientEvents.Log.Warning("Can't send message, connectionState= " + _myHubClient.State);
            }
        }
    }
}
