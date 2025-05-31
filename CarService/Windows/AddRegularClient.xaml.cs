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
    /// Interaction logic for AddRegularClient.xaml
    /// </summary>
    public partial class AddRegularClient : Window
    {
        public AddRegularClient()
        {
            InitializeComponent();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            Car car = ClassFactory.CreateCar(Mark.Text, Model.Text, Plate.Text, int.Parse(Run.Text), (DateTime)RegDate.SelectedDate);
            Factory factory = new RegularClientFactory(int.Parse(Transmission.Text),double.Parse(Discount.Text));
            IClient client = factory.Create(Name.Text, car);
            Pages.Clients.TransferClient(client.ToDTO());
            this.Close();
        }
    }
}
