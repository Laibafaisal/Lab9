using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;

namespace Lab9_Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Assignment3;Integrated Security=True;Encrypt=True";
            string query = "SELECT Product_ID, Name, UnitPrice from Product WHERE unitprice > paramValue ORDER BY unitprice DESC";
            int pricePoint = 30;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@paramValue", pricePoint);

            try
            {
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}", dataReader[0], dataReader[1], dataReader[2]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}