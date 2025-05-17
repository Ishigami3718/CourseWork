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
    public partial class Data : Page
    {
        //Requests table
        public List<RequestDTO> Requests { get; set; }
        
        public Data(List<RequestDTO> requestsDTO)
        {
            InitializeComponent();
            //Requests = requestsDTO.Select(i=>new Request(i)).ToList();
            Requests= requestsDTO;
            DataContext = this;
        }
    }
}
