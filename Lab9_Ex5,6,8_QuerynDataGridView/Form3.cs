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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=iag;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(cs);
            using(SqlCommand sql = new SqlCommand("SELECT * FROM STUDENT", con))
            {
                sql.CommandType = CommandType.Text;
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(sql.ExecuteReader());
                con.Close();
            }
        }
    }
}
