using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.ClassServices
{
    public class ClientCreator
    {
        //OCP SRP
        public static IClient CreateClient(ClientDTO dto)
        {
            if (dto.Transmission != null) return new RegularClient(dto);
            return new Client(dto);
        }
    }
}
