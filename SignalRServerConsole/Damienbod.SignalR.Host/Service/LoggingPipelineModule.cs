using Damienbod.SignalR.Host.Unity;
using Damienbod.Slab;
using Damienbod.Slab.Services;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Practices.Unity;

namespace Damienbod.SignalR.Host.Service
{
    public class LoggingPipelineModule : HubPipelineModule 
    {
        private readonly IHubLogger _slabLogger;

        public LoggingPipelineModule()
        {
            _slabLogger = UnityConfiguration.GetConfiguredContainer().Resolve<IHubLogger>();
        }

        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            _slabLogger.Log(HubType.HubServerVerbose, "=> Invoking " + context.MethodDescriptor.Name + " on hub " + context.MethodDescriptor.Hub.Name);
            return base.OnBeforeIncoming(context);
        }
        protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
        {
            _slabLogger.Log(HubType.HubServerVerbose, "<= Invoking " + context.Invocation.Method + " on client hub " + context.Invocation.Hub);
            return base.OnBeforeOutgoing(context);
        } 
    }
}
