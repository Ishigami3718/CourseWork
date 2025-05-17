using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services
{
    public class ServiceExecutingDTO
    {
        public ServiceDTO Service { get; set; }
        public List<DetailDTO> Details {  get; set; }
        public List<WorkerDTO> WorkerDTOs { get; set; }

        public double TotalPrice {  get; set; }
    }
}
