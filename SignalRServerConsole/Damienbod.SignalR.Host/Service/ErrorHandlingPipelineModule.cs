using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Damienbod.Slab;
using Microsoft.AspNet.SignalR.Hubs;

namespace Damienbod.SignalR.Host.Service
{
    public class ErrorHandlingPipelineModule : HubPipelineModule
    {
        private readonly ISlabLogger _slabLogger;

        public ErrorHandlingPipelineModule()
        {
            _slabLogger = new HubLogger();
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
