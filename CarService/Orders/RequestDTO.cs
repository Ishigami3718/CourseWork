using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarService.Orders
{
    public class RequestDTO
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Клієнт")]
        public ClientDTO Client { get; set; }
        [XmlIgnore]
        public string ClientName=>Client.Name;
        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        public ObservableCollection<ServiceExecutingDTO> Services { get; set; }
        [DisplayName("Ціна")]
        public double Price {  get; set; }

        public ObservableCollection<WorkerDTO> Workers { get; set; }
    }
}
