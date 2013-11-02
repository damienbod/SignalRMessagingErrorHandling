using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Damienbod.Slab.Loggers
{
    [EventSource(Name = "HubServerLogger")]
    public class HubServerLogger : EventSource
    {
        public void RegisterLogger(Dictionary<int, Action<string>> exectueLogDict)
        {
            exectueLogDict.Add(HubType.HubServerCritical, Critical);
            exectueLogDict.Add(HubType.HubServerError, Error);
            exectueLogDict.Add(HubType.HubServerInformational, Informational);
            exectueLogDict.Add(HubType.HubServerLogAlways, LogAlways);
            exectueLogDict.Add(HubType.HubServerVerbose, Verbose);
            exectueLogDict.Add(HubType.HubServerWarning, Warning);
        }

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