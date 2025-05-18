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
        DateOnly registerDate;

        public CarDTO ToDTO()
        {
            return new CarDTO()
            {
                Mark = mark,
                Model = model,
                LicensePlate = licensePlate,
                Run = run
            };
        }

        public Car(CarDTO dto)
        {
            mark = dto.Mark;
            model = dto.Model;
            licensePlate = dto.LicensePlate;
            run = dto.Run;
        }
    }
}
