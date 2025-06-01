using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Clients
{
    public class CarDTO
    {
        [RegularExpressionAttribute(@"^[a-zA-z]{3,20}$",ErrorMessage ="Марка англійськими буквами")]
        public string Mark {  get; set; }
        public string Model { get; set; }
        [RegularExpressionAttribute(@"^[A-Z]{2}\d{4}[A-Z]{2}$", ErrorMessage = "Номерний знак у форматі \"Дві великі англійські літери" +
            " чотири цифри дві великі англійські букви\"")]
        public string LicensePlate {  get; set; }
        [Range(0,400000,ErrorMessage ="Недопустиме значення пробігу")]
        public int Run {  get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
