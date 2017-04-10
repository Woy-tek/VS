using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using Lib;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri addr = new Uri("http://localhost:80/Temporary_Listen_Addresses/WCFTest");
            ServiceHost selfHost = new ServiceHost(typeof(BlackHole), addr);
            try
            {
                selfHost.Description.Endpoints.Clear();
                selfHost.AddServiceEndpoint(typeof(IBlackHole), new WSHttpBinding(), "TestServiceEndpoint");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("Server gotowy");
                Console.ReadLine();

                selfHost.Close();
            }catch(CommunicationException E)
            {
                Console.WriteLine("Mamy ERROR!");
                Console.WriteLine(E.Message);
                Console.ReadLine();
                selfHost.Abort();
            }
        }
    }
}
