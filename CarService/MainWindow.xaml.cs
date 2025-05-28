using CarService.Orders;
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
        static ObservableCollection<RequestDTO> requests;
        static ObservableCollection<RequestDTO> requestsSer;
        DataAddition dataAddition;
        Data Requests;
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
            requestsSer = Serializer.Deserialize<RequestDTO>(@"Orders\Requests.xml");
            ObservableCollection<ServiceExecutingDTO> ser = new ObservableCollection<ServiceExecutingDTO>();
            ser.Add(new ServiceExecutingDTO() {Service=new ServiceDTO() { Name="ddd",Price=450} });
            RequestDTO r = new RequestDTO { Client = new ClientDTO() { Name="Ростислав Лещенко"}, 
                Date = new DateOnly(2025, 4, 12), Id = 1, Price = 1500, Services = ser,
                Workers=new ObservableCollection<WorkerDTO>() { new WorkerDTO() {Name="Kalpas Sidorov",Quota=1.0} } };
            RequestDTO r1 = new RequestDTO
            {
                Client = new ClientDTO() { Name = "Петренко Петро" },
                Date = new DateOnly(2024, 7, 10),
                Id = 2,
                Price = 700,
                Services = ser,
                Workers = new ObservableCollection<WorkerDTO>() { new WorkerDTO() { Name = "Вадим Зубенко", Quota = 1.0 } }
            };
            requestsSer.Add(r);
            requestsSer.Add(r1);
            requests = new ObservableCollection<RequestDTO>(requestsSer);
            Requests = new Data(requests);
            Data.Navigate(Requests);
            dataAddition = new DataAddition();
            AddData.Navigate(dataAddition);
        }

        public static void TransferRequest(RequestDTO request)
        {
                requests.Add(request);
        }
        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            new Window1().ShowDialog();
        }

        public void Update(RequestDTO request)
        {
            dataAddition.UpdateData(request);
        }

        private void Sorting(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            but.ContextMenu.IsOpen = true;
        }

        private void ByName(object sender, RoutedEventArgs e) => Utils.SortingUtils.ByName(requests);
        private void ByDate(object sender, RoutedEventArgs e) => Utils.SortingUtils.ByDate(requests);
        private void ById(object sender, RoutedEventArgs e) => Utils.SortingUtils.ById(requests);

        private void StartSearching(object sender, KeyboardFocusChangedEventArgs e)
        {
            Search.Text = string.Empty;
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            string ser = Search.Text;
            Utils.Searching.SearchByName(ser, requests, requestsSer);
        }

        private void LeaveSearching(object sender, KeyboardFocusChangedEventArgs e)
        {
            string ser = Search.Text;
            if (string.IsNullOrEmpty(ser)) Search.Text = "Введіть для пошуку";
        }

        private void Storage(object sender, RoutedEventArgs e)
        {
            MainData.Visibility = Visibility.Collapsed;
            MainView.Navigate(new Pages.Storage());
        }

        private void Orders(object sender, RoutedEventArgs e)
        {
            MainView.Content = null;
            MainData.Visibility = Visibility.Visible;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            RequestDTO toDelete = Requests.SelectedReq;
            requestsSer.Remove(toDelete);
            requests.Remove(toDelete);
            dataAddition.UpdateData(null);
        }
    }
}
