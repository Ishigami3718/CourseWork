using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Storage
{
    public class Detail:IDetail
    {
        string name, model;
        double price,count;
        string value;

        public double Price => price;
        public double Count => count;

        public DetailDTO ToDto()
        {
            return new DetailDTO { Count = count, Model = model, Price = price, Name = name, Value = value };
        }
        public Detail(DetailDTO dto)
        {
            name = dto.Name;
            model = dto.Model;
            price = dto.Price;
            count = dto.Count;
            value = dto.Value;
        }
    }
}
