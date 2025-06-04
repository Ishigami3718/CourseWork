using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage ="Дата обов'язкова")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Як мінімум один сервіс обо'язковий")]
        public ObservableCollection<ServiceExecutingDTO> Services { get; set; }
        [DisplayName("Ціна")]
        public double Price {  get; set; }

        [Required(ErrorMessage = "Як мінімум один працвник обов'язковий")]
        public ObservableCollection<WorkerDTO> Workers { get; set; }
    }
}
