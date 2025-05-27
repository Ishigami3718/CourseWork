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
        public AddDetail()
        {
            InitializeComponent();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            string value="";
            switch (((ComboBoxItem)Value.SelectedItem).Content.ToString())
            {
                case "Штуки":value="Шт";break;
                case "Літри": value = "Л"; break;
            }
            Pages.Storage.TransferDetail(ClassFactory.CreateDetail(Name.Text, Model.Text, double.Parse(Price.Text), double.Parse(Count.Text), value).ToDTO());
            this.Close();
        }
    }
}
