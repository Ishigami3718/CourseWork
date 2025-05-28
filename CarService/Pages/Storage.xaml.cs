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
    /// Interaction logic for Storage.xaml
    /// </summary>
    public partial class Storage : Page
    {
        public static ObservableCollection<DetailDTO> Details {  get; set; }
        public static ObservableCollection<DetailDTO> DetailsSer { get; set; }
        public Storage()
        {
            InitializeComponent();
            DetailsSer = Serializer.Deserialize<DetailDTO>(@"Storage\Storage.xml");
            Details = new ObservableCollection<DetailDTO>(DetailsSer);
            DataContext = this;
        }

        private void AddDetail(object sender, RoutedEventArgs e)
        {
            new AddDetail().ShowDialog();
            Serializer.Serialize<DetailDTO>(DetailsSer, @"Storage\Storage.xml");
        }

        public static void TransferDetail(DetailDTO detail)
        {
            DetailsSer.Add(detail);
            Details.Add(detail);
        }

        private void StartSearching(object sender, KeyboardFocusChangedEventArgs e)
        {
            Search.Text = string.Empty;
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            string ser = Search.Text;
            Utils.Searching.SearchByName(ser, Details, DetailsSer);
        }

        private void LeaveSearching(object sender, KeyboardFocusChangedEventArgs e)
        {
            string ser = Search.Text;
            if (string.IsNullOrEmpty(ser)) Search.Text = "Введіть для пошуку";
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            DetailDTO toDelete = DetailsTable.SelectedItem as DetailDTO;
            DetailsSer.Remove(toDelete);
            Details.Remove(toDelete);
            Serializer.Serialize(DetailsSer, @"Storage\Storage.xml");
        }

        private void ByName(object sender, RoutedEventArgs e) => Utils.SortingUtils.ByName(Details);

        private void ByCount(object sender, RoutedEventArgs e)=> Utils.SortingUtils.ByCount(Details);

        private void ByPrice(object sender, RoutedEventArgs e)=> Utils.SortingUtils.ByPrice(Details);
    }
}
