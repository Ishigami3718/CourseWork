using CarService.Orders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarService.ClassServices
{
    public class Serializer
    {
        public static void Serialize(List<RequestDTO> requests)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<RequestDTO>));
                using (TextWriter tw = new StreamWriter(@"Orders\Orders.xml"))
                {
                    ser.Serialize(tw, requests);
                }
            }
            catch
            {
                
            }
        }

        public static List<RequestDTO> Deserialize()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<RequestDTO>));
                using (TextReader tr = new StreamReader(@"Orders\Orders.xml"))
                {
                    return (List<RequestDTO>)ser.Deserialize(tr);
                }
            }
            catch
            {
                return null;
            }
        }

        //TODO another objects
    }
}
