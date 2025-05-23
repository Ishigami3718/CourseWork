using CarService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.ClassServices
{
    public class Calculator
    {
        const double vat = 0.2;

        public static double CalcPrice(Service service, ObservableCollection<IDetail> details)
        {
            double detailPrice = 0;
            foreach (var i in details)
            {
                detailPrice += i.Price * i.Count;
            }
            return (detailPrice + service.Price) * (1 + vat);
        }
        /*public static double CalcPrice(ServiceExecuting service)
        {
            double detailPrice = 0;
            foreach (var i in service.Details)
            {
                detailPrice += i.Price * i.Count;
            }
            return (detailPrice + service.Service.Price) * (1 + vat);
        }*/

        public static double CalcFullPrice(ObservableCollection<ServiceExecuting> services,IClient client)
        {
            double price = 0;
            foreach (ServiceExecuting service in services) price += service.TotalPrice;
            return price * (1.0 - client.Discount);
        }
    }
}
