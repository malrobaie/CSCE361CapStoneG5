using DataContainers;
using Microsoft.AspNetCore.Hosting.Server;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Tools
{
    public class DBTools
    {
        public static SqlConnection ConnectToDB()
        {
            //SqlConnection con = new("Data Source=.\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"); //This is jeffs database copy
            SqlConnection con = new("Server=localhost; Database=CSCE361G5; User Id=sa; Password=Csce361G5sql#");
            return con;
        }
    }
}