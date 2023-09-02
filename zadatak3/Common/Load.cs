using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
    [DataContract]
    public class Load
    {
        private int id;
        private DateTime timeStamp;
        private double forecastValue;
        private double measuredValue;
        public static int count = 0;

        public Load(DateTime timeStamp, double forecastValue, double measuredValue)
        {
            ++count;
            this.Id = count;
            this.TimeStamp = timeStamp;
            this.ForecastValue = forecastValue;
            this.MeasuredValue = measuredValue;
        }

        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        [DataMember]
        public double ForecastValue { get => forecastValue; set => forecastValue = value; }
        [DataMember]
        public double MeasuredValue { get => measuredValue; set => measuredValue = value; }
    }
}
