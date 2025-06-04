using CarService.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            try
            {
                Services.Service service = ClassFactory.CreateService(Name.Text, double.Parse(Price.Text));
                ServiceDTO serviceDTO = service.ToDto();

                List<System.ComponentModel.DataAnnotations.ValidationResult> serviceValidationResults =
                new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                bool isServiceValid = Validator.TryValidateObject(serviceDTO, new ValidationContext(serviceDTO),
                    serviceValidationResults, true);

                if (isServiceValid)
                {
                    if (isRedact) Pages.Service.Redact(serviceDTO, idToRedact);
                    else Pages.Service.TransferService(serviceDTO);
                    this.Close();
                }
                else
                {
                    StringBuilder message = new StringBuilder();
                    foreach (var i in serviceValidationResults) message.AppendLine(i.ToString());
                    MessageBox.Show(message.ToString());
                }
            }
            catch { MessageBox.Show("Не всі дані введені"); }
        }
    }
}
