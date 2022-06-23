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
    public partial class Tenant : Form
    {
        public Tenant()
        {
            InitializeComponent();
        }

        private void Tenant_Load(object sender, EventArgs e)
        {
            this.refresh();
        }

        public void refresh() {
            string sqlQuery = "select * from TENANT";

            DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["Id"], dr["Name"], dr["address"], dr["directorName"], dr["characteristic"], dr["bankAccount"], dr["financialOpportunities"]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addTenant f = new addTenant();
            f.Show();
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
                        //var name = textBox1.Text;
                        //var address = textBox3.Text;
                        //var directorName = textBox2.Text;
                        //var characteristic = textBox4.Text;
                        //var bankAccount = textBox5.Text;
                        //var financialOpportunities = checkBox1.Checked;

                        var id = data.Cells[0].Value;
                        var name = data.Cells[1].Value;
                        var address = data.Cells[2].Value;
                        var directorName = data.Cells[3].Value;
                        var characteristic = data.Cells[4].Value;
                        var bankAccount = data.Cells[5].Value;
                        var financialOpportunities = data.Cells[6].Value;

                        string sqlQuery = "update TENANT SET financialOpportunities = '" + financialOpportunities + "', name = '" + name + "', characteristic = '" + characteristic + "', bankAccount = '" + bankAccount + "', address = '" + address + "', directorName = '" + directorName + "'" +
                            " where id = " + id + " ";

                        string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }

            MessageBox.Show("Tenant updated successfully");
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


                string sqlQuery = "delete from TENANT where id = '" + id + "'";

                string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                MessageBox.Show("Delete successfully");
                this.refresh();
            }
        }
    }
}
