using Common;
using DataBaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ElectricityConsumption : IElectricityConsumption
    {
        public static Dictionary<int, Load> loadServer = new Dictionary<int, Load>(10);
        public static Dictionary<int, Audit> auditServer = new Dictionary<int, Audit>(10);
        public Tuple<List<Load>, Audit> GetValues(DateTime dateTime)
        {
            List<Load> searched_values = InMemorySearch(dateTime);

            if (searched_values.Count > 0)
            {

                Audit a = new Audit(dateTime, MessageTypes.SUCCESS, $"Results for {dateTime}");
                foreach (var item in searched_values)
                {
                    loadServer.Add(item.Id, item);

                    auditServer.Add(a.Id, a);
                }

            }



            Console.ReadKey();

            return null;
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
