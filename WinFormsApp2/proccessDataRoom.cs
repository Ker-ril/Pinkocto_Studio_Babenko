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
    public partial class proccessDataRoom : Form
    {
        public proccessDataRoom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var idType = numericUpDown2.Value;
            var square = numericUpDown1.Value;


            string sqlQuery = "select * from TYPE where id = '" + idType + "'";

            DataTable existType = DataBaseConnection.dataAdapterSelect(sqlQuery);

            if (existType.Rows.Count == 0)
            {
                MessageBox.Show("Type not exist");
            }
            else {
                String Query = "insert into ROOM (idType,Square) " +
                                             "values ('" + idType + "','" + square + "')";

                string dt = DataBaseConnection.sqlCommandQuery(Query);

                MessageBox.Show("Room added");

                this.Close();
            }
           
        }
    }
}
