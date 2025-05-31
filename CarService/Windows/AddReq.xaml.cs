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

        private static ObservableCollection<DetailDTO> detailsSerialize;
        public Window1()
        {
            InitializeComponent();
            Workers = new ObservableCollection<IWorker>();
            Services = new ObservableCollection<ServiceExecuting>();
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
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Car car = ClassFactory.CreateCar(Mark.Text, Model.Text, Plate.Text, int.Parse(Run.Text), (DateTime)RegDate.SelectedDate);
                int? transmission;
                double? discount;
                if (string.IsNullOrEmpty(Transmission.Text)) transmission = null;
                else transmission=int.Parse(Transmission.Text);
                if (string.IsNullOrEmpty(Discount.Text)) discount = null;
                else discount = double.Parse(Transmission.Text);
                IClient client = ClassFactory.CreateClient((bool)Regularity.IsChecked,Name.Text,car,
                    int.Parse(Transmission.Text),double.Parse(Discount.Text));
                Request requst = ClassFactory.CreateRequest(client, Services, Workers);
                if (Workers.Count!=0 && Services.Count!=0) MainWindow.TransferRequest(requst.ToDTO());
                if (detailsSerialize != null) Serializer.Serialize(detailsSerialize, @"Details\Details.xml");
            }
            catch { }

        }
    }
}
