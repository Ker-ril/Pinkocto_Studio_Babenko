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
    public partial class Room : Form
    {
        public Room()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.refresh();
        }

        public void refresh() {
            string sqlQuery = "select * from ROOM";

            DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["Id"], dr["Square"], dr["idType"]); ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add BTN
            proccessDataRoom r = new proccessDataRoom();
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // edit 
            foreach (DataGridViewRow data in dataGridView1.Rows)
            {
                try
                {
                    var check = data.Cells[0].Value;
                    if (check != null)
                    {
                        int id = (int)data.Cells[0].Value;
                        var square = data.Cells[1].Value;
                        var idType = data.Cells[2].Value;


                        //check bill
                        string typeQ = "select * from TYPE where id = '" + idType + "'";

                        DataTable existType = DataBaseConnection.dataAdapterSelect(typeQ);

                        if (existType.Rows.Count == 0)
                        {
                            MessageBox.Show("Type not exist");
                        }

                        string sqlQuery = "update ROOM SET idType = " + idType + ", Square = '" + square + "' where id = "+ id+"";

                        string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }

            MessageBox.Show("Payment updated successfully");
            this.refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //remove
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("You need select one row");
            }
            else
            {
                var row = dataGridView1.SelectedRows[0];
                var id = row.Cells[0].Value.ToString();


                string sqlQuery = "delete from ROOM where id = '" + id + "'";

                string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                MessageBox.Show("Delete successfully");
                this.refresh();
            }
        }

        private void Room_Load(object sender, EventArgs e)
        {
            this.refresh();
        }

        private void button_AddNewType_Click(object sender, EventArgs e)
        {
            Type form = new Type();
            form.Show();
        }
    }
}
