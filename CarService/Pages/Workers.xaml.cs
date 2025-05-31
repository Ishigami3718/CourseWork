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
    /// Interaction logic for Workers.xaml
    /// </summary>
    public partial class Workers : Page
    {
        public static ObservableCollection<WorkerDTO> WorkersSer {  get; set; }
        public static ObservableCollection<WorkerDTO> WorkersDis { get; set; }
        public Workers()
        {
            InitializeComponent();
            WorkersSer = Serializer.Deserialize<WorkerDTO>(@"Workers\Workers.xml");
            WorkersDis = new ObservableCollection<WorkerDTO>(WorkersSer);
            DataContext = this;
        }

        public static void TransferWorker(WorkerDTO worker)
        {
            WorkersSer.Add(worker);
            WorkersDis.Add(worker);
        }

        private void AddWorker(object sender, RoutedEventArgs e)
        {
            new AddWorkerForStorage().ShowDialog();
            Serializer.Serialize<WorkerDTO>(WorkersSer, @"Workers\Workers.xml");
        }

        private void StartSearching(object sender, KeyboardFocusChangedEventArgs e)
        {
            Search.Text = string.Empty;
        }

        private void Searching(object sender, TextChangedEventArgs e)
        {
            string ser = Search.Text;
            Utils.Searching.SearchByName(ser, WorkersDis, WorkersSer);
        }

        private void LeaveSearching(object sender, KeyboardFocusChangedEventArgs e)
        {
            string ser = Search.Text;
            if (string.IsNullOrEmpty(ser)) Search.Text = "Введіть для пошуку";
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            WorkerDTO toDelete = WorkersTable.SelectedItem as WorkerDTO;
            WorkersSer.Remove(toDelete);
            WorkersDis.Remove(toDelete);
            Serializer.Serialize(WorkersSer, @"Workers\Workers.xml");
        }

        private void ByName(object sender, RoutedEventArgs e) => Utils.SortingUtils.ByName(WorkersDis);

        private void ByPrice(object sender, RoutedEventArgs e) => Utils.SortingUtils.BySalarity(WorkersDis);
        private void Sorting(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            but.ContextMenu.IsOpen = true;
        }

        public static void Redact(WorkerDTO worker, int id)
        {
            WorkersSer[id] = worker;
            WorkersDis.Clear();
            foreach (var i in WorkersSer) WorkersDis.Add(i);
        }
        private void Redact(object sender, RoutedEventArgs e)
        {
            WorkerDTO workerToRedact = WorkersTable.SelectedItem as WorkerDTO;
            new AddWorkerForStorage(workerToRedact, WorkersSer.IndexOf(workerToRedact)).ShowDialog();
            Serializer.Serialize(WorkersSer, @"Workers\Workers.xml");
        }
    }
}
