using System;
using System.Collections.Generic;
using Damienbod.Slab.Events;

namespace Damienbod.Slab.Loggers
{
    public class GlobalLogger
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

        public void Critical(string message)
        {
            GlobalEvents.Log.Critical(message);
        }

        public void Error(string message)
        {
            GlobalEvents.Log.Error(message);
        }

        public void Informational(string message)
        {
            GlobalEvents.Log.Informational(message);
        }

        public void LogAlways(string message)
        {
            GlobalEvents.Log.LogAlways(message);
        }

        public void Verbose(string message)
        {
            GlobalEvents.Log.Verbose(message);
        }

        public void Warning(string message)
        {
            GlobalEvents.Log.Warning(message);
        }
    }



}