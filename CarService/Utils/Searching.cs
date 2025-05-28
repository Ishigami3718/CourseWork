using CarService.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Utils
{
    public class Searching
    {
        private static void Search<T>(string search,ObservableCollection<T> dataToDisplay, ObservableCollection<T> data, Func<T, string> serachBy)
        {
            if (search != "Введіть для пошуку")
            {
                if (search != string.Empty && search!=null)
                {
                    List<T> r = data.Where(i => serachBy(i).Contains(search)).ToList();
                    dataToDisplay.Clear();
                    foreach (var i in r) dataToDisplay.Add(i);
                }
                else
                {
                    dataToDisplay.Clear();
                    foreach (var i in data) dataToDisplay.Add(i);
                }
            }
        }

        public static void SearchByName(string search, ObservableCollection<RequestDTO> dataToDaisplay,
            ObservableCollection<RequestDTO> data) => Search<RequestDTO>(search, dataToDaisplay, data, i => i.ClientName);

        public static void SearchByName(string search, ObservableCollection<DetailDTO> dataToDaisplay,
            ObservableCollection<DetailDTO> data) => Search<DetailDTO>(search, dataToDaisplay, data, i => i.Name);

        public static void SearchByName(string search, ObservableCollection<ServiceDTO> dataToDaisplay,
            ObservableCollection<ServiceDTO> data) => Search<ServiceDTO>(search, dataToDaisplay, data, i => i.Name);

        public static void SearchByName(string search, ObservableCollection<WorkerDTO> dataToDaisplay,
            ObservableCollection<WorkerDTO> data) => Search<WorkerDTO>(search, dataToDaisplay, data, i => i.Name);
    }
}
