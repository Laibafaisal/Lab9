using System.Data;
using System.Data.SqlClient;

class Program {
    static void Main(string[] args)
    {
        string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Assignment3;Integrated Security=True";
        string query = " SELECT customer_id, companyName from Customer";
        SqlConnection con = new SqlConnection(cs);

        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        DataTable dataTable = ds.Tables[0];
        Console.WriteLine("Customer ID  Company Name");
        if (dataTable != null)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    Console.Write($"{row[column]}\t");
                }
                Console.WriteLine();
            }
        }

    } 
}
