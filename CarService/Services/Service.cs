using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Services
{
    public class Service
    {
        string name;
        double price;
        
        public Service(string name, double price) { this.name = name; this.price = price; }

        public string Name {  get { return name; } }
        public double Price 
        { 
            get {  return price; } 
            set 
            { 
                if(price>0) price = value;
            } 
        }

        public ServiceDTO ToDto()
        {
            return new ServiceDTO { Name = Name, Price = Price };
        }
        public Service(ServiceDTO dto)
        {
            name = dto.Name;
            price = dto.Price;
        }

    }
}
