using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Utils
{
    public class DetailPriceCalculator
    {
        const double vat = 0.2;

        public static double CalcPrice(IDetail detail)
        {
            return detail.Price*detail.Count;
        }

        public static double CalcPriceVAT(IDetail detail)
        {
            return CalcPrice(detail)*(1+vat);
        }
    }
}
