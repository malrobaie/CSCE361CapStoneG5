using Accessors.PullFromDB;
using DataContainers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors.RemoveFromDB
{
    public interface IRemove
        {
            public static int Remove(object var, SqlConnection con) 
            {
                return 0;
            }
        }

    public class RemoveCountry : IRemove
        {
            public static int Remove(String country, SqlConnection con)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Country] WHERE (country = @country);";
                    cmd.Parameters.AddWithValue("@country", country);
                    return cmd.ExecuteNonQuery();
                }
            
            }
        }

    public class RemoveState : IRemove
        {
            public static int Remove(String state, SqlConnection con)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [State] WHERE (state = @state);";
                    cmd.Parameters.AddWithValue("@state", state);
                    return cmd.ExecuteNonQuery();
                }
            
            }
        }

    public class RemoveAddress : IRemove
    {
        public static int Remove(Address address, SqlConnection con)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Address] WHERE (addressId = @addressId);";
                    cmd.Parameters.AddWithValue("@addressId", GetAddressId.Get(address, con));
                    return cmd.ExecuteNonQuery();
                }
            
            }
    }
}
