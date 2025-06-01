using CarService.Clients;
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
        private static ObservableCollection<ClientDTO> ClientSer = Serializer.Deserialize<ClientDTO>(@"Clients\RegularClients.xml");

        public static int IdToNewClient { get 
            {
                if (ClientSer.Count != 0) return ClientSer[ClientSer.Count - 1].Id;
                else return 0;
            } 
        }

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

        private void Sorting(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            but.ContextMenu.IsOpen = true;
        }

        private void ByName(object sender, RoutedEventArgs e) => Utils.SortingUtils.ByName(ClientsDis);

        private void ById(object sender, RoutedEventArgs e) => Utils.SortingUtils.ById(ClientsDis);

        private void CarInfo_Click(object sender, RoutedEventArgs e)
        {
            CarDTO car = ((ClientDTO)ClientsTable.SelectedItem).Car;
            if (car != null) new CarInfo(car).ShowDialog();
        }

        public static void Redact(ClientDTO client, int id)
        {
            ClientSer[id] = client;
            ClientsDis.Clear();
            foreach (var i in ClientSer) ClientsDis.Add(i);
        }
        private void Redact(object sender, RoutedEventArgs e)
        {
            ClientDTO clientToRedact = ClientsTable.SelectedItem as ClientDTO;
            new AddRegularClient(clientToRedact, ClientSer.IndexOf(clientToRedact)).ShowDialog();
            Serializer.Serialize(ClientSer, @"Clients\RegularClients.xml");
        }

        private void NextRequest(object sender, RoutedEventArgs e)
        {
            ClientDTO toNext = ClientsTable.SelectedItem as ClientDTO;
            if (toNext != null)
            {
                new NextRequest(toNext).ShowDialog();
            }
        }

        private void CloseOrders(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ClientDTO> clientToService = new ObservableCollection<ClientDTO>();
            for(int i = 0; i < ClientSer.Count; i++)
            {
                ObservableCollection<RequestDTO> previousReq =new ObservableCollection<RequestDTO> (MainWindow.Requests_.Where(j => j.Client.Id == ClientSer[i].Id));
                DateTime previousDate;
                if (previousReq.Count != 0)
                {
                    previousDate = previousReq.Last().Date;
                    TimeSpan diff = DateTime.Now - previousDate;
                    if (diff.Days > (int)ClientSer[i].Transmission * 30 - 14) clientToService.Add(ClientSer[i]);
                }
            }
            if (clientToService.Count == 0) MessageBox.Show("В ближні 14 днів замовлень не передбчено");
            else
            {
                ClientsDis.Clear();
                foreach (var i in clientToService) ClientsDis.Add(i);
            }
        }
    }
}
