using System;
using Damienbod.SignalR.MyHub;
using Damienbod.SignalR.MyHub.Dto;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

namespace Damienbod.SignalR.Host
{
    class Program
    {
        private static IMyHub _myHub;

        static void Main(string[] args)
        {
            var url = Configuration.GetInstance().MyHubServiceUrl();

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
                        _myHub.SendHelloObject(new HelloModel {Age = 37, Molly = "pushed direct from Server "});
                    }
                    if (key.ToUpper() == "C")
                    {
                        break;
                    }
                }

                Console.ReadLine();
            }
        }
    }
}
