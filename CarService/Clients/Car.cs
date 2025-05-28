using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Clients
{
    public class Car
    {
        string mark, model, licensePlate;
        int run;
        DateTime registerDate;

        public Car(string mark,string model,string licensePlate,int run,DateTime reqisterDate)
        {
            this.mark = mark;
            this.model = model;
            this.licensePlate = licensePlate;
            this.run = run;
            this.registerDate = reqisterDate;
        }

        public int Run {  get { return run; } }
        public CarDTO ToDTO()
        {
            return new CarDTO()
            {
                Mark = mark,
                Model = model,
                LicensePlate = licensePlate,
                Run = run,
                RegisterDate=registerDate
            };
        }

        public Car(CarDTO dto)
        {
            mark = dto.Mark;
            model = dto.Model;
            licensePlate = dto.LicensePlate;
            run = dto.Run;
            registerDate = dto.RegisterDate;
        }
    }
}
