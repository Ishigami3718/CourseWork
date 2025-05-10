using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Orders
{
    public class RequestDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Клієнт")]
        public IClient Client { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Ціна")]
        public double Price {  get; set; }
    }
}
