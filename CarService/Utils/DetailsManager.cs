using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Utils
{
    public class DetailsManager
    {
        public static void ManageDetail(IDetail detail,ObservableCollection<IDetail> details,double count)
        {
            int indx = details.IndexOf(detail);
            if (indx != -1)
            {
                details[indx].Count += count;
            }
        }

        public static IDetail ChooseDetail(IDetail detail)
        {
            return new Detail(detail.Name, detail.Model, detail.Price, 0, detail.Value);
        }

    }
}
