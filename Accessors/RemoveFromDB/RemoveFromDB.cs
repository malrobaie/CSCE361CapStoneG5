using Accessors.PullFromDB;
using DataContainers;
using System.Data.SqlClient;

namespace Accessors.RemoveFromDB
{
    public interface IRemove<in T> where T : class
        {
            public int Remove(T var, SqlConnection con);
        }

    public class RemoveCountry : IRemove<string>
        {
            public int Remove(string country, SqlConnection con)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Country] WHERE (country = @country);";
                    cmd.Parameters.AddWithValue("@country", country);
                    return cmd.ExecuteNonQuery();
                }
            
            }
        }

    public class RemoveState : IRemove<string>
        {
            public int Remove(string state, SqlConnection con)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [State] WHERE (state = @state);";
                    cmd.Parameters.AddWithValue("@state", state);
                    return cmd.ExecuteNonQuery();
                }
            
            }
        }

    public class RemoveAddress : IRemove<Address>
    {
        public int Remove(Address address, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                var getAddress = new GetAddressId();
                cmd.CommandText = "DELETE FROM [Address] WHERE (addressId = @addressId);";
                cmd.Parameters.AddWithValue("@addressId", getAddress.Get(address, con));
                return cmd.ExecuteNonQuery();
            }
            
        }
    }

    public class RemoveCustomer : IRemove<Customer>
    {
        public int Remove(Customer customer, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                var getCustomer = new GetCustomerId();
                cmd.CommandText = "DELETE FROM [Customer] WHERE (customerId = @customerId);";
                cmd.Parameters.AddWithValue("@customerId", getCustomer.Get(customer, con));
                return cmd.ExecuteNonQuery();
            }
            
        }
    }
}
