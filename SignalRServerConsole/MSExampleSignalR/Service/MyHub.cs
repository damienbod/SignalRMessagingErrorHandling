using System;
using Damienbod.SignalR.MyHub;
using Damienbod.SignalR.MyHub.Dto;
using Microsoft.AspNet.SignalR;

namespace Damienbod.SignalR.Host.Service
{
    public class MyHub : IMyHub
    {
        private readonly IHubContext _hubContext;
        public MyHub()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHubServer>(); 
        }
        
        public void AddMessage(string name, string message)
        {
            _hubContext.Clients.All.addMessage("server", "ServerMessage");
            Console.WriteLine("Server Sending addMessage\n");
        }

        public void Heartbeat()
        {
            _hubContext.Clients.All.heartbeat();
            Console.WriteLine("Server Sending heartbeat\n");
        }

        public void SendHelloObject(HelloModel hello)
        {
            _hubContext.Clients.All.sendHelloObject(hello);
            Console.WriteLine("Server Sending sendHelloObject\n");
        }
    }
}
