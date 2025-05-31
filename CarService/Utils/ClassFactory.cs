using CarService.Clients;
using CarService.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace CarService.Utils
{
    public abstract class Factory
    {
        public abstract IClient Create(string name, Car car);
    }

    public  class ClientFactory:Factory
    {
        public override IClient Create(string name, Car car)
        {
            return new Client(MainWindow.LastId + 1, name, car);
        }
    }

    public  class RegularClientFactory : Factory
    {
        int transmission;
        double discount;

        public RegularClientFactory(int transmission, double discount)
        {
            this.discount = discount;
            this.transmission = transmission;
        }
        public override IClient Create(string name, Car car)
        {
            return new RegularClient(MainWindow.LastId + 1, name, car,transmission,Math.Round(discount/100,3));
        }
    }
    public class ClassFactory
    {
        //OCP SRP
        public static IClient CreateClient(ClientDTO dto)
        {
            if (dto.Transmission != null) return new RegularClient(dto);
            return new Client(dto);
        }

        public static IClient CreateClient(bool isRegular, string name, Car car,int? transmission,double? discount)
        {
            Factory factory;
            if (isRegular) factory = new RegularClientFactory((int)transmission, (double)discount);
            else factory = new ClientFactory();
            return factory.Create(name, car);
        }

        public static Car CreateCar(string mark, string model, string licensePlate, int run, DateTime reqisterDate)
        {
            return new Car(mark, model, licensePlate, run, reqisterDate);
        }

        public static IWorker CreateWorker(WorkerDTO dto)
        {
            return new Worker(dto);
        }

        public static IWorker CreateWorker(string name, double salary)
        {
            return new Worker(name,salary);
        }

        public static IDetail CreateDetail(DetailDTO dto)
        {
            return new Detail(dto);
        }

        public static IDetail CreateDetail(string name, string model, double price, double count, string value)
        {
            return new Detail(name,model,price,count,value);
        }

        public static Request    CreateRequest(IClient client, ObservableCollection<ServiceExecuting> services, ObservableCollection<IWorker> workers)
        {
            return new Request(client, MainWindow.LastId + 1, DateTime.Now, services, workers);
        }

        public static ServiceExecuting CreateServiceExexuting(Services.Service service, ObservableCollection<IDetail> details)
        {
            return new ServiceExecuting(service, details);
        }

        public static Services.Service CreateService(ServiceDTO service)
        {
            return new Services.Service(service);
        }

        public static Services.Service CreateService(string name, double price)
        {
            return new Services.Service(name, price);
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
