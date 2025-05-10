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
        int price;
        public Service(string name, int price) { this.name = name; this.price = price; }

        public string Name {  get { return name; } }
        public int Price 
        { 
            get {  return price; } 
            set 
            { 
                if(price>0) price = value;
            } 
        }

    }
}
