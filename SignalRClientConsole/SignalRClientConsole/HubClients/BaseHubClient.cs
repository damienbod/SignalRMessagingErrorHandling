using System;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRClientConsole.HubClients
{
    public abstract class BaseHubClient
    {
        protected HubConnection _hubConnection;
        protected IHubProxy _myHubProxy;

        public string HubConnectionUrl { get;set;}
        public string HubProxyName { get; set; }
        public TraceLevels HubTraceLevel { get; set; }
        public System.IO.TextWriter HubTraceWriter { get; set; }


        public ConnectionState State
        {
            get { return _hubConnection.State; }
        }

        protected void Init()
        {
            _hubConnection = new HubConnection(HubConnectionUrl)
            {
                TraceLevel = HubTraceLevel,
                TraceWriter = HubTraceWriter
            };

            _myHubProxy = _hubConnection.CreateHubProxy(HubProxyName);

            _hubConnection.Received += _hubConnection_Received;
            _hubConnection.Reconnected += _hubConnection_Reconnected;
            _hubConnection.Reconnecting += _hubConnection_Reconnecting;
            _hubConnection.StateChanged += _hubConnection_StateChanged;
            _hubConnection.Error += _hubConnection_Error;
            _hubConnection.ConnectionSlow += _hubConnection_ConnectionSlow;
            _hubConnection.Closed += _hubConnection_Closed;

        }

        public void CloseHub()
        {
            _hubConnection.Stop();
            _hubConnection.Dispose();
        }

        protected void StartHubInternal()
        {
            try
            {
                _hubConnection.Start().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public abstract void StartHub();

        void _hubConnection_Closed()
        {
            Console.Write("+++++++ _hubConnection_Closed \n");
        }

        void _hubConnection_ConnectionSlow()
        {
            Console.Write("+++++++ _hubConnection_ConnectionSlow \n");
        }

        void _hubConnection_Error(Exception obj)
        {
            Console.Write("+++++++ _hubConnection_Error \n");
        }

        void _hubConnection_StateChanged(StateChange obj)
        {
            Console.Write("+++++++ _hubConnection_StateChanged \n");
        }

        void _hubConnection_Reconnecting()
        {
            Console.Write("+++++++ _hubConnection_Reconnecting \n");
        }

        void _hubConnection_Reconnected()
        {
            Console.Write("+++++++ _hubConnection_Reconnected \n");
        }

        void _hubConnection_Received(string obj)
        {
            Console.Write("+++++++ _hubConnection_Received \n");
        }
    }
}
