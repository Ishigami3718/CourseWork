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
        public ClientDTO Client { get; set; }
        public string ClientName=>Client.Name;
        [DisplayName("Дата")]
        public DateOnly Date { get; set; }

        public List<ServiceExecutingDTO> Services { get; set; }
        [DisplayName("Ціна")]
        public double Price {  get; set; }

        public List<WorkerDTO> Workers { get; set; }
    }
}
