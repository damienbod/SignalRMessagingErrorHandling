using System;
using Microsoft.AspNet.SignalR.Client;
using SignalRDataProvider.Logging;

namespace SignalRDataProvider.HubClients
{
    public abstract class BaseHubClient
    {
        protected HubConnection _hubConnection;
        protected IHubProxy _myHubProxy;

        public string HubConnectionUrl { get; set; }
        public string HubProxyName { get; set; }
        public TraceLevels HubTraceLevel { get; set; }
        public System.IO.TextWriter HubTraceWriter { get; set; }

        public event Action<bool> ConnectionEvent;

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
                HubClientEvents.Log.Warning(ex.Message + " " + ex.StackTrace);
            }

        }

        public abstract void StartHub();

        void _hubConnection_Closed()
        {
            HubClientEvents.Log.ClientEvents("_hubConnection_Closed New State:" + _hubConnection.State + " " + _hubConnection.ConnectionId);
        }

        void _hubConnection_ConnectionSlow()
        {
            HubClientEvents.Log.ClientEvents("_hubConnection_ConnectionSlow New State:" + _hubConnection.State + " " + _hubConnection.ConnectionId);
        }

        void _hubConnection_Error(Exception obj)
        {
            HubClientEvents.Log.ClientEvents("_hubConnection_Error New State:" + _hubConnection.State + " " + _hubConnection.ConnectionId);
        }

        void _hubConnection_StateChanged(StateChange obj)
        {
            if (this.State == ConnectionState.Connected)
            {
                if (ConnectionEvent != null) ConnectionEvent.Invoke(true);
            }
            else
            {
                if (ConnectionEvent != null) ConnectionEvent.Invoke(false);
            }
            HubClientEvents.Log.ClientEvents("_hubConnection_StateChanged New State:" + _hubConnection.State + " " + _hubConnection.ConnectionId);
        }

        void _hubConnection_Reconnecting()
        {
            HubClientEvents.Log.ClientEvents("_hubConnection_Reconnecting New State:" + _hubConnection.State + " " + _hubConnection.ConnectionId);
        }

        void _hubConnection_Reconnected()
        {
            HubClientEvents.Log.ClientEvents("_hubConnection_Reconnected New State:" + _hubConnection.State + " " + _hubConnection.ConnectionId);
        }

        void _hubConnection_Received(string obj)
        {
            HubClientEvents.Log.ClientEvents("_hubConnection_Received New State:" + _hubConnection.State + " " + _hubConnection.ConnectionId);
        }
    }
}
