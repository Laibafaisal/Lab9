using System.Data;
using System.Data.SqlClient;

namespace Lab9_Ex6_8_9_QuerynDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static void createCommand(string q, string c)
        {
            using (SqlConnection con = new SqlConnection(c))
            {
                SqlCommand cmd = new SqlCommand(q, con);
                //con.Open();
                cmd.Connection.Open();
                int res = cmd.ExecuteNonQuery();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form2();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new Form3();
            f.Show();
        }
    }
}
