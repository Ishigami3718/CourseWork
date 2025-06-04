using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarService.Workers
{
    public class WorkerDTO
    {
        [RegularExpressionAttribute(@"^[А-ЯЇЄІ]{1}[а-яА-ЯїЇєЄіІ]{3,20}\s[А-ЯЇЄІ]{1}[а-яА-ЯїЇєЄіІ]{3,20}$",
            ErrorMessage = "Формат імені \"Прізвище Ім'я\"")]
        public string Name {  get; set; }
        [Range(5000,100000,ErrorMessage ="Недпустиме значення зарплати")]
        public double Salary {  get; set; }
        [XmlElement(IsNullable = true)]
        [Range(10, 100, ErrorMessage = "Недпустиме значення долі працівника")]
        public double? Quota {  get; set; }
    }
}
