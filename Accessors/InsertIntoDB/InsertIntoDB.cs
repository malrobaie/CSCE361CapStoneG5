using Accessors.PullFromDB;
using DataContainers;
using System.Data.SqlClient;
using Tools;

namespace Accessors.InsertIntoDB
{
    public interface IInsert<in T> where T : class
    {
        /**
            * in an open SQL connection (con), this opens a command, adds the command text to insert the given element into the database, does not check if it is already present.
            */
        public string? Insert(T obj);
    }

    public class InsertCountry : IInsert<string>
    {
        /**
            * in an open SQL connection (con), this opens a command, adds the command text to insert the given element into the database, does not check if it is already present.
            * returns the string representation of the new Id from the insert.
            */

        public string? Insert(string country)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                string? countryId = null;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    
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
                    
                }
                con.Close();
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
        public string? Insert(string state)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                string? stateId = null;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    
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
                    
                }
                con.Close();
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
        public string? Insert(Address address)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
            
                var getCountry = new GetCountry();
                var getState = new GetState();
                var insertCountry =  new InsertCountry();
                var insertState = new InsertState();
                string? addressId = null;
                string? countryId = getCountry.GetId(address.Country);
                if (countryId == null)
                {
                    countryId = insertCountry.Insert(address.Country);
                }

                string? stateId = getState.GetId(address.State);
                if (stateId == null)
                {
                    stateId = insertState.Insert(address.State);
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
                con.Close();
                return addressId;
            }
        }
    }

    public class InsertCustomer : IInsert<Customer>
    {
        public string? Insert(Customer customer)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
            
                var getAddress = new GetAddress();
                var insertAddress = new InsertAddress();
                string? customerId = null;
                string? addressId = getAddress.GetId(customer.Address);
                if(addressId == null)
                {
                    addressId = insertAddress.Insert(customer.Address);
                }

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "insert into Customer (lastName, firstName, addressId, email) values (@lastName, @firstName, @addressId, @email);" +
                                        "SELECT CustomerId FROM Customer WHERE customerId = SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@addressId", int.Parse(addressId));
                    cmd.Parameters.AddWithValue("@email", customer.Email);
           
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            customerId = reader["customerId"].ToString();
                        }
                    }
                }
                con.Close();
                return customerId;
            }

            
        }
    }

    public class InsertSale : IInsert<Sale>
    {
        public string? Insert(Sale sale)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
            
                string? saleId = null;
            
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "insert into [Sale] (startDate,endDate,discount,productCategory) values (@startDate, @endDate, @discount, @category);" +
                                        "SELECT saleId FROM [Sale] WHERE saleId = SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("@startDate", sale.StartDate);
                    cmd.Parameters.AddWithValue("@endDate", sale.EndDate);
                    cmd.Parameters.AddWithValue("@discount", sale.Discount);
                    cmd.Parameters.AddWithValue("@category", sale.Category);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            saleId = reader["saleId"].ToString();
                        }
                    }
                }
                sale.SaleId = int.Parse(saleId);
                con.Close();
                return saleId;
            }
        }
    }

    public class InsertProduct : IInsert<Product>
    {
        public string? Insert(Product product)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
            
                string? productId = null;

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "insert into Product (productName, productImage, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU) " +
                                                    "values (@productName, @productImage, @productCategory, @productPrice, @manufacturerName, @productDescription, @productHeight, @productWidth, @productDepth, @productSKU);" +
                                        "SELECT productId FROM Product WHERE productId = SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("@productName", product.Name);
                    cmd.Parameters.AddWithValue("@productImage", product.Image);
                    cmd.Parameters.AddWithValue("@productCategory", product.Category);
                    cmd.Parameters.AddWithValue("@productPrice", product.Price);
                    cmd.Parameters.AddWithValue("@manufacturerName", product.ManufacturerInfo);
                    cmd.Parameters.AddWithValue("@productDescription", product.Description);
                    cmd.Parameters.AddWithValue("@productHeight", product.Height);
                    cmd.Parameters.AddWithValue("@productWidth", product.Width);
                    cmd.Parameters.AddWithValue("@productDepth", product.Depth);
                    cmd.Parameters.AddWithValue("@productSKU", product.SKU);
           
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            productId = reader["productId"].ToString();
                        }
                    }
                }
                con.Close();
                return productId;
            }
        }
    }

    public class InsertCreditCard : IInsert<CreditCard>
    {
        public string? Insert(CreditCard cc)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
            
                string? ccId = null;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "insert into [CreditCard] (creditName, creditType, creditNumber, cvc, expDate) " +
                                                    "values (@creditName, @creditType, @creditNumber, @cvc, @expDate);" +
                                        "SELECT creditId FROM [CreditCard] WHERE creditId = SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("@creditName", cc.CreditName);
                    cmd.Parameters.AddWithValue("@creditType", cc.CreditType);
                    cmd.Parameters.AddWithValue("@creditNumber", cc.CreditNumber);
                    cmd.Parameters.AddWithValue("@cvc", cc.CVV);
                    cmd.Parameters.AddWithValue("@expDate", cc.ExperationDate);
            

                    using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                ccId = reader["creditId"].ToString();
                            }
                        }
                }
                con.Close();
                return ccId;
            }
        }

        public bool ConnectCreditCardToCustomer(Customer customer, CreditCard creditCard)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
            
                var getCustId = new GetCustomer();
                bool worked = false;

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "update CreditCard set customerId = @custId where creditNumber = @creditNum;";
                    cmd.Parameters.AddWithValue("@custId", getCustId.GetId(customer));
                    cmd.Parameters.AddWithValue("@creditNum", creditCard.CreditNumber);

                    int rows = cmd.ExecuteNonQuery();
                    worked = rows > 0 ? true : false;
                }
                con.Close();
                return worked;
            }
        }
    }
}
