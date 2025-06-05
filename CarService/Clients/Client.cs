using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Clients
{
    public class Client:IClient
    {
        int id;
        string name;
        Car car;

        public virtual double Discount => 0;

        public Client(int id,string name,Car car)
        {
            this.id = id;
            this.name = name;
            this.car = car;
        }
        public Car Car { get { return this.car; } }

        public virtual ClientDTO ToDTO()
        {
            return new ClientDTO
            {
                Id = id,
                Name = name,
                Car = car.ToDTO()
            };
        }

        public Client(ClientDTO dto)
        {
            id = dto.Id;
            name = dto.Name;
            car = new Car(dto.Car);
        }
    }
}
