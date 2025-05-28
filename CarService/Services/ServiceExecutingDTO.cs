using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services
{
    public class ServiceExecutingDTO
    {
        public ServiceDTO Service { get; set; }
        public ObservableCollection<DetailDTO> Details {  get; set; }

        public double TotalPrice {  get; set; }
    }
}
