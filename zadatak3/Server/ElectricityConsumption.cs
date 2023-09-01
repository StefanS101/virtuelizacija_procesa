using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ElectricityConsumption : IElectricityConsumption
    {
        public Tuple<List<Load>, Audit> GetValues(DateTime dateTime)
        {
            Console.WriteLine(dateTime);

            Console.ReadKey();

            return null;
        }
    }
}
