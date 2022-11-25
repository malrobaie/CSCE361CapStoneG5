using System.Data.SqlClient;

namespace Tools
{
    public class DBTools
    {
        public static SqlConnection ConnectToDB()
        {
            SqlConnection con = new("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Group5;Integrated Security=True");
            return con;
        }

    }
}