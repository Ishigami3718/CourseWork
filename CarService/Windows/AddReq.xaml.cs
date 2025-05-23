using System;
using System.Collections.Generic;
using System.Linq;
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
        public static List<IWorker> workers {  get; set; }
        public static List<ServiceExecuting> services {  get; set; }
        public Window1()
        {
            InitializeComponent();
            workers = new List<IWorker>();
            services = new List<ServiceExecuting>();
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
            workers.Add(ClassCreator.CreateWorker(worker));
        }

        public static void TransferService(ServiceExecutingDTO service)
        {
            services.Add(new ServiceExecuting(service)); 
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Car car = ClassCreator.CreateCar(Mark.Text,Model.Text,Plate.Text,int.Parse(Run.Text),DateOnly.FromDateTime((DateTime)RegDate.SelectedDate));
            IClient client = ClassCreator.CreateClient(Name.Text, car, (bool)Regularity.IsChecked, int.Parse(Transmission.Text), double.Parse(Discount.Text));
            Request requst = ClassCreator.CreateRequest(client, services, workers);
            MainWindow.TransferRequest(requst.ToDTO());

        }
    }
}
