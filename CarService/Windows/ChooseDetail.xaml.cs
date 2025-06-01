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
    /// Interaction logic for ChooseDetail.xaml
    /// </summary>
    public partial class ChooseDetail : Window
    {
        private ObservableCollection<DetailDTO> DetailsSer;
        public ObservableCollection<IDetail> Details { get; set; }


        public static ObservableCollection<IDetail> DetailsToTransfer { get; set; }
        public ChooseDetail(ObservableCollection<DetailDTO> setedDetails)
        {
            InitializeComponent();
            if (NextRequest.detailsSerialize != null) DetailsSer = NextRequest.detailsSerialize;
            else DetailsSer = Serializer.Deserialize<DetailDTO>(@"Storage\Storage.xml");
            Details = new ObservableCollection<IDetail>(DetailsSer.Select(i => ClassFactory.CreateDetail(i)).ToList());
            if (setedDetails != null || setedDetails.Count != 0)
            {
                DetailsToTransfer = new ObservableCollection<IDetail>(setedDetails.Select(i=>ClassFactory.CreateDetail(i)));
            }
            else DetailsToTransfer = new ObservableCollection<IDetail>();
            DataContext = this;
        }

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
            foreach (var i in toShow) Details.Add(i);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            NextRequest.TransferDetailsToSerialize(DetailsSer);
            NextRequest.TransferDetails(new ObservableCollection<DetailDTO>(DetailsToTransfer.Select(i=>i.ToDTO()).ToList()));
            this.Close();
        }
    }
}
