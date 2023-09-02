using Common;
using DataBaseLibrary;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Server
{
    public class ElectricityConsumption : IElectricityConsumption
    {
        public static Dictionary<int, Load> loadServer = new Dictionary<int, Load>(10);
        public static Dictionary<int, Audit> auditServer = new Dictionary<int, Audit>(10);

        //////////
        ///


        static List< Load> ReadFromXML(string xmlFilePath)
        {
            List<Load> list = new List<Load>();
            Load temp = new Load();


            // Create an XmlReaderSettings to specify the settings for the XmlReader
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true; // Ignore whitespace nodes

            try
            {
                using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
                {
                    
                    while (reader.Read()) // Continue reading until the end of the file
                    {

                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            // Check the element name
                            switch (reader.Name)
                            {
                                case "ID":
                                    temp.Id = Int32.Parse(reader.ReadString());
                                    break;
                                case "TIME_STAMP":
                                    temp.TimeStamp = DateTime.Parse(reader.ReadString());
                                    break;
                                case "FORECAST_VALUE":
                                    temp.ForecastValue = Double.Parse(reader.ReadString());
                                    break;
                                case "MEASURED_VALUE":
                                    temp.MeasuredValue = double.Parse(reader.ReadString());
                                    break;
                            }
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "row")
                        {
                            // Process the four fields here for each row
                            list.Add(temp);
                            temp = new Load();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            return list;
        }




        //////

        public Tuple<List<Load>, Audit> GetValues(DateTime dateTime)
        {
            List<Load> searched_values = InMemorySearch(dateTime);

            if (searched_values.Count > 0)
            {

                Audit audit = new Audit(dateTime, MessageTypes.SUCCESS, $"Results for {dateTime.Date}");
                foreach (var item in searched_values)
                {
                    loadServer.Add(item.Id, item);

                    auditServer.Add(audit.Id, audit);
                }
                return new Tuple<List<Load>, Audit>(searched_values, audit);
            }

            else
            {
                List<Load> xmlElements = new List<Load>();
                xmlElements = ReadFromXML("C:\\Users\\Stefan\\Desktop\\virtuelizacija_procesa_projekat\\zadatak3\\DataBaseLibrary\\TBL_LOAD.xml");
                Audit audit = new Audit(dateTime, MessageTypes.SUCCESS, $"Results for {dateTime.Date}");


                if (xmlElements.Count > 0)
                {
                    return new Tuple<List<Load>, Audit>(xmlElements, audit);
                }
                else
                {
                    Audit a = new Audit(dateTime, MessageTypes.ERROR, $"There is no data for day: {dateTime.Date}");
                    List<Load> empty= new List<Load>();
                    return new Tuple<List<Load>, Audit>(empty, a);
                }

            }

        }
        public List<Load> InMemorySearch(DateTime date)
        {
            List<Load> values = new List<Load>();

            foreach (Load item in InMemoryData.database.Values)
            {
                if (item.TimeStamp.Date == date.Date)
                {
                    values.Add(item);
                }
            }
            return values;
        }
    }

     
}

