using CarService.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarService.ClassServices
{
    public class Searching
    {
        private static void Search<T>(string search,ObservableCollection<T> dataToDaisplay, ObservableCollection<T> data, Func<T, string> serachBy)
        {
            if (search != "Введіть для пошуку")
            {
                if (search != string.Empty)
                {
                    List<T> r = dataToDaisplay.Where(i => serachBy(i).Contains(search)).ToList();
                    dataToDaisplay.Clear();
                    foreach (var i in r) dataToDaisplay.Add(i);
                }
                else
                {
                    dataToDaisplay.Clear();
                    foreach (var i in data) dataToDaisplay.Add(i);
                }
            }
        }

        public static void SearchByName(string search, ObservableCollection<RequestDTO> dataToDaisplay,
            ObservableCollection<RequestDTO> data) => Search<RequestDTO>(search, dataToDaisplay, data, i => i.ClientName);
    }
}
