using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Clients
{
    public class RegularClient:Client,IClient
    {
        int transmission;
        double discount;

        public override double Discount => discount;

        public RegularClient(int id, string name, Car car,int transmission,double discount) : base(id, name, car)
        {
            this.transmission = transmission;
            this.discount = discount;
        }

        
        /*public RegularClient(Client client,int transmission,double discount):base(client)
        {
            this.discount = discount;
        }*/
        
        public override ClientDTO ToDTO()
        {
            ClientDTO dto = base.ToDTO();
            dto.Transmission = transmission;
            dto.Discount = discount;
            return dto;
        }
        public RegularClient(ClientDTO dto):base(dto) { transmission = (int)dto.Transmission;discount = (double)dto.Discount; }
    }
}
