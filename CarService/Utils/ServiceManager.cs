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
            new Services.Service("Заміна моторного масла",1),
            new Services.Service("Заміна Масляного фільтра",1),
            new Services.Service("Заміна повітряного фільтра",1),
            new Services.Service("Заміна гальмівної рідини",1),
            new Services.Service("Заміна антифризу",1),
            new Services.Service("Заміна свічок зпалювання",1),
            new Services.Service("Заміна гальмівних колодок",1),
            new Services.Service("Заміна ремня ГРМ",1),
            new Services.Service("Перевірка/заміна акамулятора",1),
        };

        static Dictionary<Services.Service, int> servicesByRunDiff;
        public static List<ServiceExecuting> DetermServicesByRunDiff(int newRun,RequestDTO previousRequest)
        {
            List<Services.Service> services = Serializer.Deserialize<ServiceDTO>(@"Services\Services.xaml").
                Select(i=>new Services.Service(i)).ToList();
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
            if(previousRequest==null) previousRun = 0;
            else previousRun = previousRequest.Client.Car.Run;
            int runDiff = newRun - previousRun;
            foreach (var service in servicesByRunDiff) 
            {
                if (runDiff > service.Value)
                {
                    res.Add(ClassFactory.CreateServiceExexuting(service.Key,new ObservableCollection<IDetail>()));
                }
            }
            return res;
        }
    }
}
