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
    public partial class processDataBill : Form
    {
        public processDataBill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rentId = numericUpDown2.Value;
            var sum = (int)numericUpDown3.Value;
            var fine = numericUpDown1.Value;
            var startDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            var endDate = monthCalendar2.SelectionRange.Start.ToString("yyyy-MM-dd");
            var dedlineWithoutAdditionalPayment = monthCalendar3.SelectionRange.Start.ToString("yyyy-MM-dd");


            string sqlQuery = "select * from RENT where id = '" + rentId + "'";

            DataTable existRent = DataBaseConnection.dataAdapterSelect(sqlQuery);

            if (existRent.Rows.Count == 0)
            {
                MessageBox.Show("Rent not exist");
            }
            else { 

            String Query = "insert into BILL (idRent, dedlineWithoutAdditionalPayment, fine,startDate,endDate, sum) " +
                                              "values ('" + rentId + "','" + dedlineWithoutAdditionalPayment + "','" + fine + "','" + startDate + "','" + endDate + "','" + sum + "')";

            string dt = DataBaseConnection.sqlCommandQuery(Query);

            MessageBox.Show("Payment added");

            this.Close();
            }
        }

        private void processDataBill_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar3_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
