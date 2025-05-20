using CarService.Services;
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

        public static Request CreateRequest(IClient client,int id,DateOnly date,List<ServiceExecuting> services,List<IWorker> workers)
        {
            return new Request(client,id,date,services,Calculator.CalcFullPrice(services,client),workers);
        }

        public static ServiceExecuting CreateServiceExexuting(Service service,List<IDetail> details)
        {
            return new ServiceExecuting(service,details, Calculator.CalcPrice(service, details));
        }
    }

    public class WorkerSetter
    {
        public static void SetWorker(List<IWorker> workers, WorkerDTO dto, double quota)
        {
            IWorker worker = ClassCreator.CreateWorker(dto);
            worker.Quota = quota;
            workers.Add(worker);
        }
    }
}
