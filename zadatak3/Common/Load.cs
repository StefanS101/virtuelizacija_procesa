using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Load
    {
        private string id;
        private DateTime timeStamp;
        private double forecastValue;
        private double measuredValue;

        public Load(string id, DateTime timeStamp, double forecastValue, double measuredValue)
        {
            this.Id = id;
            this.TimeStamp = timeStamp;
            this.ForecastValue = forecastValue;
            this.MeasuredValue = measuredValue;
        }

        public string Id { get => id; set => id = value; }
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        public double ForecastValue { get => forecastValue; set => forecastValue = value; }
        public double MeasuredValue { get => measuredValue; set => measuredValue = value; }
    }
}
