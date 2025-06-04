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

        public ObservableCollection<IDetail> Details {  get { return details; } set { if (value.Count != 0 || value != null) details = value; } }

        public double TotalPrice { get { return OrderPriceCalculator.CalcPrice(service, details); } }


        /*public Service Service { get { return service; } }
public List<IDetail> Details { get { return details; } }*/



        public ServiceExecuting(Service service, ObservableCollection<IDetail> details)
        {
            this.service = service;
            this.details = details;
        }

        public ServiceExecuting(ServiceExecutingDTO dto)
        {
            service = new Service(dto.Service);
            details = new ObservableCollection<IDetail>(dto.Details.Select(i=>ClassFactory.CreateDetail(i)));
        }

        public ServiceExecutingDTO ToDto()
        {
            return new ServiceExecutingDTO { Details = new ObservableCollection<DetailDTO>(details.Select(i => i.ToDTO()).ToList()), Service = service.ToDto()};
        }

        public override string ToString()
        {
            return service.ToString();
        }
    }
}
