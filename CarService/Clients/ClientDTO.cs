using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Clients
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CarDTO Car { get; set; }

        public int? Transmission {  get; set; }

        public double? Discount { get; set; }

    }
}
