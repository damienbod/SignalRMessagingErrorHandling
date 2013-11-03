using System;
using Damienbod.SignalR.MyHub;
using Damienbod.SignalR.MyHub.Dto;
using Damienbod.Slab;
using Microsoft.AspNet.SignalR;

namespace Damienbod.SignalR.Host.Service
{
    public class MyHub : IMyHub
    {
        private readonly ISlabLogger _slabLogger;
        private readonly IHubContext _hubContext;

        public MyHub(ISlabLogger slabLogger)
        {
            _slabLogger = slabLogger;

            // TODO replace with IoC resolve, problem with SignalR DependenyResolver 
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHubServer>(); 
        }
        
        public void AddMessage(string name, string message)
        {
            _hubContext.Clients.All.addMessage("server", "ServerMessage");
            _slabLogger.Log(HubType.HubServerCritical, "Server Sending addMessage");
            _slabLogger.Log(GlobalType.GlobalCritical, "Server Sending addMessage");
        }

        public void Heartbeat()
        {
            _hubContext.Clients.All.heartbeat();
            _slabLogger.Log(HubType.HubServerVerbose, "Server Sending heartbeat");
        }

        public void SendHelloObject(HelloModel hello)
        {
            _hubContext.Clients.All.sendHelloObject(hello);
            _slabLogger.Log(HubType.HubServerVerbose, "Server Sending sendHelloObject");
        }
    }
}
