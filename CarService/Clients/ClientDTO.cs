using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Clients
{
    public class ClientDTO
    {
        public int Id { get; set; }
        [RegularExpressionAttribute(@"^[А-ЯЇЄІ]{1}[а-яА-ЯїЇєЄіІ]{3,20}\s[А-ЯЇЄІ]{1}[а-яА-ЯїЇєЄіІ]{3,20}$",
            ErrorMessage ="Формат імені \"Прізвище Ім'я\"")]
        public string Name { get; set; }

        public CarDTO Car { get; set; }
        [Range(3,24,ErrorMessage ="Періодичність від 3 до 24 місяців")]
        public int? Transmission {  get; set; }
        [Range(0, 15, ErrorMessage = "Скидка від 0 до 15 %")]
        public double? Discount { get; set; }

    }
}
