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

namespace CarService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable mainData;
        List<RequestDTO> requestDTOs = new List<RequestDTO>();
        public MainWindow()
        {
            InitializeComponent();
            mainData =Pages.Table.Requsts();
            requestDTOs.Add(new RequestDTO { Client = new ClientDTO(), Date = new DateOnly(2025, 4, 12), Id =  1, Price = 1500 });
            Data.Navigate(new Data(requestDTOs));
             /*for(int i = 0; i < 10; i++)
             {
                 Pages.Table.AddRow(new RequestDTO { Client=new ClientDTO(),Date=new DateTime(2025,4,12),Id=i+1,Price=1500},mainData);
             }
             AddData.Navigate(new DataAddition());*/
        }
    }
}
