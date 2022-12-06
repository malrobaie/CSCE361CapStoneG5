using DataContainers;
using System.ComponentModel.DataAnnotations;
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
    }
}