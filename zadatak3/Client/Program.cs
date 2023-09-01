using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ChannelFactory<IElectricityConsumption> channelFactory = 
                new ChannelFactory<IElectricityConsumption>("connect_server");
            IElectricityConsumption channel;

            try
            {
                channel = channelFactory.CreateChannel();
                Console.WriteLine("Channel created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }

            channel.GetValues(DateTime.Now);

            Console.WriteLine("Closing");
            Console.ReadKey();
        }
    }
}
