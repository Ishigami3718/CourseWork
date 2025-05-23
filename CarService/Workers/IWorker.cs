using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Workers
{
    public interface IWorker
    {
        public double Quota { get; set; }

        public WorkerDTO ToDto();
    }
}
