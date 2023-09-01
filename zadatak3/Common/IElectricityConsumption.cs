using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IElectricityConsumption
    {
        [OperationContract]
        Tuple<List<Load>, Audit> GetValues(DateTime dateTime);
    }
}
