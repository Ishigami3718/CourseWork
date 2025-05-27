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
        private ObservableCollection<DetailDTO> DetailsSer;
        public  ObservableCollection<IDetail> Details { get; set; }

        Service selectedService;

        public static ObservableCollection<IDetail> DetailsToTransfer { get; set; }
        public Window2()
        {
            InitializeComponent();
            DetailsSer = Serializer.Deserialize<DetailDTO>(@"Storage\Storage.xml");
            Services =new ObservableCollection<Service>(Serializer.Deserialize<ServiceDTO>(@"Services\Services.xml").Select(i=>ClassFactory.CreateService(i)).ToList());
            Details =new ObservableCollection<IDetail>(DetailsSer.Select(i=>ClassFactory.CreateDetail(i)).ToList());
            DetailsToTransfer = new ObservableCollection<IDetail>();
            DataContext = this;
        }

        private void SelectService(object sender, RoutedEventArgs e) => selectedService = (Service)ServicesUI.SelectedItem;

        private void SelectDetail(object sender, RoutedEventArgs e)
        {
            DetailsToTransfer.Add(ClassFactory.CreateDetail(((IDetail)Storage.SelectedItem).ToDTO()));
            // Відняти кількість
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Window1.TransferService(ClassFactory.CreateServiceExexuting(selectedService, DetailsToTransfer).ToDto());
        }
    }
}
