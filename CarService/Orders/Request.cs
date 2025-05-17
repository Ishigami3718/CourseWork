using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Orders
{
    public class Request
    {
        IClient client;
        int id;
        DateOnly date;
        List<ServiceExecuting> services;
        double totalPrice;

        public Request(RequestDTO dto)
        {
            client = ClassCreator.CreateClient(dto.Client);
            id = dto.Id;
            date = dto.Date;
            services = dto.Services.Select(i=>new ServiceExecuting(i)).ToList();
            totalPrice = dto.Price;
        }
    }

}
