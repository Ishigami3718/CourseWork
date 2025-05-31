using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CarService.Pages
{
    /// <summary>
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : Page
    {
        public static ObservableCollection<ServiceDTO> ServicesSer { get; set; }
        public static ObservableCollection<ServiceDTO> Services {  get; set; }
        public Service()
        {
            InitializeComponent();
            ServicesSer = Serializer.Deserialize<ServiceDTO>(@"Services\Services.xml");
            Services = new ObservableCollection<ServiceDTO>(ServicesSer);
            DataContext = this;
        }

        public static void TransferService(ServiceDTO service)
        {
            Services.Add(service);
            ServicesSer.Add(service);
        }

        private void AddService(object sender, RoutedEventArgs e)
        {
            new AddServiceForStorage().ShowDialog();
            Serializer.Serialize<ServiceDTO>(ServicesSer, @"Services\Services.xml");
        }

        private void StartSearching(object sender, KeyboardFocusChangedEventArgs e)
        {
            Search.Text = string.Empty;
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            string ser = Search.Text;
            Utils.Searching.SearchByName(ser, Services, ServicesSer);
        }

        private void LeaveSearching(object sender, KeyboardFocusChangedEventArgs e)
        {
            string ser = Search.Text;
            if (string.IsNullOrEmpty(ser)) Search.Text = "Введіть для пошуку";
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            ServiceDTO toDelete = ServicesTable.SelectedItem as ServiceDTO;
            ServicesSer.Remove(toDelete);
            Services.Remove(toDelete);
            Serializer.Serialize(ServicesSer, @"Services\Services.xml");
        }

        private void ByName(object sender, RoutedEventArgs e) => Utils.SortingUtils.ByName(Services);

        private void ByPrice(object sender, RoutedEventArgs e) => Utils.SortingUtils.ByPrice(Services);

        public static void Redact(ServiceDTO service,int id)
        {
            ServicesSer[id]= service;
            Services.Clear();
            foreach(var i in ServicesSer) Services.Add(i);
        }
        private void Redact(object sender, RoutedEventArgs e)
        {
            ServiceDTO serviceToRedact = ServicesTable.SelectedItem as ServiceDTO;
            new AddServiceForStorage(serviceToRedact, ServicesSer.IndexOf(serviceToRedact)).ShowDialog();
            Serializer.Serialize(ServicesSer, @"Services\Services.xml");
        }
    }
}
