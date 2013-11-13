using System;
using Damienbod.SignalR.IHubSync.Client.Dto;
using Microsoft.AspNet.SignalR.Client;
using SignalRClientConsole.HubClients;
using SignalRClientConsole.Logging;

namespace SignalRClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client  http://localhost:8089");      
            var myHubClient = new MyHubClient();
            
            while (true)
            {
                string key = Console.ReadLine();
                if (key.ToUpper() == "W")
                {
                    if (myHubClient.State == ConnectionState.Connected)
                    {
                        myHubClient.AddMessage("damien client", "hello all");
                    }
                    else
                    {
                        HubClientEvents.Log.Warning("Can't send message, connectionState= " + myHubClient.State);
                    }
                    
                }
                if (key.ToUpper() == "E")
                {
                    if (myHubClient.State == ConnectionState.Connected)
                    {
                        myHubClient.Heartbeat();
                    }
                    else
                    {
                        HubClientEvents.Log.Warning("Can't send message, connectionState= " + myHubClient.State);
                    }
                    
                }
                if (key.ToUpper() == "R")
                {
                    if (myHubClient.State == ConnectionState.Connected)
                    {
                        var hello = new HelloModel { Age = 10, Molly = "clientMessage" };
                        myHubClient.SendHelloObject(hello);
                    }
                    else
                    {
                        HubClientEvents.Log.Warning("Can't send message, connectionState= " + myHubClient.State);
                    }
                    
                }
                if (key.ToUpper() == "T")
                {
                    myHubClient.CloseHub();
                    HubClientEvents.Log.Informational("Closed Hub");
                }
                if (key.ToUpper() == "Z")
                {
                    myHubClient.StartHub();
                    HubClientEvents.Log.Informational("Started the Hub");
                }
                if (key.ToUpper() == "C")
                {
                    break;
                }
            }

        }
    }
}
