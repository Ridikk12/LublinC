using Studia.DbConnection;
using Studia.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblResult.Visible = false;
            dGvAll.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var customers = Customer.GetAllCustomers();
            Customer moj = new Customer() { Wiek = 2, DataUrodzenia = DateTime.Now, Imie = "test", Nazwisko = "Test222" };
            Customer.InsertCustomer(moj);

        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            var customers = Customer.GetAllCustomers();
            dGvAll.DataSource = customers;
      
        }

        private void tbWiek_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only numbers
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer();
            newCustomer.Imie = tbImie.Text;
            newCustomer.Nazwisko = tbNaziwsko.Text;
            newCustomer.DataUrodzenia = dtUrodzenia.Value;
            newCustomer.Wiek = Convert.ToInt32(tbWiek.Text);
            Customer.InsertCustomer(newCustomer);
            lblResult.Visible = true;

        }
    }
}
