using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services
{
    public class ServiceExecuting
    {
        Service service;
        List<Detail>? details;
        const double vat = 0.2;
        IWorker worker;
        double totalPrice=>CalcPrice();

        private double CalcPrice()
        {
            double detailPrice = 0;
            foreach(var i in details)
            {
                DetailDTO currDetail = i.ToDto();
                detailPrice += currDetail.Price*currDetail.Count;
            }
            return (detailPrice+service.Price)*(1+vat);
        }
    }
}
