using System;
using System.Threading.Tasks;
using Damienbod.SignalR.Host.Unity;
using Damienbod.SignalR.MyHub.Dto;
using Damienbod.Slab;
using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;

namespace Damienbod.SignalR.Host.Service
{
    public class MyHubServer : Hub
    {
        private readonly ISlabLogger _slabLogger;

        public MyHubServer()
        {
            _slabLogger = UnityConfiguration.GetConfiguredContainer().Resolve<ISlabLogger>();
        }

        public void AddMessage(string name, string message)
        {
            _slabLogger.Log(HubType.HubServerVerbose, "Hub Sending AddMessage " + name  + " " + message);
            Clients.All.addMessage(name, message);
        }

        public void Heartbeat()
        {
            _slabLogger.Log(HubType.HubServerVerbose, "Hub Sending Heartbeat");
            Clients.All.heartbeat();
        }

        public void SendHelloObject(HelloModel hello)
        {
            _slabLogger.Log(HubType.HubServerVerbose, "Hub Sending SendHelloObject " + hello.Molly + " " + hello.Age);
            Clients.All.sendHelloObject(hello);
        }

        public override Task OnConnected()
        {
            _slabLogger.Log(HubType.HubServerVerbose, "Hub OnConnected" + Context.ConnectionId);
            return (base.OnConnected());
        }

        public override Task OnDisconnected()
        {
            _slabLogger.Log(HubType.HubServerVerbose, "Hub OnDisconnected" + Context.ConnectionId);
            return (base.OnDisconnected());
        }

        public override Task OnReconnected()
        {
            _slabLogger.Log(HubType.HubServerVerbose, "Hub OnReconnected" + Context.ConnectionId);
            return (base.OnReconnected());
        }
    }
}