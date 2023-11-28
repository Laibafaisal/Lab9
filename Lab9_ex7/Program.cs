using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Assignment3;Integrated Security=True;Encrypt=False";
        //SqlCommand cmd = new SqlCommand();
        //cmd.CommandText = "SELECT COUNT(*) FROM Product";
        //Int32 count = (Int32)cmd.ExecuteScalar();
        AddProductCategory("Marker", cs);
    }

    static public int AddProductCategory (string newName, string cs)
    {
        Int32 newProd_ID = 0;
        string sql = "Insert into product (Name) values (@name) " + "Select CAST (scope_identity() AS int)";
        
        using(SqlConnection con = new SqlConnection(cs)) 
        { 
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            cmd.Parameters["@name"].Value = newName;
            try
            {
                con.Open();
                newProd_ID = (Int32)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return (Int32)newProd_ID;
        }

    }
}