using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataTable data = new DataTable();
            data.Columns.Add("Id", typeof(int));
            data.Columns.Add("Ім'я", typeof(string));
            data.Columns.Add("Машина", typeof(string));
            data.Columns.Add("Ціна", typeof(double));
            data.Columns.Add("Дата", typeof(DateTime));
            Data.Navigate(new Page1(data));
        }
    }
}
