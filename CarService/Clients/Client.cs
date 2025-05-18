using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Clients
{
    public class Client:IClient
    {
         protected int id;
         protected string name;
         protected Car car;

        public virtual double Discount => 0;

        public ClientDTO ToDTO()
        {
            return new ClientDTO
            {
                Id = id,
                Name = name,
                Car = car
            };
        }

        public Client(ClientDTO dto)
        {
            id = dto.Id;
            name = dto.Name;
            car = dto.Car;
        }
    }
}
