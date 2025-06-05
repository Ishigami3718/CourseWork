using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NextRequest.xaml
    /// </summary>
    public partial class NextRequest : Window
    {
        public static ObservableCollection<Services.ServiceExecuting> Services { get; set; }
        public static ObservableCollection<IWorker> workers { get; set; }

        private ClientDTO client;
        public static ObservableCollection<DetailDTO> detailsSerialize;
        static ObservableCollection<DetailDTO> detailsToService;
        int newRun;
        public NextRequest(ClientDTO client)
        {
            InitializeComponent();
            Services = new ObservableCollection<Services.ServiceExecuting>();
            workers = new ObservableCollection<IWorker>();
            this.client = client;
            DataContext = this;
        }

        private void CurrentRun_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void FormServices(object sender, RoutedEventArgs e)
        {
            try
            {
                int currRun;
                List<RequestDTO> previousRequests = MainWindow.Requests_.Where(i => i.Client.Id == client.Id && i is RegularClient).ToList();
                if (previousRequests.Count > 0)
                {
                    RequestDTO previousRequest = previousRequests.Last();
                    currRun = int.Parse(CurrentRun.Text);
                    newRun = currRun;
                    int run = currRun-previousRequest.Client.Car.Run;
                    ObservableCollection<Services.ServiceExecuting> services =
                        new ObservableCollection<Services.ServiceExecuting>(ServiceManager.DetermServicesByRunDiff(run, previousRequest.Client));
                    Services.Clear();
                    foreach (var i in services) Services.Add(i);
                }
                else
                {
                    currRun = int.Parse(CurrentRun.Text);
                    newRun = currRun;
                    ObservableCollection<Services.ServiceExecuting> services =
                        new ObservableCollection<Services.ServiceExecuting>(ServiceManager.DetermServicesByRunDiff(currRun, client));
                    Services.Clear();
                    foreach (var i in services) Services.Add(i);
                }
            }
            catch { }
        }

        private void AddWorker(object sender, RoutedEventArgs e)
        {
            AddWorker add = new AddWorker();
            add.WorkerAdded += TransferWorker;
            add.ShowDialog();
        }
        public static void TransferWorker(WorkerDTO worker)
        {
            workers.Add(ClassFactory.CreateWorker(worker));
        }

        public static void TransferDetailsToSerialize(ObservableCollection<DetailDTO> toSerialize)
        {
            detailsSerialize = toSerialize;
        }

        public static void TransferDetails(ObservableCollection<DetailDTO> details)
        {
            detailsToService = details;
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Services.Count == 0 || Services == null || workers.Count==0 || workers==null) 
                { MessageBox.Show("Сервіси не створені, або не назначені робітники");return; }
                Request request = ClassFactory.CreateRequest(ClassFactory.CreateClient(client), MainWindow.LastId + 1, DateTime.Now,
                    Services, workers);
                RequestDTO requestDTO = request.ToDTO();

                List<System.ComponentModel.DataAnnotations.ValidationResult> requestValidationResults =
                        new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                bool isRequestValid = Validator.TryValidateObject(requestDTO, new ValidationContext(requestDTO),
                    requestValidationResults, true);
                if (isRequestValid)
                {
                    MainWindow.TransferRequest(requestDTO);
                    if (detailsSerialize != null) Serializer.Serialize(detailsSerialize, @"Storage\Storage.xml");
                    client.Car.Run = newRun;
                    Serializer.Serialize(MainWindow.Requests_, @"Orders\Orders.xml");
                    this.Close();
                }
                else
                {
                    StringBuilder message = new StringBuilder();
                    foreach (var i in requestValidationResults) message.AppendLine(i.ToString());
                    MessageBox.Show(message.ToString());
                }
            }
            catch { MessageBox.Show("Не всі дані введені"); }
        }

        private void ChooseDetail(object sender, RoutedEventArgs e)
        {
            ServiceExecuting serv = AutoServices.SelectedItem as ServiceExecuting;
            if (serv != null)
            {
                new ChooseDetail(serv.ToDto().Details).ShowDialog();
                Services[Services.IndexOf(serv)].Details = new ObservableCollection<IDetail>
                    (detailsToService.Select(i => ClassFactory.CreateDetail(i)).ToList());
            }
        }
    }
}
