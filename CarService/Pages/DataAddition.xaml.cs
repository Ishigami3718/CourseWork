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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarService.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class DataAddition : Page
    {
       // public List<ServiceExecutingDTO> Requests { get; set; }
        public List<ServiceExecutingDTO> Services { get; set; }
        public List<WorkerDTO> Workers { get; set; }
        public DataAddition(RequestDTO requestsDTO)
        {
            InitializeComponent();
            Services = requestsDTO.Services;
            Workers = requestsDTO.Workers;
            DataContext = this;
        }
    }
}
