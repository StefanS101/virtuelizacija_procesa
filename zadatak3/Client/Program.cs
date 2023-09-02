using Common;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading;
namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Thread.Sleep(1000);

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

            Tuple<List<Load>, Audit> results = channel.GetValues(DateTime.Now);
            if (results.Item1 != null)
            {
                List<Load> loaded = results.Item1;
                foreach (var result in loaded)
                {
                    Console.WriteLine(result.ToString() + "\n");
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
