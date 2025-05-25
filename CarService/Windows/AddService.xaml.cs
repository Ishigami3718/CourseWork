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
using System.Windows.Shapes;

namespace CarService.Windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public  ObservableCollection<Service> Services { get; set; }
        public  ObservableCollection<IDetail> Details { get; set; }

        Service selectedService;

        public static ObservableCollection<IDetail> DetailsToTransfer { get; set; }
        public Window2()
        {
            InitializeComponent();
            Services = Serializer.Deserialize<Service>("Services.Services.xml");
            Details = Serializer.Deserialize<IDetail>("Storage.Details.xml");
            DetailsToTransfer = new ObservableCollection<IDetail>();
            DataContext = this;
        }

        private void SelectService(object sender, RoutedEventArgs e) => selectedService = (Service)ServicesUI.SelectedItem;

        private void SelectDetail(object sender, RoutedEventArgs e)
        {
            DetailsToTransfer.Add(ClassFactory.CreateDetail((DetailDTO)Storage.SelectedItem));
            DataContext = this;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Window1.TransferService(ClassFactory.CreateServiceExexuting(selectedService, DetailsToTransfer).ToDto());
        }
    }
}
