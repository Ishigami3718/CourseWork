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
    /// Interaction logic for AddServiceForStorage.xaml
    /// </summary>
    public partial class AddServiceForStorage : Window
    {
        bool isRedact = false;
        int idToRedact;
        public AddServiceForStorage()
        {
            InitializeComponent();
        }

        public AddServiceForStorage(ServiceDTO service,int id)
        {
            InitializeComponent();
            Name.Text = service.Name;
            Price.Text = service.Price.ToString();
            isRedact = true;
            idToRedact = id;
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            if (isRedact) Pages.Service.Redact(ClassFactory.CreateService(Name.Text, double.Parse(Price.Text)).ToDto(), idToRedact);
            else Pages.Service.TransferService(ClassFactory.CreateService(Name.Text,double.Parse(Price.Text)).ToDto());
            this.Close();
        }
    }
}
