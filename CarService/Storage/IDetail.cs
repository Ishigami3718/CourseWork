using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Storage
{
    public interface IDetail
    {
        public double Price { get; }
        public double Count {  get; }
    }
}
