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
        public AddWorkerForStorage()
        {
            InitializeComponent();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            Pages.Workers.TransferWorker(ClassFactory.CreateWorker(Name.Text, double.Parse(Salarity.Text)).ToDto());
            this.Close();
        }
    }
}
