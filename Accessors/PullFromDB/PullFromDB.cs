using DataContainers;
using System.Data.SqlClient;
using Tools;

namespace Accessors.PullFromDB
{
    public interface IGetID<in T> where T : class
        {
            public string? GetId(T var);
        }

    public class GetState : IGetID<string>
        {
            public string? GetId(string state)
            {
                using(SqlConnection con = DBTools.ConnectToDB())
                {
                    string? stateId = null;
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        
                        cmd.CommandText = "SELECT stateId FROM State WHERE (state = @state);";
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

    public class GetCountry : IGetID<string>
        {
            public string? GetId(string country)
            {
            using(SqlConnection con = DBTools.ConnectToDB())
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
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
                    con.Close();
                    return countryId;
                }
            }
        }

    public class GetAddress : IGetID<Address>
    {
        public string? GetId(Address address)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            using (SqlCommand cmd = con.CreateCommand())
            {
                con.Open();
                var getCountry = new GetCountry();
                var getState = new GetState();
                string? addressId = null;
                cmd.CommandText = "SELECT addressId FROM Address WHERE (street = @street) and (city = @city) and (stateId = @stateId) and (countryId = @countryId);";
                cmd.Parameters.AddWithValue("@countryId", int.Parse(getCountry.GetId(address.Country)));
                cmd.Parameters.AddWithValue("@stateId", int.Parse(getState.GetId(address.State)));
                cmd.Parameters.AddWithValue("@city", address.City);
                cmd.Parameters.AddWithValue("@street", address.Street);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        addressId = reader["addressId"].ToString();
                    }
                }
                con.Close();
                return addressId;
            }
        }
    }

    public class GetCustomer : IGetID<Customer>
    {
        public string? GetId(Customer customer)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                var getAddress = new GetAddress();
                string? customerId = null;
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    
                    cmd.CommandText = "SELECT customerId FROM Customer WHERE (lastName = @lastName) and " +
                                        "(firstName = @firstName) and (addressId = @addressId) and (email = @email);";
                    cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@addressId", int.Parse(getAddress.GetId(customer.Address)));
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

        public Customer GetCustomerFromEmail(string email)
        {
            Customer customer = new Customer();
            customer.Address = new Address();
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    
                    cmd.CommandText = "SELECT Customer.lastName, Customer.firstName, Address.street, Address.city, Address.zipCode, Country.country, State.state " +
                                        "FROM Customer INNER JOIN Address ON Customer.addressId = Address.addressId INNER JOIN Country ON Address.countryId = Country.countryId INNER JOIN " +
                                        "State ON Address.stateId = State.stateId WHERE (Customer.email = @email)";
                    
                    cmd.Parameters.AddWithValue("@email", email);
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            customer.Address.Country = reader["country"].ToString();
                            customer.Address.City = reader["city"].ToString();
                            customer.Address.ZipCode = reader["zipCode"].ToString();
                            customer.Address.State = reader["state"].ToString();
                            customer.Address.Street = reader["street"].ToString();
                            customer.FirstName = reader["firstName"].ToString();
                            customer.LastName = reader["lastName"].ToString();
                            customer.Email = email;
                        }
                    }
                }
                con.Close();
            }
            return customer;
        }
    }

    public class GetSale : IGetID<Sale>
    {
        public string? GetId(Sale sale)
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
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
                    con.Close();
                    return saleId;
                }   
        }

        public static List<Sale> GetSaleList()
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                List<Sale> list = new List<Sale>();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT startDate, endDate, discount, productCategory FROM Sale";
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Sale sale = new Sale();

                            sale.StartDate = DateTime.Parse(reader["startDate"].ToString());
                            sale.Category = reader["productCategory"].ToString();
                            sale.Discount = (double)reader["discount"];
                            sale.EndDate = DateTime.Parse(reader["endDate"].ToString());

                            list.Add(sale);
                        }
                    }
                }
                con.Close();
                return list;
            }
        }
    }

    public class GetProduct : IGetID<Product>
    {
        public string? GetId(Product product)
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
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
                    con.Close();
                    return productId;
                }   
        }

        public List<Product> GetProductsBasedOnCategory(string category)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
            
                List<Product> products = new List<Product>();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, " +
                                        "productWidth, productDepth, productSKU, productImage FROM Product WHERE (productCategory = @category)";
                    
                    cmd.Parameters.AddWithValue("@category", category);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        while(reader.Read())
                        {
                            Product product = new Product();
                            product.Name = reader["productName"].ToString();
                            product.Depth = (double) reader["productDepth"];
                            product.SKU = reader["productSKU"].ToString();
                            product.Description = reader["productDescription"].ToString();
                            product.ManufacturerInfo = reader["manufacturerName"].ToString();
                            product.Width = (double)reader["productWidth"];
                            product.Category = reader["productCategory"].ToString();
                            product.Price = (double)reader["productPrice"];
                            product.Height = (double) reader["productHeight"];
                            product.Image = reader["productImage"].ToString();

                            products.Add(product);
                        }
                    }
                }
                con.Close();
                return products;
            }
        }

        public List<Product> GetProductsFromSearch(string search)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                List<Product> products = new List<Product>();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU, productImage " +
                                        "FROM Product " +
                                        "WHERE (productName LIKE @search) OR (productCategory LIKE @search) OR (manufacturerName LIKE @search) OR (productDescription LIKE @search) OR (productSKU LIKE @search)";

                    search = "%" + search + "%";
                    cmd.Parameters.AddWithValue("@search", search);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Product product = new Product();
                            product.Name = reader["productName"].ToString();
                            product.Depth = (double) reader["productDepth"];
                            product.SKU = reader["productSKU"].ToString();
                            product.Description = reader["productDescription"].ToString();
                            product.ManufacturerInfo = reader["manufacturerName"].ToString();
                            product.Width = (double)reader["productWidth"];
                            product.Category = reader["productCategory"].ToString();
                            product.Price = (double)reader["productPrice"];
                            product.Height = (double) reader["productHeight"];
                            product.Image = reader["productImage"].ToString();

                            products.Add(product);
                        }
                    }
                }
                con.Close();
                return products;
            }
        }

        public List<Product> GetProductsFromSale(Sale sale)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                List<Product> products = new List<Product>();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT productName, productCategory, productPrice, manufacturerName, productDescription, productHeight, productWidth, productDepth, productSKU, productImage " +
                                        "FROM Product " +
                                        "WHERE (productCategory = @category);";

                    cmd.Parameters.AddWithValue("@category", sale.Category);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Product product = new Product();
                            product.Name = reader["productName"].ToString();
                            product.Depth = (double) reader["productDepth"];
                            product.SKU = reader["productSKU"].ToString();
                            product.Description = reader["productDescription"].ToString();
                            product.ManufacturerInfo = reader["manufacturerName"].ToString();
                            product.Width = (double)reader["productWidth"];
                            product.Category = reader["productCategory"].ToString();
                            product.Price = (double)reader["productPrice"];
                            product.Height = (double) reader["productHeight"];
                            product.Image = reader["productImage"].ToString();

                            products.Add(product);
                        }
                    }
                }
                con.Close();
                return products;
            }
        }

    }

    public class GetCreditCard : IGetID<CreditCard>
    {
        public string? GetId(CreditCard cc)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                string? ccId = null;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    
                    cmd.CommandText = "SELECT creditId FROM CreditCard WHERE (creditNumber = @number);";
                    cmd.Parameters.AddWithValue("@number", cc.CreditNumber);

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

        public void GetAllCardsForCustomer(Customer customer)
        {
            customer.paymentMethods = new List<CreditCard>();
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    var getCustId = new GetCustomer();
                    cmd.CommandText = "SELECT creditName, creditType, creditNumber, expDate, cvc FROM CreditCard WHERE (customerId = @custId)";
                    cmd.Parameters.AddWithValue("@custId", getCustId.GetId(customer));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            CreditCard card = new CreditCard();
                            card.CVV = (int)reader["cvc"];
                            card.CreditName = reader["creditName"].ToString();
                            card.CreditNumber = (double)reader["creditNumber"];
                            card.CreditType = reader["credittype"].ToString();
                            card.ExperationDate = reader["expDate"].ToString();

                            customer.paymentMethods.Add(card);
                        }
                    }
                }
                con.Close();
            }
        }
    }

    public class GetCart
    {
        public void GetCustomerCart(Customer customer)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    var getCustId = new GetCustomer();
                    cmd.CommandText = "SELECT creditName, creditType, creditNumber, expDate, cvc FROM CreditCard WHERE (customerId = @custId)";
                    cmd.Parameters.AddWithValue("@custId", getCustId.GetId(customer));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            CreditCard card = new CreditCard();
                            card.CVV = (int)reader["cvc"];
                            card.CreditName = reader["creditName"].ToString();
                            card.CreditNumber = (double)reader["creditNumber"];
                            card.CreditType = reader["credittype"].ToString();
                            card.ExperationDate = reader["expDate"].ToString();

                            customer.paymentMethods.Add(card);
                        }
                    }
                }
                con.Close();
            }
        }
    }


}
