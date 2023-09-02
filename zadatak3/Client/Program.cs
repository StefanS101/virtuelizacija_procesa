using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.Threading;

namespace Client
{
    internal class Program
    {
        static void process(IElectricityConsumption channel, DateTime time)
        {
            Tuple<List<Load>, Audit> results = channel.GetValues(time);
            if (results.Item1 != null && results.Item1.Count > 0)
            {
                List<Load> loaded = results.Item1;
                foreach (var result in loaded)
                {
                    Console.WriteLine(result.ToString() + "\n");
                }

                CSVManipulation csv = new CSVManipulation();


                string direktorijumZaCsvDatoteka = ConfigurationManager.AppSettings["putanja"];
                string imeDatoteke = "results_" + results.Item1[0].TimeStamp.ToString("yyyy_MM_dd") + ".csv";
                string putanjaDatoteke = direktorijumZaCsvDatoteka + "\\" + imeDatoteke;



                csv.MakeCSVFile(loaded, putanjaDatoteke);
            }
            else if (results.Item2 != null)
            {
                Console.WriteLine(results.Item2.ToString());
            }
        }

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
                Console.WriteLine("0. Exit application");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        process(channel, time);
                        break;
                    case 2:
                        Console.WriteLine("unesite datum u formatu dd/mm/yyyy");
                        string s = Console.ReadLine();
                        string[] elementi = s.Split('/');
                        time = new DateTime(Int32.Parse(elementi[2]), Int32.Parse(elementi[1]), Int32.Parse(elementi[0])); process(channel, time);
                        break;
                    case 3:
                        break;



                }





            } while (option != 0);
            
        }
    }
}
