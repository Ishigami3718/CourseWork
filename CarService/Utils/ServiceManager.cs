using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Utils
{
    public class ServiceManager
    {
        public static List<ServiceExecuting> DetermServicesByGlobalRun(int run)
        {
            List<Services.Service> services = Serializer.Deserialize<ServiceDTO>(@"Services\Services.xaml").
                Select(i=>new Services.Service(i)).ToList();
            List<ServiceExecuting> res = new List<ServiceExecuting>();
            if (run<11000)
            {
                //res.Add(new ServiceExecuting());
            }
            else if (run<24000)
            {

            }
            else if (run<48000)
            {

            }
            else if (run < 56000)
            {

            }
            else if (run < 80000)
            {

            }
            else if (run > 80000)
            {

            }
            return res;
        }
    }
}
