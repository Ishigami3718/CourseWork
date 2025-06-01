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
        static List<Services.Service> baseServices = new List<Services.Service>()
        {
            new Services.Service("Заміна моторного масла",350),
            new Services.Service("Заміна Масляного фільтра",200),
            new Services.Service("Заміна повітряного фільтра",275),
            new Services.Service("Заміна гальмівної рідини",450),
            new Services.Service("Заміна антифризу",600),
            new Services.Service("Заміна свічок зпалювання",400),
            new Services.Service("Заміна гальмівних колодок",1000),
            new Services.Service("Заміна ремня ГРМ",2750),
            new Services.Service("Перевірка/заміна акамулятора",200)
        };

        static Dictionary<Services.Service, int> servicesByRunDiff;

        public static List<ServiceExecuting> DetermServicesByRunDiff(int newRun, ClientDTO previousRequest)
        {
            List<Services.Service> services = Serializer.Deserialize<ServiceDTO>(@"Services\Services.xaml").
                Select(i => new Services.Service(i)).ToList();
            List<ServiceExecuting> res = new List<ServiceExecuting>();
            servicesByRunDiff = new Dictionary<Services.Service, int>()
            {
                {baseServices[0],10000},
                {baseServices[1],10000},
                {baseServices[2],30000},
                {baseServices[3],60000},
                {baseServices[4],60000},
                {baseServices[5],60000},
                {baseServices[6],90000},
                {baseServices[7],90000},
                {baseServices[8],90000}
            };
            int previousRun;
            previousRun = previousRequest.Car.Run;
            int runDiff = newRun - previousRun;
            foreach (var service in servicesByRunDiff)
            {
                if (runDiff > service.Value)
                {
                    res.Add(ClassFactory.CreateServiceExexuting(service.Key, new ObservableCollection<IDetail>()));
                }
            }
            return res;
        }
    }
}
