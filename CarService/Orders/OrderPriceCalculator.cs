using CarService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Orders
{
    public class OrderPriceCalculator
    {
        const double vat = 0.2;

        public static double CalcPrice(Services.Service service, ObservableCollection<IDetail> details)
        {
            double detailPrice = 0;
            foreach (var i in details)
            {
                detailPrice += DetailPriceCalculator.CalcPrice(i);
            }
            return (detailPrice + service.Price) * (1 + vat);
        }

        public static double CalcFullPrice(ObservableCollection<ServiceExecuting> services, IClient client)
        {
            double price = 0;
            foreach (ServiceExecuting service in services) price += service.TotalPrice;
            return price * (1.0 - client.Discount);
        }
    }
}
