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
    public partial class Developer : Form
    {
        public Developer()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            SubjectArea subjectArea = new SubjectArea();
            subjectArea.Show();
        }
    }
}
