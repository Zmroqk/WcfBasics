using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfLibrary;
using System.ServiceModel.Description;

namespace WcfService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/WcfLibrary/");
            ServiceHost host = new ServiceHost(typeof(Calculator), baseAddress);
            try
            {
                host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "Calculator");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);

                host.Open();
                Console.WriteLine("Service is ready");
                Console.ReadKey();
                host.Close();
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine("Error: ");
                Console.Error.WriteLine(ex.Message);
                host.Abort();
                Console.ReadKey();
            }           
        }
    }
}
