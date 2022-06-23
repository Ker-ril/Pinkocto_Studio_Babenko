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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            textBox_Password.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        static public string status;
        void CClose()
        {
            if (status == "running")
                Close();
            if (status == "running2")
                Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox_Login.Text == "Admin") && (textBox_Password.Text == "Admin"))
            {
                CClose();
                status = "running";
            }
            else if ((textBox_Login.Text == "User") && (textBox_Password.Text == "User"))
            {
                CClose();
                status = "running2";
            }
            else{
                MessageBox.Show("Wrong login or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs aboutUs = new AboutUs();
            aboutUs.Show();
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Developer developer = new Developer();  
            developer.Show();   
        }

        private void subjectAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectArea subjectArea = new SubjectArea();
            subjectArea.Show();
        }  
    }
}
