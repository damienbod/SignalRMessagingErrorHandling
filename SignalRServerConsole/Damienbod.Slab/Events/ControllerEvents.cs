using System.Diagnostics.Tracing;

namespace Damienbod.Slab.Events
{
    [EventSource(Name = "ControllerEvents")]
    public class ControllerEvents : EventSource
    {
        public static readonly ControllerEvents Log = new ControllerEvents();

        [Event(WebType.ControllerCritical, Message = "Controller Critical: {0}", Level = EventLevel.Critical)]
        public void Critical(string message)
        {
            if (IsEnabled()) WriteEvent(WebType.ControllerCritical, message);
        }

        [Event(WebType.ControllerError, Message = "Controller Error {0}", Level = EventLevel.Error)]
        public void Error(string message)
        {
            if (IsEnabled()) WriteEvent(WebType.ControllerError, message);
        }

        [Event(WebType.ControllerInformational, Message = "Controller Informational {0}", Level = EventLevel.Informational)]
        public void Informational(string message)
        {
            if (IsEnabled()) WriteEvent(WebType.ControllerInformational, message);
        }

        [Event(WebType.ControllerLogAlways, Message = "Controller LogAlways {0}", Level = EventLevel.LogAlways)]
        public void LogAlways(string message)
        {
            if (IsEnabled()) WriteEvent(WebType.ControllerLogAlways, message);
        }

        [Event(WebType.ControllerVerbose, Message = "Controller Verbose {0}", Level = EventLevel.Verbose)]
        public void Verbose(string message)
        {
            if (IsEnabled()) WriteEvent(WebType.ControllerVerbose, message);
        }

        [Event(WebType.ControllerWarning, Message = "Controller Warning {0}", Level = EventLevel.Warning)]
        public void Warning(string message)
        {
            if (IsEnabled()) WriteEvent(WebType.ControllerWarning, message);
        }
    }



}