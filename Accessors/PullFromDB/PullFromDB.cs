using DataContainers;
using System.Data.SqlClient;

namespace Accessors.PullFromDB
{
    public interface IGetID<in T> where T : class
        {
            public string? GetId(T var, SqlConnection con);
        }

    public class GetState : IGetID<string>
        {
            public string? GetId(string state, SqlConnection con)
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

    public class GetCountry : IGetID<string>
        {
            public string? GetId(string country, SqlConnection con)
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

    public class GetAddress : IGetID<Address>
    {
        public string? GetId(Address address, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                var x = new GetCountry();
                var y = new GetState();
                string? addressId = null;
                cmd.CommandText = "SELECT addressId FROM Address WHERE (street = @street) and (city = @city) and (stateId = @stateId) and (countryId = @countryId);";
                cmd.Parameters.AddWithValue("@countryId", int.Parse(x.GetId(address.Country, con)));
                cmd.Parameters.AddWithValue("@stateId", int.Parse(y.GetId(address.State, con)));
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

    public class GetCustomer : IGetID<Customer>
    {
        public string? GetId(Customer customer, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                var getAddress = new GetAddress();
                string? customerId = null;
                cmd.CommandText = "SELECT customerId FROM Customer WHERE (lastName = @lastName) and " +
                                    "(firstName = @firstName) and (addressId = @addressId) and (email = @email);";
                cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@addressId", int.Parse(getAddress.GetId(customer.Address, con)));
                cmd.Parameters.AddWithValue("@email", customer.Email);
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

    public class GetSale : IGetID<Sale>
    {
        public string? GetId(Sale sale, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
                {
                    string? saleId = null;
                    cmd.CommandText = "SELECT saleId FROM Sale WHERE (startDate = @startDate) and (endDate = @endDate) and (productCategory = @category);";
                    cmd.Parameters.AddWithValue("@startDate", sale.StartDate);
                    cmd.Parameters.AddWithValue("@endDate", sale.EndDate);
                    cmd.Parameters.AddWithValue("@category", sale.Category);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            saleId = reader["saleId"].ToString();
                        }
                    }
                    return saleId;
                }   
        }
    }

    public class GetProduct : IGetID<Product>
    {
        public string? GetId(Product product, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
                {
                    string? productId = null;
                    cmd.CommandText = "SELECT productId FROM Product WHERE (productSKU = @sku);";
                    cmd.Parameters.AddWithValue("@sku", product.SKU);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            productId = reader["productId"].ToString();
                        }
                    }
                    return productId;
                }   
        }
    }

    public class GetCreditCard : IGetID<CreditCard>
    {
        public string? GetId(CreditCard cc, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
                {
                    string? ccId = null;
                    cmd.CommandText = "SELECT creditId FROM CreditCard WHERE (creditNumber = @number);";
                    cmd.Parameters.AddWithValue("@number", cc.CreditNumber);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            ccId = reader["creditId"].ToString();
                        }
                    }
                    return ccId;
                }
        }
    }


    public interface IGetDataObject<in T> where T : class
    {
        public void GetAll(T var, SqlConnection con);

        public void GetOne(T var, SqlConnection con);
    }
}
