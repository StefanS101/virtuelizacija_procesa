using DataBaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InMemoryData.database = new Dictionary<int, Load>();
            InMemoryData.database.Add(1, new Load(DateTime.Now, 155, 152));


            using (ServiceHost host = new ServiceHost(typeof(Server.ElectricityConsumption)))
            {
                host.Open();

                Console.WriteLine("Server is runnung\n");
                Console.WriteLine("Press any key to exit\n");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
