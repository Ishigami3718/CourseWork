﻿using System;
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

        public Car(string mark,string model,string licensePlate,int run,DateOnly reqisterDate)
        {
            this.mark = mark;
            this.model = model;
            this.licensePlate = licensePlate;
            this.run = run;
            this.registerDate = reqisterDate;
        }
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
