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
        double totalPrice=>CalcPrice();
        List<IWorker> workers = new List<IWorker>();

        public Request(RequestDTO dto)
        {
            client = ClassCreator.CreateClient(dto.Client);
            id = dto.Id;
            date = dto.Date;
            services = dto.Services.Select(i=>new ServiceExecuting(i)).ToList();
        }

        public void SetWorker(WorkerDTO dto, double quota)
        {
            IWorker worker = ClassCreator.CreateWorker(dto);
            worker.Quota = quota;
            workers.Add(worker);
        }

        private double CalcPrice()
        {
            double price = 0;
            foreach (ServiceExecuting service in services) price += service.ToDto().TotalPrice;
            return price;
        }
    }

}
