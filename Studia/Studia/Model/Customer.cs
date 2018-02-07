using Studia.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studia.Model
{
    public class Customer
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public int Wiek { get; set; }

        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            var dt = DbProvider.GetDataSelectQuery("Select * From Customer");
            foreach (DataRow row in dt.Rows)
            {
                string imie = row["Imie"].ToString();
                string nazwisko = row["Nazwisko"].ToString();
                int wiek = Convert.ToInt32(row["Wiek"]);
                DateTime dataUrodzenia = Convert.ToDateTime(row["DataUrodzenia"]);
                customerList.Add(new Customer
                {
                    Imie = imie,
                    Nazwisko = nazwisko,
                    DataUrodzenia = dataUrodzenia,
                    Wiek = wiek
                });
            }

            return customerList;

        }

        public static DataTable GetAllCustomersDataTable()
        {       
            return DbProvider.GetDataSelectQuery("Select * From Customer");
        }

        public static bool InsertCustomer(Customer customer)
        {
            string sqlCommand = @"Insert Into Customer (Imie,Nazwisko,Wiek,DataUrodzenia) 
                Values('"
                    + customer.Imie
                    + "','"
                    + customer.Nazwisko + "','"
                    + customer.Wiek + "','"
                    + customer.DataUrodzenia + "')";
            return DbProvider.InsertQuery(sqlCommand);
        }

    }
}
