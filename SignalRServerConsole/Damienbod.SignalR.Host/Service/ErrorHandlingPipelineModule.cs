using Damienbod.SignalR.Host.Unity;
using Damienbod.Slab;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Practices.Unity;

namespace Damienbod.SignalR.Host.Service
{
    public class ErrorHandlingPipelineModule : HubPipelineModule
    {
        private readonly ISlabLogger _slabLogger;

        public ErrorHandlingPipelineModule()
        {
            _slabLogger = UnityConfiguration.GetConfiguredContainer().Resolve<ISlabLogger>();
        }

        protected override void OnIncomingError(ExceptionContext ex, IHubIncomingInvokerContext context)
        {
            _slabLogger.Log(HubType.HubServerVerbose, "=> Exception " + ex.Error + " " + ex.Result);
            if (ex.Error.InnerException != null)
            {
                _slabLogger.Log(HubType.HubServerVerbose, "=> Inner Exception " + ex.Error.InnerException.Message);
            }
            base.OnIncomingError(ex, context);
        }
    }
}
