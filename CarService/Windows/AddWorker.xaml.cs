using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        public List<IWorker> Workers {  get; set; }
        IWorker worker;
        public AddWorker()
        {
            InitializeComponent();
            Workers = Serializer.Deserialize<WorkerDTO>(@"Workers\Workers.xml").Select(i=>ClassCreator.CreateWorker(i)).ToList();
            DataContext = this;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            worker = (IWorker)SelectWorker.SelectedItem;
            worker.Quota = Math.Round(double.Parse(Quota.Text) / 100,3);
            Window1.TransferWorker(worker.ToDto());
            this.Close();
        }
    }
}
