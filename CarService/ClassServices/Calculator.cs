using CarService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.ClassServices
{
    public class Calculator
    {
        const double vat = 0.2;

        public static double CalcPrice(Service service, List<IDetail> details)
        {
            double detailPrice = 0;
            foreach (var i in details)
            {
                detailPrice += i.Price * i.Count;
            }
            return (detailPrice + service.Price) * (1 + vat);
        }
    }
}
