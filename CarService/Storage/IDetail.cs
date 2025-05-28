using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Storage
{
    public interface IDetail
    {
        public string Name { get; }
        public string Model {  get; }
        public double Price { get; }
        public double Count { get; set; }

        public string Value {  get; }

        public DetailDTO ToDTO();
    }
}
