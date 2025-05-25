using CarService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Utils
{
    public class ClassFactory
    {
        //OCP SRP
        public static IClient CreateClient(ClientDTO dto)
        {
            if (dto.Transmission != null) return new RegularClient(dto);
            return new Client(dto);
        }

        public static IClient CreateClient(string name, Car car, bool isReqular, int transmission, double discount)
        {
            if (isReqular) return new RegularClient(MainWindow.LastId + 1, name, car, transmission, Math.Round(discount / 100, 3));
            else return new Client(MainWindow.LastId + 1, name, car);
        }

        /*
         public static IClient CreateRegularClient(Client client,int transmission, double discount)
        {
            return new RegularClient(client,transmission,discount);
        }
         */

        public static Car CreateCar(string mark, string model, string licensePlate, int run, DateOnly reqisterDate)
        {
            return new Car(mark, model, licensePlate, run, reqisterDate);
        }

        public static IWorker CreateWorker(WorkerDTO dto)
        {
            return new Worker(dto);
        }

        public static IDetail CreateDetail(DetailDTO dto)
        {
            return new Detail(dto);
        }

        public static Request CreateRequest(IClient client, ObservableCollection<ServiceExecuting> services, ObservableCollection<IWorker> workers)
        {
            return new Request(client, MainWindow.LastId + 1, DateOnly.FromDateTime(DateTime.Now), services, OrderPriceCalculator.CalcFullPrice(services, client), workers);
        }

        public static ServiceExecuting CreateServiceExexuting(Service service, ObservableCollection<IDetail> details)
        {
            return new ServiceExecuting(service, details, OrderPriceCalculator.CalcPrice(service, details));
        }
    }

    public class WorkerSetter
    {
        public static void SetWorker(List<IWorker> workers, WorkerDTO dto, double quota)
        {
            IWorker worker = ClassFactory.CreateWorker(dto);
            worker.Quota = quota;
            workers.Add(worker);
        }
    }
}
