using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Damienbod.Slab.Loggers
{
    [EventSource(Name = "GlobalLogger")]
    public class GlobalLogger : EventSource
    {
        public void RegisterLogger(Dictionary<int, Action<string>> exectueLogDict)
        {
            exectueLogDict.Add(GlobalType.GlobalCritical, Critical);
            exectueLogDict.Add(GlobalType.GlobalError, Error);
            exectueLogDict.Add(GlobalType.GlobalInformational, Informational);
            exectueLogDict.Add(GlobalType.GlobalLogAlways, LogAlways);
            exectueLogDict.Add(GlobalType.GlobalVerbose, Verbose);
            exectueLogDict.Add(GlobalType.GlobalWarning, Warning);
        }

        [Event(GlobalType.GlobalCritical, Message = "Global Critical: {0}", Level = EventLevel.Critical)]
        public void Critical(string message)
        {
            
            if (IsEnabled()) WriteEvent(GlobalType.GlobalCritical, message);
        }

        [Event(GlobalType.GlobalError, Message = "Global Error {0}", Level = EventLevel.Error)]
        public void Error(string message)
        {
            if (IsEnabled()) WriteEvent(GlobalType.GlobalError, message);
        }

        [Event(GlobalType.GlobalInformational, Message = "Global Informational {0}", Level = EventLevel.Informational)]
        public void Informational(string message)
        {
            if (IsEnabled()) WriteEvent(GlobalType.GlobalInformational, message);
        }

        [Event(GlobalType.GlobalLogAlways, Message = "Global LogAlways {0}", Level = EventLevel.LogAlways)]
        public void LogAlways(string message)
        {
            if (IsEnabled()) WriteEvent(GlobalType.GlobalLogAlways, message);
        }

        [Event(GlobalType.GlobalVerbose, Message = "Global Verbose {0}", Level = EventLevel.Verbose)]
        public void Verbose(string message)
        {
            if (IsEnabled()) WriteEvent(GlobalType.GlobalVerbose, message);
        }

        [Event(GlobalType.GlobalWarning, Message = "Global Warning {0}", Level = EventLevel.Warning)]
        public void Warning(string message)
        {
            if (IsEnabled()) WriteEvent(GlobalType.GlobalWarning, message);
        }
    }



}