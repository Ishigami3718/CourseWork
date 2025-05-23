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
        List<IWorker> workers = new List<IWorker>();

        public IClient Client {  get { return client; } }
        public int Id { get { return id; } }
        public List<ServiceExecuting> Services {  get { return services; } }

        public Request(IClient client, int id, DateOnly date, List<ServiceExecuting> services,double totalPrice ,List<IWorker> workers)
        {
            this.client = client;
            this.id = id;
            this.date = date;
            this.services = services;
            this.totalPrice = totalPrice;
            this.workers = workers;
        }

        public Request(RequestDTO dto)
        {
            client = ClassCreator.CreateClient(dto.Client);
            id = dto.Id;
            date = dto.Date;
            services = dto.Services.Select(i=>new ServiceExecuting(i)).ToList();
        }

        public RequestDTO ToDTO()
        {
            return new RequestDTO()
            {
                Client = client.ToDTO(),
                Id = id,
                Date = date,
                Price = totalPrice,
                Services = services.Select(i => i.ToDto()).ToList(),
                Workers = workers.Select(i => i.ToDto()).ToList()
            };
        }
    }

}
