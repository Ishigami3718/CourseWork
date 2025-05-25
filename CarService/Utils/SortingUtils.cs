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
        private static void SortRequests<T>(Func<T, IComparable> ByKey, ObservableCollection<T> toSort)
        {
            ObservableCollection<T> sorted = new ObservableCollection<T>(toSort.OrderBy(ByKey));
            toSort.Clear();
            foreach (var item in sorted) toSort.Add(item);
        }

        public static void ByName(ObservableCollection<RequestDTO> toSort) => SortRequests<RequestDTO>(i => i.ClientName, toSort);
        public static void ByDate(ObservableCollection<RequestDTO> toSort) => SortRequests<RequestDTO>(i => i.Date, toSort);
        public static void ById(ObservableCollection<RequestDTO> toSort) => SortRequests<RequestDTO>(i => i.Id, toSort);
    }
}
