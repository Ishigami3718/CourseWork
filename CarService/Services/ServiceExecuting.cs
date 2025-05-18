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
        List<IDetail> details;
        
        double totalPrice=>Calculator.CalcPrice(service,details);



        public ServiceExecuting(ServiceExecutingDTO dto)
        {
            service = new Service(dto.Service);
            details = dto.Details.Select(i=>ClassCreator.CreateDetail(i)).ToList();
        }

        public ServiceExecutingDTO ToDto()
        {
            return new ServiceExecutingDTO { Details = details.Select(i => ((Detail)i).ToDto()).ToList(), Service = service.ToDto(), TotalPrice = totalPrice };
        }
    }
}
