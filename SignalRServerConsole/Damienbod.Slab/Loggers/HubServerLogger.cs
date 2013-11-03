using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Damienbod.Slab.Events;

namespace Damienbod.Slab.Loggers
{
    public class HubServerLogger 
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

        public void Critical(string message)
        {
            HubServerEvents.Log.Critical(message);
        }

        public void Error(string message)
        {
            HubServerEvents.Log.Error(message);
        }

        public void Informational(string message)
        {
            HubServerEvents.Log.Informational(message);
        }

        public void LogAlways(string message)
        {
            HubServerEvents.Log.LogAlways(message);
        }

        public void Verbose(string message)
        {
            HubServerEvents.Log.Verbose(message);
        }

        public void Warning(string message)
        {
            HubServerEvents.Log.Warning(message);
        }
    }
}