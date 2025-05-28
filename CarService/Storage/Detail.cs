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
        public double Count {  get { return count; } set { count = value; } }

        public string Value => value;
        public string Name => name;
        public string Model => model;

        public DetailDTO ToDTO()
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

        public Detail(string name,string model, double price, double count,string value)
        {
            this.name = name;
            this.model = model;
            this.price = price;
            this.count = count;
            this.value = value;
        }

        public override string ToString()
        {
            return $"{name} {model} {count} {value} {price}грн";
        }
    }
}
