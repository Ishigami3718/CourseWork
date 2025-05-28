using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<ServiceExecutingDTO> Services { get; set; }
        public ObservableCollection<WorkerDTO> Workers { get; set; }
        public DataAddition(RequestDTO requestsDTO)
        {
            InitializeComponent();
            Services = requestsDTO.Services;
            Workers = requestsDTO.Workers;
            DataContext = this;
        }

        public DataAddition()
        {
            Services = new ObservableCollection<ServiceExecutingDTO>();
            Workers = new ObservableCollection<WorkerDTO>();
            InitializeComponent();
            DataContext = this;
        }

        public void UpdateData(RequestDTO dto)
        {
            if (dto != null)
            {
                Services.Clear();
                foreach (var s in dto.Services)
                    Services.Add(s);

                Workers.Clear();
                foreach (var w in dto.Workers)
                    Workers.Add(w);
                DataContext = this;
            }
            else
            {
                Services.Clear();
                Workers.Clear();
            }
        }
    }
}
