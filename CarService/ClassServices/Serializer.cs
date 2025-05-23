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
        public static void Serialize<T>(List<T> requests,string path)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                using (TextWriter tw = new StreamWriter(path))
                {
                    ser.Serialize(tw, requests);
                }
            }
            catch
            {
                
            }
        }

        public static List<T> Deserialize<T>(string path)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<T>));
                using (TextReader tr = new StreamReader(path))
                {
                    return (List<T>)ser.Deserialize(tr);
                }
            }
            catch
            {
                return new List<T>();
            }
        }
    }
}
