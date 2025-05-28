using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarService.Workers
{
    public class WorkerDTO
    {
        public string Name {  get; set; }
        public double Salary {  get; set; }
        [XmlElement(IsNullable = true)]
        public double? Quota {  get; set; }
    }
}
