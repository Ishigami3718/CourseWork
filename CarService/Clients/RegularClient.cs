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

        public  ClientDTO ToDTO()
        {
            ClientDTO dto = ((Client)this).ToDTO();
            dto.Transmission = transmission;
            dto.Discount = discount;
            return dto;
        }
        public RegularClient(ClientDTO dto):base(dto) { transmission = (int)dto.Transmission;discount = (double)dto.Discount; }
    }
}
