using System;
using System.ServiceModel;

namespace UNO_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(UNO_Server.UNOServices));
            host.Open();
            Console.WriteLine("Server is running");
            Console.ReadLine();
        }
    }
}
