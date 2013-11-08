using System;
using Damienbod.SignalR.MyHub;
using Damienbod.SignalR.MyHub.Dto;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRClientConsole.HubClients
{
    public class MyHubClient : IMyHub
    {
        private readonly HubConnection _hubConnection;
        private readonly IHubProxy _myHubProxy;

        public MyHubClient()
        {
            _hubConnection = new HubConnection("http://localhost:8089/")
            {
                TraceLevel = TraceLevels.All,
                TraceWriter = Console.Out
            };

            _myHubProxy = _hubConnection.CreateHubProxy("Hubsync");

            _myHubProxy.On<string, string>("addMessage", Recieved_AddMessage);
            _myHubProxy.On("heartbeat", Recieved_Heartbeat);
            _myHubProxy.On<HelloModel>("sendHelloObject", Recieved_SendHelloObject);

            StartHub();
        }

        public void Recieved_AddMessage(string name, string message)
        {
            Console.Write("Recieved addMessage: " + name + ": " + message + "\n");
        }

        public void Recieved_Heartbeat()
        {
            Console.Write("Recieved heartbeat \n");
        }

        public void Recieved_SendHelloObject(HelloModel hello)
        {
            Console.Write("Recieved sendHelloObject {0}, {1} \n", hello.Molly, hello.Age);
        }

        public void AddMessage(string name, string message)
        {
            _myHubProxy.Invoke("addMessage", "client message", " sent from console client").ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("!!! There was an error opening the connection:{0} \n", task.Exception.GetBaseException());
                }

            }).Wait();
            Console.WriteLine("Client Sending addMessage to server\n");
        }

        public void Heartbeat()
        {
           _myHubProxy.Invoke("Heartbeat").ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}", task.Exception.GetBaseException());
                }

            }).Wait();
            Console.WriteLine("client heartbeat sent to server\n");
        }

        public void SendHelloObject(HelloModel hello)
        {
            _myHubProxy.Invoke<HelloModel>("SendHelloObject", hello).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}", task.Exception.GetBaseException());
                }

            }).Wait();
            Console.WriteLine("client sendHelloObject sent to server\n");
        }

        private void StartHub()
        {
            _hubConnection.Start().Wait();
        }
    }
}
