using Accessors.PullFromDB;
using DataContainers;
using System.Data.SqlClient;
using Tools;

namespace Accessors.InsertIntoDB
{
    public interface ICreateCustomer
    {
        public void Create(Customer customer);
    }

    public class CreateCustomer : ICreateCustomer
    {
        public void Create(Customer customer)
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                try
                {
                    InsertCountry.Insert("Japan", con);
                }catch(Exception ex)
                {
                    
                }
                con.Close();
            }
        }
    }

    public class UpdateCart
    {
        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    public interface IInsert 
    {
        /**
            * in an open SQL connection (con), this opens a command, adds the command text to insert the given element into the database, does not check if it is already present.
            */
        public static string Insert(object obj, SqlConnection con) 
        { 
            return "";
        }
    }

    public class InsertCountry : IInsert
    {
        /**
            * in an open SQL connection (con), this opens a command, adds the command text to insert the given element into the database, does not check if it is already present.
            * returns the string representation of the new Id from the insert.
            */
        public static string Insert(string country, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                string countryId = null;
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

    public class InsertState : IInsert
    {
        /**
            * in an open SQL connection (con), this opens a command, adds the command text to insert the given element into the database, does not check if it is already present.
            * returns the string representation of the new Id from the insert.
            */
        public static string Insert(string state, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                string stateId = null;
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

    public class InsertAddress : IInsert
    {
        /**
            * in an open SQL connection (con), this opens a command, adds the command text to insert the given element into the database, does not check if it is already present.
            * returns the string representation of the new Id from the insert.
            */
        public static string Insert(Address address, SqlConnection con)
        {
            string addressId = null;
            string countryId = GetCountryId.Get(address.Country, con);
            if (countryId == null)
            {
                countryId = InsertCountry.Insert(address.Country, con);
            }

            string stateId = GetStateId.Get(address.State, con);
            if (stateId == null)
            {
                stateId = InsertState.Insert(address.State, con);
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
}
