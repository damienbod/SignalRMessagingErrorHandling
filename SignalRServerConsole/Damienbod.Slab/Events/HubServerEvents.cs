using System.Diagnostics.Tracing;

namespace Damienbod.Slab.Events
{
    [EventSource(Name = "HubServerEvents")]
    public class HubServerEvents : EventSource
    {
        public static readonly HubServerEvents Log = new HubServerEvents();

        [Event(HubType.HubServerCritical, Message = "HubServerLogger Critical: {0}", Level = EventLevel.Critical)]
        public void Critical(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubServerCritical, message);
        }

        [Event(HubType.HubServerError, Message = "HubServerLogger Error {0}", Level = EventLevel.Error)]
        public void Error(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubServerError, message);
        }

        [Event(HubType.HubServerInformational, Message = "HubServerLogger Informational {0}", Level = EventLevel.Informational)]
        public void Informational(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubServerInformational, message);
        }

        [Event(HubType.HubServerLogAlways, Message = "HubServerLogger LogAlways {0}", Level = EventLevel.LogAlways)]
        public void LogAlways(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubServerLogAlways, message);
        }

        [Event(HubType.HubServerVerbose, Message = "HubServerLogger Verbose {0}", Level = EventLevel.Verbose)]
        public void Verbose(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubServerVerbose, message);
        }

        [Event(HubType.HubServerWarning, Message = "HubServerLogger Warning {0}", Level = EventLevel.Warning)]
        public void Warning(string message)
        {
            if (IsEnabled()) WriteEvent(HubType.HubServerWarning, message);
        }
    }
}