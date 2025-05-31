using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        bool isRedact = false;
        int idToRedact;
        public AddRegularClient()
        {
            InitializeComponent();
        }

        public AddRegularClient(ClientDTO client,int id)
        {
            InitializeComponent();
            CarDTO car = client.Car;
            Mark.Text = car.Mark;
            Model.Text = car.Model;
            Plate.Text = car.LicensePlate;
            Run.Text = car.Run.ToString();
            RegDate.SelectedDate = car.RegisterDate;
            Name.Text = client.Name;
            Transmission.Text=client.Transmission.ToString();
            Discount.Text = (client.Discount*100).ToString();
            isRedact = true;
            idToRedact = id;
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            Car car = ClassFactory.CreateCar(Mark.Text, Model.Text, Plate.Text, int.Parse(Run.Text), (DateTime)RegDate.SelectedDate);
            Factory factory = new RegularClientFactory(int.Parse(Transmission.Text),double.Parse(Discount.Text));
            IClient client = factory.Create(Name.Text, car);
            if (isRedact) Pages.Clients.Redact(client.ToDTO(),idToRedact);
            else Pages.Clients.TransferClient(client.ToDTO());
            this.Close();
        }
    }
}
