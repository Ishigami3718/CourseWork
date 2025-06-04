using CarService.Clients;
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
    /// Interaction logic for AddDetail.xaml
    /// </summary>
    public partial class AddDetail : Window
    {
        bool isRedact = false;
        int idToRedact;
        public AddDetail()
        {
            InitializeComponent();
        }

        public AddDetail(DetailDTO detail, int id)
        {
            InitializeComponent();
            Name.Text = detail.Name;
            Model.Text = detail.Model;
            Price.Text = detail.Price.ToString();
            Count.Text=detail.Count.ToString();
            switch (detail.Value)
            {
                case "Шт": Value.SelectedIndex=0;break;
                case "Л": Value.SelectedIndex = 1; break;
            }
            idToRedact = id;
            isRedact = true;
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            try
            {
                string value = "";
                ComboBoxItem selecteValue = Value.SelectedItem as ComboBoxItem;
                if (selecteValue == null) {MessageBox.Show("Не всі дані введені"); return; }
                switch (selecteValue.Content.ToString())
                {
                    case "Штуки": value = "Шт"; break;
                    case "Літри": value = "Л"; break;
                }
                IDetail detail = ClassFactory.CreateDetail(Name.Text, Model.Text, double.Parse(Price.Text),
                    double.Parse(Count.Text), value);
                DetailDTO detailDTO = detail.ToDTO();

                List<System.ComponentModel.DataAnnotations.ValidationResult> detailValidationResults =
                new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                bool isDetailValid = Validator.TryValidateObject(detailDTO, new ValidationContext(detailDTO),
                    detailValidationResults, true);

                if (isDetailValid)
                {
                    if (isRedact) Pages.Storage.Redact(detailDTO, idToRedact);
                    else Pages.Storage.TransferDetail(detailDTO);
                    this.Close();
                }
                else
                {
                    StringBuilder message = new StringBuilder();
                    foreach (var i in detailValidationResults) message.AppendLine(i.ToString());
                    MessageBox.Show(message.ToString());
                }
            }
            catch { MessageBox.Show("Не всі дані введені, або неправильний формат введених даних"); }
        }
    }
}
