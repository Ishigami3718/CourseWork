using CarService.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Utils
{
    public class SortingUtils
    {
        private static void Sort<T>(Func<T, IComparable> ByKey, ObservableCollection<T> toSort)
        {
            ObservableCollection<T> sorted = new ObservableCollection<T>(toSort.OrderBy(ByKey));
            toSort.Clear();
            foreach (var item in sorted) toSort.Add(item);
        }

        public static void ByName(ObservableCollection<RequestDTO> toSort) => Sort<RequestDTO>(i => i.ClientName, toSort);
        public static void ByDate(ObservableCollection<RequestDTO> toSort) => Sort<RequestDTO>(i => i.Date, toSort);
        public static void ById(ObservableCollection<RequestDTO> toSort) => Sort<RequestDTO>(i => i.Id, toSort);

        public static void ByName(ObservableCollection<DetailDTO> toSort) => Sort<DetailDTO>(i => i.Name, toSort);
        public static void ByCount(ObservableCollection<DetailDTO> toSort) => Sort<DetailDTO>(i => i.Count, toSort);
        public static void ByPrice(ObservableCollection<DetailDTO> toSort) => Sort<DetailDTO>(i => i.Price, toSort);

        public static void ByName(ObservableCollection<ServiceDTO> toSort) => Sort<ServiceDTO>(i => i.Name, toSort);
        public static void ByPrice(ObservableCollection<ServiceDTO> toSort) => Sort<ServiceDTO>(i => i.Price, toSort);
    }
}
