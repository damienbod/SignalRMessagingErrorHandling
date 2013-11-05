using System;
using Damienbod.SignalR.MyHub;
using Damienbod.SignalR.MyHub.Dto;
using Damienbod.Slab;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace Damienbod.SignalR.Host.Service
{
    public class MyHub : IMyHub
    {
        private readonly ISlabLogger _slabLogger;
        private readonly IHubContext _hubContext;

        private readonly MyHubServer _myHubServer;

        public MyHub(ISlabLogger slabLogger, MyHubServer myHubServer)
        {
            _slabLogger = slabLogger;
            _myHubServer = myHubServer;

            // TODO replace with IoC resolve, problem with SignalR DependenyResolver 
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHubServer>(); 
        }
        
        public void AddMessage(string name, string message)
        {
            _hubContext.Clients.All.addMessage("server", "ServerMessage");
            _slabLogger.Log(HubType.HubServerVerbose, "Server Sending addMessage");
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
