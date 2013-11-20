using System.Diagnostics.Tracing;

namespace SignalRDataProvider.Logging
{
    [EventSource(Name = "HubClientEvents")]
    public class HubClientEvents : EventSource
    {
        public static readonly HubClientEvents Log = new HubClientEvents();

        [Event(HubType.HubClientCritical, Message = "{0}", Level = EventLevel.Critical)]
        public void Critical(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubClientCritical, message);
        }

        [Event(HubType.HubClientError, Message = "{0}", Level = EventLevel.Error)]
        public void Error(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubClientError, message);
        }

        [Event(HubType.HubClientInformational, Message = "{0}", Level = EventLevel.Informational)]
        public void Informational(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubClientInformational, message);
        }

        [Event(HubType.HubClientLogAlways, Message = "{0}", Level = EventLevel.LogAlways)]
        public void LogAlways(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubClientLogAlways, message);
        }

        [Event(HubType.HubClientVerbose, Message = "{0}", Level = EventLevel.Verbose)]
        public void Verbose(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubClientVerbose, message);
        }

        [Event(HubType.HubClientWarning, Message = "{0}", Level = EventLevel.Warning)]
        public void Warning(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubClientWarning, message);
        }


        [Event(HubType.HubClientEvents, Message = "{0}", Level = EventLevel.Verbose)]
        public void ClientEvents(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubClientEvents, message);
        }
    }
}