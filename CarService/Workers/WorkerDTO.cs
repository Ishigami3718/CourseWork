using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Workers
{
    public class WorkerDTO
    {
        public string Name {  get; set; }
        public double Salary {  get; set; }

        public double? Quota {  get; set; }
    }
}
