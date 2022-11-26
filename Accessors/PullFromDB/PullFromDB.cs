using DataContainers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors.PullFromDB
{
    public interface IGet
        {
            public static string Get(object var, SqlConnection con)
            {
                return "";
            } 
        }

    public class GetStateId : IGet
        {
            public static string Get(string state, SqlConnection con)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    string stateId = null;
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

    public class GetCountryId : IGet
        {
            public static string Get(string country, SqlConnection con)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    string countryId = null;
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

    public class GetAddressId : IGet
    {
        public static string Get(Address address, SqlConnection con)
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    string addressId = null;
                    cmd.CommandText = "SELECT addressId FROM Address WHERE (street = @street) and (city = @city) and (stateId = @stateId) and (countryId = @countryId);";
                    cmd.Parameters.AddWithValue("@countryId", int.Parse(GetCountryId.Get(address.Country, con)));
                    cmd.Parameters.AddWithValue("@stateId", int.Parse(GetStateId.Get(address.State, con)));
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
}
