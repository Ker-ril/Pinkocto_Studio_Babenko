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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            this.refresh();
        }

        public void refresh()
        {
            string sqlQuery = "select * from PAYMENT";

            DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["Id"], dr["IdBill"], (DateTime)dr["datePayment"], dr["sum"]); ;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processDataPayment p = new processDataPayment();
            p.Show();
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
                        var idBill = data.Cells[1].Value;
                        var datePayment = data.Cells[2].Value;
                        var sum = data.Cells[3].Value;
                        var res = data.Cells[2].Value;


                        if (res.GetType() == typeof(string))
                        {
                            DateTime d = DateTime.Parse((string)datePayment);
                            res = d.ToString("yyyy-MM-dd");
                        }
                        else if (datePayment.GetType() == typeof(DateTime)) {
                            var temp = ((DateTime)datePayment).ToString();
                            DateTime d = DateTime.Parse((string)temp);
                            res = d.ToString("yyyy-MM-dd");
                        }


                        //check bill
                        string billQ = "select * from BILL where id = '" + idBill + "'";

                        DataTable existBill = DataBaseConnection.dataAdapterSelect(billQ);

                        if (existBill.Rows.Count == 0)
                        {
                            MessageBox.Show("Bill not exist");
                        }

                        string sqlQuery = "update PAYMENT SET idBill = " + idBill + ", datePayment = '" + res + "', sum = "+sum+" where id = " + id + " ";

                        string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }

            MessageBox.Show("Payment updated successfully");
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


                string sqlQuery = "delete from PAYMENT where id = '" + id + "'";

                string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                MessageBox.Show("Delete successfully");
                this.refresh();
            }
        }
    }
}
