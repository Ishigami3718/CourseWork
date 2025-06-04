using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services
{
    public class ServiceDTO
    {
        public string Name {  get; set; }
        [Range(100, 10000, ErrorMessage = "Недопустиме значення ціни сервісу")]
        public double Price {  get; set; }

        public double PriceVAT {  get; set; }
    }
}
