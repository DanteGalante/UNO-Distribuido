using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace UNO_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(LoginServices));
            host.Open();
            Console.WriteLine("Server is running");
            Console.ReadLine();
        }
    }
}
