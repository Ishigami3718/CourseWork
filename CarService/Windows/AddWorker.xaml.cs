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
        public event Action<WorkerDTO> WorkerAdded;
        public List<IWorker> Workers {  get; set; }
        IWorker worker;
        public AddWorker()
        {
            InitializeComponent();
            Workers = Serializer.Deserialize<WorkerDTO>(@"Workers\Workers.xml").Select(i=>ClassFactory.CreateWorker(i)).ToList();
            DataContext = this;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                worker = (IWorker)SelectWorker.SelectedItem;
                if (worker == null) { MessageBox.Show("Оберіть працівника"); return; }
                double quotaPercent = double.Parse(Quota.Text);
                if (quotaPercent <10) { MessageBox.Show("Надто мала доля"); return; }
                worker.Quota = Math.Round(quotaPercent / 100, 3);
                WorkerAdded?.Invoke(worker.ToDto());
                this.Close();
            }
            catch { MessageBox.Show("Введіть долю праціника"); }
        }
    }
}
