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
        private static bool InRange(int run,(int,int) range)
        {
            return run>=range.Item1 && run<=range.Item2;
        }
        public static List<ServiceExecuting> DetermServices(Request previousRequest)
        {
            List<Service> services = Serializer.Deserialize<ServiceDTO>(@"Services\Services.xaml").
                Select(i=>new Service(i)).ToList();
            List<ServiceExecuting> res = new List<ServiceExecuting>();
            int run = previousRequest.Client.Car.Run;
            if (InRange(run, (5000, 11000)))
            {
                //res.Add(new ServiceExecuting());
            }
            else if (InRange(run, (24000, 48000)))
            {

            }
            else if (InRange(run, (24000, 48000)))
            {

            }
            return res;
        }
    }
}
