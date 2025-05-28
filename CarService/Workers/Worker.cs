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
        double? quota;

        public double? Quota { get { return quota; } set { quota = value; } }
        public Worker(WorkerDTO dto)
        {
            name = dto.Name;
            salary = dto.Salary;
            quota = dto.Quota;
        }

        public Worker(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }


        public WorkerDTO ToDto()
        {
            return new WorkerDTO {Name=name,Salary=salary,Quota=quota};
        }

        public override string ToString()
        {
            return $"{name} ставка:{quota}";
        }
    }
}
