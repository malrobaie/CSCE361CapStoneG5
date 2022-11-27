using Accessors.PullFromDB;
using DataContainers;
using System.Data.SqlClient;

namespace Accessors.InsertIntoDB
{
    public interface IInsert<in T> where T : class
    {
        /**
            * in an open SQL connection (con), this opens a command, adds the command text to insert the given element into the database, does not check if it is already present.
            */
        public string? Insert(T obj, SqlConnection con);
    }

    public class InsertCountry : IInsert<string>
    {
        /**
            * in an open SQL connection (con), this opens a command, adds the command text to insert the given element into the database, does not check if it is already present.
            * returns the string representation of the new Id from the insert.
            */

        public string? Insert(string country, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                string? countryId = null;
                cmd.CommandText = "insert into [Country] (country) values (@country);" +
                                    "SELECT countryId FROM Country WHERE countryId = SCOPE_IDENTITY();";
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

    public class InsertState : IInsert<string>
    {
        /**
        * in an open SQL connection (con), this opens a command, adds the command text to insert the given element into the database, does not check if it is already present.
        * returns the string representation of the new Id from the insert.
        */
        public string? Insert(string state, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                string? stateId = null;
                cmd.CommandText = "insert into [State] (state) values (@state);" +
                                    "SELECT stateId FROM State WHERE stateId = SCOPE_IDENTITY();";
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

    public class InsertAddress : IInsert<Address>
    {
        /**
            * in an open SQL connection (con), this opens a command, adds the command text to insert the given element into the database, does not check if it is already present.
            * returns the string representation of the new Id from the insert.
            */
        public string? Insert(Address address, SqlConnection con)
        {
            var getCountry = new GetCountryId();
            var getState = new GetStateId();
            var insertCountry =  new InsertCountry();
            var insertState = new InsertState();
            string? addressId = null;
            string? countryId = getCountry.Get(address.Country, con);
            if (countryId == null)
            {
                countryId = insertCountry.Insert(address.Country, con);
            }

            string? stateId = getState.Get(address.State, con);
            if (stateId == null)
            {
                stateId = insertState.Insert(address.State, con);
            }

            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "insert into [Address] (street,city,zipCode,stateId,countryId) values (@street, @city, @zipCode, @stateId, @countryId);" +
                                    "SELECT addressId FROM Address WHERE addressId = SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@stateId", Int32.Parse(stateId));
                cmd.Parameters.AddWithValue("@countryId", Int32.Parse(countryId));
                cmd.Parameters.AddWithValue("@street", address.Street);
                cmd.Parameters.AddWithValue("@city", address.City);
                cmd.Parameters.AddWithValue("@zipCode", address.ZipCode);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        addressId = reader["addressId"].ToString();
                    }
                }
            }

            return addressId;
        }
    }

    public class InsertCustomer : IInsert<Customer>
    {
        public string? Insert(Customer customer, SqlConnection con)
        {
            
            var getAddress = new GetAddressId();
            var insertAddress = new InsertAddress();
            string? customerId = null;
            string? addressId = getAddress.Get(customer.Address, con);
            if(addressId == null)
            {
                addressId = insertAddress.Insert(customer.Address, con);
            }

            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "insert into Customer (lastName, firstName, addressId) values (@lastName, @firstName, @addressId);" +
                                    "SELECT CustomerId FROM Customer WHERE customerId = SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@addressId", int.Parse(addressId));
           
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        customerId = reader["customerId"].ToString();
                    }
                }
            }

            return customerId;
        }
    }
}
