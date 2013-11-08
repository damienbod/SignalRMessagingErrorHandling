using System;
using Damienbod.SignalR.MyHub.Dto;
using SignalRClientConsole.HubClients;

namespace SignalRClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client  http://localhost:8089");
            MyHubClient myHubClient = new MyHubClient();
            
            while (true)
            {
                string key = Console.ReadLine();
                if (key.ToUpper() == "W")
                {
                    myHubClient.AddMessage("damien client","hello all");
                }
                if (key.ToUpper() == "E")
                {
                    myHubClient.Heartbeat();
                }
                if (key.ToUpper() == "R")
                {
                    var hello = new HelloModel { Age = 10, Molly = "clientMessage" };
                    myHubClient.SendHelloObject(hello);
                }
                if (key.ToUpper() == "C")
                {
                    break;
                }
            }

        }
    }
}
