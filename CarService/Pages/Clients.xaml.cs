using CarService.Orders;
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
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        public static ObservableCollection<ClientDTO> ClientsDis {  get; set; }
        private static ObservableCollection<ClientDTO> ClientSer;

        public Clients()
        {
            InitializeComponent();
            ClientSer = Serializer.Deserialize<ClientDTO>(@"Clients\RegularClients.xml");
            ClientsDis = new ObservableCollection<ClientDTO>(ClientSer);
            DataContext = this;
        }

        public static void TransferClient(ClientDTO client)
        {
            ClientsDis.Add(client);
            ClientSer.Add(client);
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            new AddRegularClient().ShowDialog();
            Serializer.Serialize<ClientDTO>(ClientSer, @"Clients\RegularClients.xml");
        }

        private void StartSearching(object sender, KeyboardFocusChangedEventArgs e)
        {
            Search.Text = string.Empty;
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            string ser = Search.Text;
            Utils.Searching.SearchByName(ser, ClientsDis, ClientSer);
        }

        private void LeaveSearching(object sender, KeyboardFocusChangedEventArgs e)
        {
            string ser = Search.Text;
            if (string.IsNullOrEmpty(ser)) Search.Text = "Введіть для пошуку";
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            ClientDTO toDelete = ClientsTable.SelectedItem as ClientDTO;
            ClientSer.Remove(toDelete);
            ClientsDis.Remove(toDelete);
            Serializer.Serialize(ClientSer, @"Clients\RegularClients.xml");
        }

        private void ByName(object sender, RoutedEventArgs e) => Utils.SortingUtils.ByName(ClientsDis);

        private void ById(object sender, RoutedEventArgs e) => Utils.SortingUtils.ById(ClientsDis);

        private void CarInfo_Click(object sender, RoutedEventArgs e)
        {
            CarDTO car = ((ClientDTO)ClientsTable.SelectedItem).Car;
            if (car != null) new CarInfo(car).ShowDialog();
        }
    }
}
