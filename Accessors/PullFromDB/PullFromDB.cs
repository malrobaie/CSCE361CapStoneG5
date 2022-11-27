using DataContainers;
using System.Data.SqlClient;

namespace Accessors.PullFromDB
{
    public interface IGet<in T> where T : class
        {
            public string? Get(T var, SqlConnection con);
        }

    public class GetStateId : IGet<string>
        {
            public string? Get(string state, SqlConnection con)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    string? stateId = null;
                    cmd.CommandText = "SELECT stateId FROM State WHERE (state = @state);";
                    cmd.Parameters.AddWithValue("@state", state);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            stateId = reader["stateId"].ToString();
                        }
                    }
                    return stateId;
                }
            }
        }

    public class GetCountryId : IGet<string>
        {
            public string? Get(string country, SqlConnection con)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    string? countryId = null;
                    cmd.CommandText = "SELECT countryId FROM Country WHERE (country = @country);";
                    cmd.Parameters.AddWithValue("@country", country);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            countryId = reader["countryId"].ToString();
                        }
                    }
                    return countryId;
                }
            }
        }

    public class GetAddressId : IGet<Address>
    {
        public string? Get(Address address, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                var x = new GetCountryId();
                var y = new GetStateId();
                string? addressId = null;
                cmd.CommandText = "SELECT addressId FROM Address WHERE (street = @street) and (city = @city) and (stateId = @stateId) and (countryId = @countryId);";
                cmd.Parameters.AddWithValue("@countryId", int.Parse(x.Get(address.Country, con)));
                cmd.Parameters.AddWithValue("@stateId", int.Parse(y.Get(address.State, con)));
                cmd.Parameters.AddWithValue("@city", address.City);
                cmd.Parameters.AddWithValue("@street", address.Street);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        addressId = reader["addressId"].ToString();
                    }
                }
                return addressId;
            }
        }
    }

    public class GetCustomerId : IGet<Customer>
    {
        public string? Get(Customer customer, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                var getAddress = new GetAddressId();
                string? customerId = null;
                cmd.CommandText = "SELECT customerId FROM Customer WHERE (lastName = @lastName) and " +
                                    "(firstName = @firstName) and (addressId = @addressId);";
                cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@addressId", int.Parse(getAddress.Get(customer.Address, con)));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        customerId = reader["customerId"].ToString();
                    }
                }
                return customerId;
            }
        }
    }
}
