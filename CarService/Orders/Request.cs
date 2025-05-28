using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Orders
{
    public class Request
    {
        IClient client;
        int id;
        DateTime date;
        ObservableCollection<ServiceExecuting> services;
        double totalPrice;
        ObservableCollection<IWorker> workers;

        public IClient Client {  get { return client; } }
        public int Id { get { return id; } }
        public ObservableCollection<ServiceExecuting> Services {  get { return services; } }

        public Request(IClient client, int id, DateTime date, ObservableCollection<ServiceExecuting> services,double totalPrice ,ObservableCollection<IWorker> workers)
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
            client = ClassFactory.CreateClient(dto.Client);
            id = dto.Id;
            date = dto.Date;
            services = new ObservableCollection<ServiceExecuting>(dto.Services.Select(i => new ServiceExecuting(i)));
            workers = new ObservableCollection<IWorker>(dto.Workers.Select(i => ClassFactory.CreateWorker(i)));
        }

        public RequestDTO ToDTO()
        {
            return new RequestDTO()
            {
                Client = client.ToDTO(),
                Id = id,
                Date = date,
                Price = totalPrice,
                Services = new ObservableCollection<ServiceExecutingDTO>(services.Select(i => i.ToDto())),
                Workers = new ObservableCollection<WorkerDTO>(workers.Select(i => i.ToDto()))
            };
        }
    }

}
