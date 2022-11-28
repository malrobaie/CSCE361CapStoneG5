using System.Data.SqlClient;

namespace Tools
{
    public class DBTools
    {
        public static SqlConnection ConnectToDB()
        {
            SqlConnection con = new("Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
            return con;
        }

        public static string GetID(string type, string table, string identifier)
        {
            string SQLText = "SELECT " + type + "Id FROM " + table + " WHERE (" + type + " = '" + identifier + "')";
            return SQLText;
        }

    }
}