using CarService.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
    /// Interaction logic for AddWorkerForStorage.xaml
    /// </summary>
    public partial class AddWorkerForStorage : Window
    {
        bool isRedact = false;
        int idToRedact;
        public AddWorkerForStorage()
        {
            InitializeComponent();
        }

        public AddWorkerForStorage(WorkerDTO worker,int id)
        {
            InitializeComponent();
            Name.Text = worker.Name;
            Salarity.Text = worker.Salary.ToString();
            isRedact = true;
            idToRedact = id;
        }
        private void OK(object sender, RoutedEventArgs e)
        {
            try
            {
                IWorker worker = ClassFactory.CreateWorker(Name.Text, double.Parse(Salarity.Text));
                WorkerDTO workerDTO = worker.ToDto();

                List<System.ComponentModel.DataAnnotations.ValidationResult> workerValidationResults =
                new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                bool isWorkerValid = Validator.TryValidateObject(workerDTO, new ValidationContext(workerDTO),
                    workerValidationResults, true);

                if (isWorkerValid)
                {
                    if (isRedact) Pages.Workers.Redact(workerDTO, idToRedact);
                    else Pages.Workers.TransferWorker(workerDTO);
                    this.Close();
                }
                else
                {
                    StringBuilder message = new StringBuilder();
                    foreach (var i in workerValidationResults) message.AppendLine(i.ToString());
                    MessageBox.Show(message.ToString());
                }
            }
            catch { MessageBox.Show("Не всі дані введені"); }
        }
    }
}
