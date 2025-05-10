using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Pages
{
    public class Table
    {

        public static DataTable Requsts()
        {
            DataTable data = new DataTable();
            data.Columns.Add("Id", typeof(int)).ReadOnly = true;
            data.Columns.Add("Ім'я", typeof(IClient)).ReadOnly = true;
            data.Columns.Add("Машина", typeof(Car)).ReadOnly = true;
            data.Columns.Add("Ціна", typeof(double)).ReadOnly = true;
            data.Columns.Add("Дата", typeof(DateTime)).ReadOnly = true;
            return data;
        }

        public static void AddRow(RequestDTO req, DataTable dt)
        {
            //TODO Add constructors to client classes!
            dt.Rows.Add(req.Id, req.Client, req.Client.Car, req.Price, req.Date);
        }
    }
}
