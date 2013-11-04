using Damienbod.SignalR.Host.Unity;
using Damienbod.Slab;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Practices.Unity;

namespace Damienbod.SignalR.Host.Service
{
    public class LoggingPipelineModule : HubPipelineModule 
    {
        private readonly ISlabLogger _slabLogger;

        public LoggingPipelineModule()
        {
            _slabLogger = UnityConfiguration.GetConfiguredContainer().Resolve<ISlabLogger>();
        }

        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
           // Debug.WriteLine("=> Invoking " + context.MethodDescriptor.Name + " on hub " + context.MethodDescriptor.Hub.Name);
            _slabLogger.Log(HubType.HubServerVerbose, "=> Invoking " + context.MethodDescriptor.Name + " on hub " + context.MethodDescriptor.Hub.Name);
            return base.OnBeforeIncoming(context);
        }
        protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
        {
           // Debug.WriteLine("<= Invoking " + context.Invocation.Method + " on client hub " + context.Invocation.Hub);
            _slabLogger.Log(HubType.HubServerVerbose, "<= Invoking " + context.Invocation.Method + " on client hub " + context.Invocation.Hub);
            return base.OnBeforeOutgoing(context);
        } 
    }
}
