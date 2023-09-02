using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Client
{
    public  class CSVManipulation
    {
        public void MakeCSVFile(List<Load> data, string failePath)
        {
            
            string tekst = PretvoriListuUString(data);
            MemoryStream ms = GenerisanjeStrimaOdStringa(tekst);

            
            if (File.Exists(failePath))
            {
                
                File.Delete(failePath);
            }

            
            using (FileStream csv = new FileStream(failePath, FileMode.CreateNew, FileAccess.Write))
            {
                csv.Write(ms.ToArray(), 0, ms.ToArray().Length);
                csv.Dispose();
            }

            
            ms.Dispose();
        }

        public string PretvoriListuUString(List<Load> zaUpis)
        {
            string strim = "";
            strim += "TIME_STAMP,FORECAST_VALUE,MEASURED_VALUE\n";

            foreach (Load l in zaUpis)
            {
                strim += l.TimeStamp.ToString("yyyy-MM-dd") + ",";
                strim += l.TimeStamp.ToString("HH:mm") + ",";
                strim += l.ForecastValue.ToString().Replace(",", ".") + ",";
                strim += l.MeasuredValue.ToString().Replace(",", ".") + "\n";
            }

            return strim;
        }

        public static MemoryStream GenerisanjeStrimaOdStringa(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}
