using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<RequestDTO> requests;

        public static int LastId 
        { get 
            { 
               if(requests.Count!=0) return requests[requests.Count-1].Id;
               else return 0;
            } 
        }
        public MainWindow()
        {
            InitializeComponent();
            requests = Serializer.Deserialize<RequestDTO>(@"Orders\Requests.xml");
            List<ServiceExecutingDTO> ser = new List<ServiceExecutingDTO>();
            ser.Add(new ServiceExecutingDTO() {Service=new ServiceDTO() { Name="ddd",Price=450} });
            RequestDTO r = new RequestDTO { Client = new ClientDTO() { Name="Ростислав Лещенко"}, 
                Date = new DateOnly(2025, 4, 12), Id = 1, Price = 1500, Services = ser,
                Workers=new List<WorkerDTO>() { new WorkerDTO() {Name="Kalpas Sidorov",Quota=1.0} } };
            requests.Add(r);
            Data.Navigate(new Data(requests));
            AddData.Navigate(new DataAddition(r));
        }

        public static void TransferRequest(RequestDTO request)
        {
            requests.Add(request);
        }
        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            new Window1().ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Data.Navigate(new Data(requests));
        }
    }
}
