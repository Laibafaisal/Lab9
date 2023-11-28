using System.Data.SqlClient;

namespace Lab9_Ex4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DATABASE_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=iag;Integrated Security=True;Encrypt=False";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                MessageBox.Show("Connection established successfully!");
                string q = "SELECT* FROM Student";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    MessageBox.Show(dr["Student_ID"].ToString() + "\t" + dr["Student_Name"]);   
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
