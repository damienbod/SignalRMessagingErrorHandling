using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Damienbod.Slab.Events;

namespace Damienbod.Slab.Loggers
{
    [EventSource(Name = "ControllerLogger")]
    public class ControllerLogger : EventSource
    {
        public void RegisterLogger(Dictionary<int, Action<string>> exectueLogDict)
        {
            exectueLogDict.Add(WebType.ControllerCritical, Critical);
            exectueLogDict.Add(WebType.ControllerError, Error);
            exectueLogDict.Add(WebType.ControllerInformational, Informational);
            exectueLogDict.Add(WebType.ControllerLogAlways, LogAlways);
            exectueLogDict.Add(WebType.ControllerVerbose, Verbose);
            exectueLogDict.Add(WebType.ControllerWarning, Warning);
        }

        public void Critical(string message)
        {
            ControllerEvents.Log.Critical(message);
        }

        public void Error(string message)
        {
            ControllerEvents.Log.Error(message);
        }

        public void Informational(string message)
        {
            ControllerEvents.Log.Informational(message);
        }

        public void LogAlways(string message)
        {
            ControllerEvents.Log.LogAlways(message);
        }

        public void Verbose(string message)
        {
            ControllerEvents.Log.Verbose(message);
        }

        public void Warning(string message)
        {
            ControllerEvents.Log.Warning(message);
        }
    }



}