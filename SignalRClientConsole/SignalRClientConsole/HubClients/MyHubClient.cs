using System;
using Damienbod.SignalR.IHubSync.Client;
using Damienbod.SignalR.IHubSync.Client.Dto;
using Microsoft.AspNet.SignalR.Client;
using SignalRClientConsole.Logging;

namespace SignalRClientConsole.HubClients
{
    public class MyHubClient : BaseHubClient, ISendHubSync, IRecieveHubSync
    {
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

            _myHubProxy.On<string, string>("AddMessage", Recieve_AddMessage);
            _myHubProxy.On("Heartbeat", Recieve_Heartbeat);
            _myHubProxy.On<HelloModel>("SendHelloObject", Recieve_SendHelloObject);

            StartHubInternal();
        }

        public override void StartHub()
        {
            _hubConnection.Dispose();
            Init();
        }

        public void Recieve_AddMessage(string name, string message)
        {
            HubClientEvents.Log.Informational("Recieved addMessage: " + name + ": " + message);
        }

        public void Recieve_Heartbeat()
        {
            HubClientEvents.Log.Informational("Recieved heartbeat ");
        }

        public void Recieve_SendHelloObject(HelloModel hello)
        {         
            HubClientEvents.Log.Informational("Recieved sendHelloObject "+ hello.Molly + ", " + hello.Age);
        }

        public void AddMessage(string name, string message)
        {
            _myHubProxy.Invoke("addMessage", "client message", " sent from console client").ContinueWith(task =>
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
