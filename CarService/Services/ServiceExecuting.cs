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
        List<Detail> details;
        const double vat = 0.2;
        
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


        public ServiceExecuting(ServiceExecutingDTO dto)
        {
            service = new Service(dto.Service);
            details = dto.Details.Select(i=>new Detail(i)).ToList();
        }

        public ServiceExecutingDTO ToDto()
        {
            return new ServiceExecutingDTO { Details = details.Select(i => i.ToDto()).ToList(), Service = service.ToDto(), TotalPrice = totalPrice };
        }
    }
}
