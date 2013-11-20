using System;
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
        private readonly MyHubClient _myHubClient;

        //public event Action<bool> ConnectionEvent;
        
        public SignalRHubSync()
        {
            _myHubClient = new MyHubClient();
            _myHubClient.ConnectionEvent += _myHubClient_ConnectionEvent;
            _myHubClient.RecievedMessageEvent += _myHubClient_RecievedMessageEvent;
        }

        void _myHubClient_RecievedMessageEvent(MyMessage obj)
        {
            if (RecieveMessageEvent != null) RecieveMessageEvent.Invoke(obj); 
        }

        void _myHubClient_ConnectionEvent(bool obj)
        {
            if (ConnectionEvent != null) ConnectionEvent.Invoke(obj);
        }

        public event Action<bool> ConnectionEvent;
        public event Action<MyMessage> RecieveMessageEvent;


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
