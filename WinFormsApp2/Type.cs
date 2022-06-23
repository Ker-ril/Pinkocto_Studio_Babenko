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
    public partial class Type : Form
    {
        public Type()
        {
            InitializeComponent();
        }

        public void refresh() {
            string sqlQuery = "select * from TYPE";

            DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["Id"], dr["Price"], dr["name"]);
            }
        }

        private void Type_Load(object sender, EventArgs e)
        {
            string sqlQuery = "select * from TYPE";

            DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["Id"], dr["Price"], dr["name"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addData add = new addData();
            add.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string sqlQuery = "select * from TYPE";

            DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["Id"], dr["Price"], dr["name"]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            processDataType f = new processDataType();
            f.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string sqlQuery = "select * from TYPE";

            DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["Id"], dr["Price"], dr["name"]);
            }
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
                        var price = data.Cells[1].Value;
                        String name = (string)data.Cells[2].Value;

                        //                UPDATE table_name
                        //SET column1 = value1, column2 = value2, ...
                        //WHERE condition;

                        string sqlQuery = "update TYPE SET name = '" + name + "', Price = '" + price + "' where id = '" + id + "' ";

                        string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                    }
                }
                catch (Exception err) {
                    MessageBox.Show(err.Message);
                }

            }
            MessageBox.Show("Type edited");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("You need select one row");
            }
            else {
                var row = dataGridView1.SelectedRows[0];
                var id = row.Cells[0].Value.ToString();


                string sqlQuery = "delete from TYPE where id = '"+ id +"'";

                string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                MessageBox.Show("Delete successfully");
                this.refresh();
                    
                
            }

        }
    }
}
