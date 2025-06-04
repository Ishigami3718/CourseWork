using CarService.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
        public static ObservableCollection<RequestDTO> Requests_ => requestsSer;
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
            requestsSer = Serializer.Deserialize<RequestDTO>(@"Orders\Orders.xml");
            requests = new ObservableCollection<RequestDTO>(requestsSer);
            Requests = new Data(requests);
            Data.Navigate(Requests);
            dataAddition = new DataAddition();
            AddData.Navigate(dataAddition);
        }

        public static void TransferRequest(RequestDTO request)
        {
            requests.Add(request);
            requestsSer.Add(request);
        }
        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            new Window1().ShowDialog();
            Serializer.Serialize<RequestDTO>(requestsSer, @"Orders\Orders.xml");
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
            Serializer.Serialize(requestsSer, @"Orders\Orders.xml");
            dataAddition.UpdateData(null);
        }

        private void Workers(object sender, RoutedEventArgs e)
        {
            MainData.Visibility = Visibility.Collapsed;
            MainView.Navigate(new Pages.Workers());
        }

        private void Service(object sender, RoutedEventArgs e)
        {
            MainData.Visibility = Visibility.Collapsed;
            MainView.Navigate(new Pages.Service());
        }

        private void CarInfo_Click(object sender, RoutedEventArgs e)
        {
            CarDTO car=null;
            try
            {
                if (Requests.SelectedReq != null)
                {
                    car = Requests.SelectedReq.Client.Car;
                }
            }
            catch(NullReferenceException) { }
            if(car!=null) new CarInfo(car).ShowDialog();
        }

        private void Clients(object sender, RoutedEventArgs e)
        {
            MainData.Visibility = Visibility.Collapsed;
            MainView.Navigate(new Pages.Clients());
        }

        public static void Redact(RequestDTO request,int id)
        {
            requestsSer[id] = request;
        }

        private void RedactRequest(object sender, RoutedEventArgs e)
        {
            Requests.Redact(requestsSer);
            requests.Clear();
            foreach(RequestDTO request in requestsSer) requests.Add(request);
            Serializer.Serialize<RequestDTO>(requestsSer, @"Orders\Orders.xml");
        }
    }
}
