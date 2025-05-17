using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Workers
{
    public class Worker:IWorker
    {
        string name;
        double salary;
        double quota;

        public double Quota { get { return quota; } set { quota = value; } }
        public Worker(WorkerDTO dto)
        {
            name = dto.Name;
            salary = dto.Salary;
        }
        public WorkerDTO ToDto()
        {
            return new WorkerDTO {Name=name,Salary=salary};
        }
    }
}
