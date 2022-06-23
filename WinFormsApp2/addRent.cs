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
    public partial class addRent : Form
    {
        public addRent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var roomId = numericUpDown1.Value;
            var tenantId = numericUpDown2.Value;

            var startDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            var finalDate = monthCalendar2.SelectionRange.Start.ToString("yyyy-MM-dd");


            string roomQuery = "select * from ROOM where id = " + roomId + "";
            string tenQuery = "select * from TENANT where id = " + tenantId + "";

            DataTable existRoom = DataBaseConnection.dataAdapterSelect(roomQuery);
            DataTable existTenant = DataBaseConnection.dataAdapterSelect(tenQuery);

            if (existRoom.Rows.Count == 0)
            {
                MessageBox.Show("Room not exist");
            } else if (existTenant.Rows.Count == 0) {
                MessageBox.Show("Tenant not exist");
            }
            else
            {

                // check exist rent for current room and period
                String q2 = "select * from RENT where roomId = " + roomId + " AND (('" + startDate + "' >= RENT.startDate AND '" + startDate + "' <= RENT.finalDate) " +
                    "OR ('" + finalDate + "' >= RENT.startDate AND '" + finalDate + "' <= RENT.finalDate) OR ('" + startDate + "' <= RENT.startDate AND '" + finalDate + "' >= RENT.finalDate))";

                DataTable resultForTrigger = DataBaseConnection.dataAdapterSelect(q2);

                if (resultForTrigger.Rows.Count != 0)
                {
                    MessageBox.Show("Room for selected period was rent");
                }
                else
                {
                    String Query = "insert into RENT (roomId, TenantId, startDate, finalDate) " +
                        "values (" + roomId + ",'" + tenantId + "','" + startDate + "', '" + finalDate + "')";

                    string dt = DataBaseConnection.sqlCommandQuery(Query);
                    MessageBox.Show("Rent added");

                    this.Close();
                }

            }
        }
    }
}
