using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
                if(value>0) price = value;
            } 
        }

        public ServiceDTO ToDto()
        {
            return new ServiceDTO { Name = Name, Price = Price,PriceVAT=price*1.2 };
        }
        public Service(ServiceDTO dto)
        {
            name = dto.Name;
            price = dto.Price;
        }

        public override string ToString()
        {
            return $"{name} {price}грн";
        }

        public override bool Equals(object? obj)
        {
            Service toComp = obj as Service;
            return name.Equals(toComp.name) && price.Equals(toComp.price);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, price);
        }
    }
}
