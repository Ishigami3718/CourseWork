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
        public  ObservableCollection<Services.Service> Services { get; set; }
        private ObservableCollection<DetailDTO> DetailsSer;
        public  ObservableCollection<IDetail> Details { get; set; }

        Services.Service selectedService;

        public static ObservableCollection<IDetail> DetailsToTransfer { get; set; }
        public Window2()
        {
            InitializeComponent();
            DetailsSer = Serializer.Deserialize<DetailDTO>(@"Storage\Storage.xml");
            Services =new ObservableCollection<Services.Service>(Serializer.Deserialize<ServiceDTO>(@"Services\Services.xml").Select(i=>ClassFactory.CreateService(i)).ToList());
            Details =new ObservableCollection<IDetail>(DetailsSer.Select(i=>ClassFactory.CreateDetail(i)).ToList());
            DetailsToTransfer = new ObservableCollection<IDetail>();
            DataContext = this;
        }

        private void SelectService(object sender, RoutedEventArgs e) => selectedService = (Services.Service)ServicesUI.SelectedItem;

        private void SelectDetail(object sender, RoutedEventArgs e)
        {
            IDetail detailToAdd = (IDetail)Storage.SelectedItem;
            int indx = Storage.SelectedIndex;
            int count = int.Parse(Count.Text);
            
            if (DetailsSer[indx].Count < count) 
            {
                MessageBox.Show("Недостатньо деталей");
                return; 
            }
            var currDetail = DetailsToTransfer.FirstOrDefault(i =>
            i.Name == detailToAdd.Name &&
            i.Model == detailToAdd.Model &&
            i.Price == detailToAdd.Price &&
            i.Value == detailToAdd.Value
            );
            if (currDetail == null)
            {
                detailToAdd.Count = count;
                DetailsToTransfer.Add(detailToAdd);
            }
            else 
            {
                currDetail.Count += count;
                ObservableCollection<IDetail> newDet = new ObservableCollection<IDetail>(DetailsToTransfer.Select(i => i).ToList());
                DetailsToTransfer.Clear();
                foreach (var i in newDet) DetailsToTransfer.Add(i);
            }
            DetailsSer[indx].Count -= count;
            ObservableCollection<IDetail> toShow = new ObservableCollection<IDetail>(DetailsSer.Select(i => ClassFactory.CreateDetail(i)).ToList());
            Details.Clear();
            foreach(var i in toShow) Details.Add(i);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Window1.TransferService(ClassFactory.CreateServiceExexuting(selectedService, DetailsToTransfer).ToDto());
            Window1.TransferDetailsToSerialize(DetailsSer);
            this.Close();
        }
    }
}
