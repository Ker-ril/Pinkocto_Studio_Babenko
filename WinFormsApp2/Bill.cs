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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processDataBill f = new processDataBill();
            f.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            this.refresh();
        }
        public void refresh()
        {
            string sqlQuery = "select * from BILL";

            DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["Id"], dr["idRent"], dr["dedlineWithoutAdditionalPayment"], dr["fine"], dr["startDate"], dr["endDate"], dr["sum"]); ;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow data in dataGridView1.Rows)
            {
                try
                {
                    var check = data.Cells[0].Value;
                    if (check != null)
                    {
                        int id = (int)data.Cells[0].Value;
                        var idRent = data.Cells[1].Value;
                        var dedlineWithoutAdditionalPayment = data.Cells[2].Value;
                        var fine = data.Cells[3].Value;
                        var startDate = data.Cells[4].Value;
                        var endDate = data.Cells[5].Value;
                        var sum = data.Cells[6].Value;


                        if (dedlineWithoutAdditionalPayment.GetType() == typeof(string))
                        {
                            DateTime d = DateTime.Parse((string)dedlineWithoutAdditionalPayment);
                            dedlineWithoutAdditionalPayment = d.ToString("yyyy-MM-dd");
                        }
                        else if (dedlineWithoutAdditionalPayment.GetType() == typeof(DateTime))
                        {
                            var temp = ((DateTime)dedlineWithoutAdditionalPayment).ToString();
                            DateTime d = DateTime.Parse((string)temp);
                            dedlineWithoutAdditionalPayment = d.ToString("yyyy-MM-dd");
                        }


                        if (startDate.GetType() == typeof(string))
                        {
                            DateTime d = DateTime.Parse((string)startDate);
                            startDate = d.ToString("yyyy-MM-dd");
                        }
                        else if (startDate.GetType() == typeof(DateTime))
                        {
                            var temp = ((DateTime)startDate).ToString();
                            DateTime d = DateTime.Parse((string)temp);
                            startDate = d.ToString("yyyy-MM-dd");
                        }

                        if (endDate.GetType() == typeof(string))
                        {
                            DateTime d = DateTime.Parse((string)endDate);
                            endDate = d.ToString("yyyy-MM-dd");
                        }
                        else if (endDate.GetType() == typeof(DateTime))
                        {
                            var temp = ((DateTime)endDate).ToString();
                            DateTime d = DateTime.Parse((string)temp);
                            endDate = d.ToString("yyyy-MM-dd");
                        }



                        //check rent
                        string existRent = "select * from RENT where id = '" + idRent + "'";

                        DataTable rent = DataBaseConnection.dataAdapterSelect(existRent);

                        if (rent.Rows.Count == 0)
                        {
                            MessageBox.Show("Rent not exist");
                        }

                        string sqlQuery = "update BILL SET idRent = " + idRent + ", dedlineWithoutAdditionalPayment = '" + dedlineWithoutAdditionalPayment + "'," +
                            " sum = " + sum + ", fine = " + fine + ", startDate = '"+ startDate +"', endDate = '"+endDate+"' where id = " + id + " ";

                        string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                        MessageBox.Show("Payment updated successfully");

                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("You need select one row");
            }
            else
            {
                var row = dataGridView1.SelectedRows[0];
                var id = row.Cells[0].Value.ToString();


                string sqlQuery = "delete from BILL where id = '" + id + "'";

                string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                MessageBox.Show("Delete successfully");
                this.refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Payment f = new Payment();
            f.Show();
        }
    }
}
