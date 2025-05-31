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
            string value="";
            switch (((ComboBoxItem)Value.SelectedItem).Content.ToString())
            {
                case "Штуки":value="Шт";break;
                case "Літри": value = "Л"; break;
            }
            if (isRedact) Pages.Storage.Redact(ClassFactory.CreateDetail(Name.Text, Model.Text, double.Parse(Price.Text),
                double.Parse(Count.Text), value).ToDTO(), idToRedact);
            else Pages.Storage.TransferDetail(ClassFactory.CreateDetail(Name.Text, Model.Text, double.Parse(Price.Text), double.Parse(Count.Text), value).ToDTO());
            this.Close();
        }
    }
}
