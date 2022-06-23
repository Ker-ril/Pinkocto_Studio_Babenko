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
    public partial class addTenant : Form
    {
        public addTenant()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var address = textBox3.Text;
            var directorName = textBox2.Text;
            var characteristic = textBox4.Text;
            var bankAccount = textBox5.Text;
            var financialOpportunities = checkBox1.Checked;

            String Query = "insert into TENANT (name, address,directorName,characteristic,bankAccount,financialOpportunities) " +
                "values ('" + name + "','" + address + "','" + directorName + "','" + characteristic+ "','" + bankAccount + "','" + financialOpportunities + "')";

            string dt = DataBaseConnection.sqlCommandQuery(Query);


            MessageBox.Show(dt);
            this.Close();
        }

        private void addTenant_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
