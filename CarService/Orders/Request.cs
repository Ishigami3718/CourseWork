using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Orders
{
    public class Request
    {
        IClient client;
        int id;
        DateOnly date;
        List<Service> services;
        double totalPrice;
    }
}
