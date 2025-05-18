using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.ClassServices
{
    public class ClassCreator
    {
        //OCP SRP
        public static IClient CreateClient(ClientDTO dto)
        {
            if (dto.Transmission != null) return new RegularClient(dto);
            return new Client(dto);
        }

        public static IWorker CreateWorker(WorkerDTO dto)
        {
            return new Worker(dto);
        }

        public static IDetail CreateDetail(DetailDTO dto)
        {
            return new Detail(dto);
        }
    }
}
