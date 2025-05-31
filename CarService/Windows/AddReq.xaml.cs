using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarService.Windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static ObservableCollection<IWorker> Workers {  get; set; }
        public static ObservableCollection<ServiceExecuting> Services {  get; set; }

        public static ObservableCollection<DetailDTO> detailsSerialize;

        private ObservableCollection<ClientDTO> RegularClient;
        private bool isRedact = false;
        private int idToRedact;
        DateTime dateFromRedact;
        public Window1()
        {
            InitializeComponent();
            Workers = new ObservableCollection<IWorker>();
            Services = new ObservableCollection<ServiceExecuting>();
            RegularClient = Serializer.Deserialize<ClientDTO>(@"Clients\RegularClients.xml");
            detailsSerialize = null;
            DataContext = this;
        }

        public Window1(RequestDTO request,int id)
        {
            InitializeComponent();
            Workers = new ObservableCollection<IWorker>(request.Workers.Select(i => ClassFactory.CreateWorker(i)).ToList());
            Services = new ObservableCollection<ServiceExecuting>(request.Services.Select(i => ClassFactory.
            CreateServiceExexuting(i)).ToList());
            detailsSerialize = null;
            Name.Text = request.ClientName;
            Transmission.Text = request.Client.Transmission.ToString();
            Discount.Text = (request.Client.Discount*100).ToString();
            Mark.Text = request.Client.Car.Mark;
            Model.Text = request.Client.Car.Model;
            Plate.Text = request.Client.Car.LicensePlate;
            Run.Text = request.Client.Car.Run.ToString();
            RegDate.SelectedDate = request.Client.Car.RegisterDate;
            RegularClient = Serializer.Deserialize<ClientDTO>(@"Clients\RegularClients.xml");
            isRedact = true;
            idToRedact = id;
            if (ClassFactory.CreateClient(request.Client) is RegularClient) Regularity.IsChecked = true;
            dateFromRedact = request.Date;
            DataContext = this;
        }

        private void AddService(object sender, RoutedEventArgs e)
        {
            new Window2().ShowDialog();
        }

        private void AddWorker(object sender, RoutedEventArgs e)
        {
            new AddWorker().ShowDialog();
        }

        public static void TransferWorker(WorkerDTO worker)
        {
            Workers.Add(ClassFactory.CreateWorker(worker));
        }

        public static void TransferService(ServiceExecutingDTO service)
        {
            Services.Add(new ServiceExecuting(service)); 
        }

        public static void TransferDetailsToSerialize(ObservableCollection<DetailDTO> toSerialize)
        {
            detailsSerialize = toSerialize;
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = ClassFactory.CreateCar(Mark.Text, Model.Text, Plate.Text, int.Parse(Run.Text), (DateTime)RegDate.SelectedDate);
                int? transmission;
                double? discount;
                if (string.IsNullOrWhiteSpace(Transmission.Text)) transmission = null;
                else transmission = int.Parse(Transmission.Text);
                if (string.IsNullOrWhiteSpace(Discount.Text)) discount = null;
                else discount = double.Parse(Discount.Text);
                IClient client = ClassFactory.CreateClient((bool)Regularity.IsChecked, Name.Text, car,
                    transmission, discount);
                if (client is RegularClient)
                {
                    RegularClient.Add(client.ToDTO());
                    Serializer.Serialize(RegularClient, @"Clients\RegularClients.xml");
                }
                Request requst;
                if (isRedact) requst = ClassFactory.CreateRequest(client, idToRedact + 1, dateFromRedact, Services, Workers);
                else requst = ClassFactory.CreateRequest(client, MainWindow.LastId + 1, DateTime.Now, Services, Workers);
                if (Workers.Count != 0 && Services.Count != 0)
                {
                    if (isRedact) MainWindow.Redact(requst.ToDTO(), idToRedact);
                    else MainWindow.TransferRequest(requst.ToDTO());
                }
                if (detailsSerialize != null) Serializer.Serialize(detailsSerialize, @"Storage\Storage.xml");
            }
            catch { }
            this.Close();
        }

        private void ClearServices(object sender, RoutedEventArgs e) 
        { 
            Services.Clear();
            detailsSerialize = null;
        }


        private void ClearWorkers(object sender, RoutedEventArgs e) => Workers.Clear();

        private void SelectRegularWorker(object sender, RoutedEventArgs e)
        {

        }

        private void Regularity_Click(object sender, RoutedEventArgs e)
        {
            if(Regularity.IsChecked == true)
            {
                Transmission.IsEnabled = true;
                Discount.IsEnabled = true;
            }
            else
            {
                Transmission.IsEnabled = false;
                Discount.IsEnabled = false;
            }
        }
    }
}
