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
    public partial class addData : Form
    {
        public addData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String title = textBox1.Text;
            String name = textBox2.Text;
            int minLvl = (int)numericUpDown1.Value;
            int maxLvl = (int)numericUpDown2.Value;

            String Query = "insert into jobs (job_desc, min_lvl, max_lvl) values ('"  +name + "','"+minLvl+"','"+maxLvl+"')";

            string dt = DataBaseConnection.sqlCommandQuery(Query);


            MessageBox.Show(dt);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void addData_Load(object sender, EventArgs e)
        {

        }
    }
}
