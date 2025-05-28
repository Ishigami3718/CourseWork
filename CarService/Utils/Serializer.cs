using CarService.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace CarService.Utils
{
    public class Serializer
    {
        public static void Serialize<T>(ObservableCollection<T> requests,string path)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<T>));
                using (TextWriter tw = new StreamWriter(path))
                {
                    ser.Serialize(tw, requests);
                }
            }
            catch
            {
                
            }
        }

        public static ObservableCollection<T> Deserialize<T>(string path)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<T>));
                using (TextReader tr = new StreamReader(path))
                {
                    return (ObservableCollection<T>)ser.Deserialize(tr);
                }
            }
            catch
            {
                return new ObservableCollection<T>();
            }
        }
    }
}
