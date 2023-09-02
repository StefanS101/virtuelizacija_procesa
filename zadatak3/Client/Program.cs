using Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            int option;
            DateTime time = DateTime.Now;
            do
            {
                Console.WriteLine("1. current date");
                Console.WriteLine("2. Custom date:");
                Console.WriteLine("0. Exit");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: break;
                    case 2:
                        Console.WriteLine("unesite datum u formatu dd/mm/yyyy");
                        string s = Console.ReadLine();
                        string[] elementi = s.Split('/');
                        Console.WriteLine(elementi);
                        Console.WriteLine(elementi[0]);
                        time = new DateTime(Int32.Parse(elementi[2]), Int32.Parse(elementi[1]), Int32.Parse(elementi[0]) );
                        break;
                    case 3:
                        throw new Exception();
                        
                }


                Tuple<List<Load>, Audit> results = channel.GetValues(time);
                if (results.Item1 != null)
                {
                    List<Load> loaded = results.Item1;
                    foreach (var result in loaded)
                    {
                        Console.WriteLine(result.ToString() + "\n");
                    }
                }


            } while (option != 0);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
