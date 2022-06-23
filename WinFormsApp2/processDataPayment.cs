using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class processDataPayment : Form
    {
        public processDataPayment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var billId = numericUpDown2.Value;
            var sum = numericUpDown3.Value;

            var date = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");


            string sqlQuery = "select * from BILL where id = '" + billId + "'";

            DataTable existBill = DataBaseConnection.dataAdapterSelect(sqlQuery);

            if (existBill.Rows.Count == 0)
            {
                MessageBox.Show("Bill not exist");
            }
            else { 
            String Query = "insert into PAYMENT (IdBill, datePayment, sum) values (" +billId + ",'" + (string)date + "',"+sum+")";

            string dt = DataBaseConnection.sqlCommandQuery(Query);
            MessageBox.Show("Payment added");

            this.Close();

            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }
