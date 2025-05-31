using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for AddWorkerForStorage.xaml
    /// </summary>
    public partial class AddWorkerForStorage : Window
    {
        bool isRedact = false;
        int idToRedact;
        public AddWorkerForStorage()
        {
            InitializeComponent();
        }

        public AddWorkerForStorage(WorkerDTO worker,int id)
        {
            InitializeComponent();
            Name.Text = worker.Name;
            Salarity.Text = worker.Salary.ToString();
            isRedact = true;
            idToRedact = id;
        }
        private void OK(object sender, RoutedEventArgs e)
        {
            if (isRedact) Pages.Workers.Redact(ClassFactory.CreateWorker(Name.Text, double.Parse(Salarity.Text)).ToDto(), idToRedact);
            else Pages.Workers.TransferWorker(ClassFactory.CreateWorker(Name.Text, double.Parse(Salarity.Text)).ToDto());
            this.Close();
        }
    }
}
