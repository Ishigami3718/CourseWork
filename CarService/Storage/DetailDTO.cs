using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Storage
{
    public class DetailDTO
    {
        public string Name {  get; set; }
        public string Model {  get; set; }
        [Range(0,10000,ErrorMessage ="Недопустиме значення кількості деталі (від 0 до 10000)")]
        public double Count {  get; set; }
        [Range(0, 100000, ErrorMessage = "Недопустиме значення ціни деталі")]
        public double Price {  get; set; }

        public double PriceVAT {  get; set; }
        public string Value {  get; set; }

    }
}
