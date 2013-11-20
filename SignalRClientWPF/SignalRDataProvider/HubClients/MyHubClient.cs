using System;
using System.Threading.Tasks;
using Damienbod.SignalR.IHubSync.Client;
using Damienbod.SignalR.IHubSync.Client.Dto;
using Microsoft.AspNet.SignalR.Client;
using PortableSignalR.Model;
using SignalRClientConsole.HubClients;
using SignalRDataProvider.Logging;

namespace SignalRDataProvider.HubClients
{
    public class MyHubClient : BaseHubClient, ISendHubSync, IRecieveHubSync
    {
        public event Action<MyMessage> RecievedMessageEvent;

        public MyHubClient()
        {
            Init();
        }

        public new void Init()
        {
            HubConnectionUrl = "http://localhost:8089/";
            HubProxyName = "Hubsync";
            HubTraceLevel = TraceLevels.None;
            HubTraceWriter = Console.Out;

            base.Init();

            _myHubProxy.On<string, string>("addMessage", Recieve_AddMessage);
            _myHubProxy.On("heartbeat", Recieve_Heartbeat);
            _myHubProxy.On<HelloModel>("sendHelloObject", Recieve_SendHelloObject);

            StartHubInternal();
        }

        public override void StartHub()
        {
            _hubConnection.Dispose();
            Init();
        }

        public void Recieve_AddMessage(string name, string message)
        {
            if (RecievedMessageEvent != null) RecievedMessageEvent.Invoke(new MyMessage { Name = name , Message = message});
            HubClientEvents.Log.Informational("Recieved addMessage: " + name + ": " + message);
        }

        public void Recieve_Heartbeat()
        {
            if (RecievedMessageEvent != null) RecievedMessageEvent.Invoke(new MyMessage { Name = "Heartbeat", Message = "recieved" });
            HubClientEvents.Log.Informational("Recieved heartbeat ");
        }

        public void Recieve_SendHelloObject(HelloModel hello)
        {
            if (RecievedMessageEvent != null) RecievedMessageEvent.Invoke(new MyMessage { Name = hello.Age.ToString(), Message = hello.Molly });
            HubClientEvents.Log.Informational("Recieved sendHelloObject " + hello.Molly + ", " + hello.Age);
        }

        public void AddMessage(string name, string message)
        {
            _myHubProxy.Invoke("addMessage", name, message).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    HubClientEvents.Log.Error("There was an error opening the connection:" + task.Exception.GetBaseException());
                }

            }).Wait();
            HubClientEvents.Log.Informational("Client Sending addMessage to server");
        }

        public void Heartbeat()
        {
            _myHubProxy.Invoke("Heartbeat").ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    HubClientEvents.Log.Error("There was an error opening the connection:" + task.Exception.GetBaseException());
                }

            }).Wait();
            HubClientEvents.Log.Informational("Client heartbeat sent to server");
        }

        public void SendHelloObject(HelloModel hello)
        {
            _myHubProxy.Invoke<HelloModel>("SendHelloObject", hello).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    HubClientEvents.Log.Error("There was an error opening the connection:" + task.Exception.GetBaseException());
                }

            }).Wait();
            HubClientEvents.Log.Informational("Client sendHelloObject sent to server");
        }


    }
}
