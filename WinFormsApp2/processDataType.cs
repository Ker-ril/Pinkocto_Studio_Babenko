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
    public partial class processDataType : Form
    {
        public processDataType()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            int price = (int)numericUpDown1.Value;
            
            String Query = "insert into TYPE (name, Price) values ('" + name + "','" + price + "')";

            string dt = DataBaseConnection.sqlCommandQuery(Query);


            MessageBox.Show(dt);
            this.Close();
        }

        private void processDataType_Load(object sender, EventArgs e)
        {

        }
    }
}
