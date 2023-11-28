using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab9_Ex6_8_9_QuerynDataGridView
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=iag;Integrated Security=True;Encrypt=False";
            using (SqlConnection c = new SqlConnection(cs))
            {
                c.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("Select * From Student", c))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
