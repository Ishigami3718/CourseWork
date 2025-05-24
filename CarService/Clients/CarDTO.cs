using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Clients
{
    public class CarDTO
    {
        public string Mark {  get; set; }
        public string Model { get; set; }
        public string LicensePlate {  get; set; }
        public int Run {  get; set; }

        public DateOnly RegisterDate { get; set; }
    }
}
