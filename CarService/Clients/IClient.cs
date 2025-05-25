using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Clients
{
    public interface IClient
    {
        public double Discount {  get; }
        public ClientDTO ToDTO();

        public Car Car { get; }
    }
}
