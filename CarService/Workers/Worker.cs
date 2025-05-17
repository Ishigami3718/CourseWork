using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Workers
{
    public class Worker
    {
        string name;
        double salary;
        double quota;

        public double Quota { get { return quota; } set { quota = value; } }
        public Worker(WorkerDTO dto)
        {
            //TODO Fill constructor
        }
        public WorkerDTO ToDto()
        {
            //TODO Fill meth
            return new WorkerDTO { };
        }
    }
}
