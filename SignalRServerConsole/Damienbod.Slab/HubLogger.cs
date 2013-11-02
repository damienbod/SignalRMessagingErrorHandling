using System;
using System.Collections.Generic;
using Damienbod.Slab.Loggers;

namespace Damienbod.Slab
{
    public class HubLogger : ISlabLogger
    {
        public HubLogger()
        {
            RegisterLog();
        }

        private readonly Dictionary<int, Action<string>> _exectueLogDict = new Dictionary<int, Action<string>>();

        private void RegisterLog()
        {
            var globalLogger = new GlobalLogger();
            globalLogger.RegisterLogger(_exectueLogDict);

            var hubServerLogger = new HubServerLogger();
            hubServerLogger.RegisterLogger(_exectueLogDict);
        }

        public void Log(int log, string message)
        {
            if (_exectueLogDict.ContainsKey(log))
            {
                _exectueLogDict[log].Invoke(message);
                return;
            }

            _exectueLogDict[GlobalType.GlobalWarning].Invoke(message);
        }
    }
}
