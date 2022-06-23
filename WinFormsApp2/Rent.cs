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
    public partial class Rent : Form
    {
        public Rent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addRent r = new addRent();
            r.Show();
        }

        public void refresh() {
            string sqlQuery = "select * from RENT";

            DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add(dr["Id"], dr["roomId"], dr["TenantId"], dr["startDate"], dr["finalDate"]); ;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.refresh();
        }

        private void Rent_Load(object sender, EventArgs e)
        {
            this.refresh();
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


                string sqlQuery = "delete from RENT where id = '" + id + "'";

                string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                MessageBox.Show("Delete successfully");
                this.refresh();
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
                        var roomId = data.Cells[1].Value;
                        var tanentId = data.Cells[2].Value;
                        var startDate = data.Cells[3].Value;
                        var finalDate = data.Cells[4].Value;

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


                        if (finalDate.GetType() == typeof(string))
                        {
                            DateTime d = DateTime.Parse((string)finalDate);
                            finalDate = d.ToString("yyyy-MM-dd");
                        }
                        else if (finalDate.GetType() == typeof(DateTime))
                        {
                            var temp = ((DateTime)finalDate).ToString();
                            DateTime d = DateTime.Parse((string)temp);
                            finalDate = d.ToString("yyyy-MM-dd");
                        }




                        //check rent
                        string existRoomQ = "select * from ROOM where id = '" + roomId + "'";
                        string existTanentQ = "select * from TENANT where id = '" + tanentId + "'";

                        DataTable room = DataBaseConnection.dataAdapterSelect(existRoomQ);
                        DataTable tanent = DataBaseConnection.dataAdapterSelect(existTanentQ);

                        if (room.Rows.Count == 0)
                        {
                            MessageBox.Show("Room not exist");
                        }
                        else if (tanent.Rows.Count == 0)
                        {
                            MessageBox.Show("Tanent not exist");

                        }
                        else {

                            // check exist rent for current room and period
                            String q2 = "select * from RENT where roomId = " + roomId + " AND (('" + startDate + "' >= RENT.startDate AND '" + startDate + "' <= RENT.finalDate) " +
                                "OR ('" + finalDate + "' >= RENT.startDate AND '" + finalDate + "' <= RENT.finalDate) OR ('" + startDate + "' <= RENT.startDate AND '" + finalDate + "' >= RENT.finalDate)) AND "+id+" != RENT.Id";

                            DataTable resultForTrigger = DataBaseConnection.dataAdapterSelect(q2);

                            if (resultForTrigger.Rows.Count != 0)
                            {
                                MessageBox.Show("Room for selected period was rent");
                            }
                            else
                            {
                                string sqlQuery = "update RENT SET roomId = " + roomId + ", TenantId = '" + tanentId + "'," +
                                " startDate = '" + startDate + "', finalDate = " + finalDate + " where id = " + id + " ";

                                string dt = DataBaseConnection.sqlCommandQuery(sqlQuery);

                                MessageBox.Show("Rent updated successfully");
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }
        }
    }
}
