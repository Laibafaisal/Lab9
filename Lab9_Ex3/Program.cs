using System.Data;
using System.Data.SqlClient;
class Program
{
    static void Main(string[] Args)
    {
        //connection with assignment3 database to get products
        string p = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Assignment3;Integrated Security=True;Encrypt=False";
        //connection with iag database to get students who ordered the products
        string s = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=iag;Integrated Security=True;Encrypt=False";
        SqlConnection productsCon = new SqlConnection(p);
        SqlConnection studentsCon = new SqlConnection(s);

        SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Product", productsCon);
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT * From Student", studentsCon);

        DataSet ds = new DataSet();
        da1.Fill(ds, "Products");
        da2.Fill(ds, "Students");

        DataRelation dataRelation = ds.Relations.Add("StudentProducts", ds.Tables[0].Columns["Product_ID"], ds.Tables[1].Columns["Student_ID"]);
        foreach (DataRow dr1 in ds.Tables["Students"].Rows )
        {
            Console.WriteLine(dr1["Student_ID"]);
            foreach (DataRow dr2 in dr1.GetChildRows(dataRelation))
            {
                Console.WriteLine("\t", dr2["Student_ID"]);
            }
        }
    }
}