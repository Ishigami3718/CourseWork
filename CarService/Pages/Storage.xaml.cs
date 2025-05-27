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
            Details = DetailsSer;
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
        }
    }
}
