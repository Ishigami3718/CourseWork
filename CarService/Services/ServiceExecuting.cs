using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services
{
    public class ServiceExecuting
    {
        Service service;
        ObservableCollection<IDetail> details;
        
        double totalPrice;

        public double TotalPrice { get { return totalPrice; } }
        /*public Service Service { get { return service; } }
        public List<IDetail> Details { get { return details; } }*/


        public ServiceExecuting(Service service, ObservableCollection<IDetail> details,double totalPrice)
        {
            this.service = service;
            this.details = details;
            this.totalPrice = totalPrice;
        }

        public ServiceExecuting(ServiceExecutingDTO dto)
        {
            service = new Service(dto.Service);
            details = new ObservableCollection<IDetail>(dto.Details.Select(i=>ClassCreator.CreateDetail(i)));
        }

        public ServiceExecutingDTO ToDto()
        {
            return new ServiceExecutingDTO { Details = details.Select(i => i.ToDTO()).ToList(), Service = service.ToDto(), TotalPrice = totalPrice };
        }
    }
}
