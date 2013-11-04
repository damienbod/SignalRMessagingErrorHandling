using System;
using Damienbod.SignalR.Host.Service;
using Damienbod.SignalR.Host.Unity;
using Damienbod.SignalR.MyHub;
using Damienbod.SignalR.MyHub.Dto;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Owin;

[assembly: OwinStartup(typeof(Damienbod.SignalR.Host.Startup))]
namespace Damienbod.SignalR.Host
{
    public class Startup
    {
        private static IMyHub _myHub;

        public static void Start()
        {
            // TODO setup IoC container, problem with Hub resolve
            GlobalHost.DependencyResolver = new DefaultDependencyResolver(); //new UnityDependencyResolver(UnityConfiguration.GetConfiguredContainer());
            GlobalHost.HubPipeline.AddModule(new LoggingPipelineModule());
            GlobalHost.HubPipeline.AddModule(new ErrorHandlingPipelineModule());

            var url = MyConfiguration.GetInstance().MyHubServiceUrl();
            _myHub = UnityConfiguration.GetConfiguredContainer().Resolve<IMyHub>();

            using (WebApp.Start(url))
            {

                Console.WriteLine("Server running on {0}", url);
                while (true)
                {
                    var key = Console.ReadLine();
                    if (key.ToUpper() == "W")
                    {
                        _myHub.AddMessage("Server", "addmessage sent from server");
                    }
                    if (key.ToUpper() == "E")
                    {
                        _myHub.Heartbeat();
                    }
                    if (key.ToUpper() == "R")
                    {
                        _myHub.SendHelloObject(new HelloModel { Age = 37, Molly = "pushed direct from Server " });
                    }
                    if (key.ToUpper() == "C")
                    {
                        break;
                    }
                }

                Console.ReadLine();
            }
        }

        public void Configuration(IAppBuilder app)
        {
            // Branch the pipeline here for requests that start with "/signalr"
            app.Map("/signalr", map =>
            {
                

                // Setup the CORS middleware to run before SignalR.
                // By default this will allow all origins. You can 
                // configure the set of origins and/or http verbs by
                // providing a cors options with a different policy.
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    // EnableJSONP = true
                };
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch already runs under the "/signalr"
                // path.

                hubConfiguration.EnableDetailedErrors = true;
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}