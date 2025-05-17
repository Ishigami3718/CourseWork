using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Storage
{
    public class Detail
    {
        string name, model;
        int price,count;
        string value;

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
