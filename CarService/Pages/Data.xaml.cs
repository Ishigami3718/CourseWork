using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CarService.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public static void AddRow(RequestDTO req,DataTable dt)
        {
            dt.Rows.Add(req.Id,"Ros","BMW",req.Price,req.Date);
        }

        public static new void AddRow(RequestDTO req, ObservableCollection<RequestDTO> requests)
        {
            requests.Add(req);
        }
        public Page1(DataTable dt)
        {
            InitializeComponent();
            DataGrid.ItemsSource = dt.DefaultView;
        }

        public Page1(ObservableCollection<RequestDTO> requests)
        {
            InitializeComponent();
            DataGrid.ItemsSource = requests;
        }
    }
}
