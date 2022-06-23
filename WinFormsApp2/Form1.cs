using System.Data;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string sqlQuery = "select * from TYPE";

            //DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            //foreach (DataRow dr in dt.Rows)
            //{
            //    dataGridView1.Rows.Add(dr["Id"], dr["Price"], dr["name"]);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //addData add = new addData();
            //add.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string sqlQuery = "select * from TYPE";

            //DataTable dt = DataBaseConnection.dataAdapterSelect(sqlQuery);

            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();

            //foreach (DataRow dr in dt.Rows)
            //{
            //    dataGridView1.Rows.Add(dr["Id"], dr["Price"], dr["name"]);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Type form = new Type();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserFrom form = new UserFrom();
            form.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Room f = new Room();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tenant f = new Tenant();
            f.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
            
            
        }
    }
}