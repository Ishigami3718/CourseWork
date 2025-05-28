using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Storage
{
    public class DetailDTO
    {
        public string Name {  get; set; }
        public string Model {  get; set; }
        public double Count {  get; set; }
        public double Price {  get; set; }

        public double PriceVAT {  get; set; }
        public string Value {  get; set; }

    }
}
