using Accessors.PullFromDB;
using DataContainers;
using System.Data.SqlClient;
using Tools;

namespace Accessors.RemoveFromDB
{
    public interface IRemove<in T> where T : class
        {
            public int Remove(T var);
        }

    public class RemoveCountry : IRemove<string>
        {
            public int Remove(string country)
            {
                using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                int rows;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Country] WHERE (country = @country);";
                    cmd.Parameters.AddWithValue("@country", country);
                    rows = cmd.ExecuteNonQuery();
                }
                con.Close();
                return rows;
            }
                
            
            }
        }

    public class RemoveState : IRemove<string>
    {
        public int Remove(string state)
        {
            using(SqlConnection conn = DBTools.ConnectToDB())
            {
                conn.Open();
                int rows;
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [State] WHERE (state = @state);";
                    cmd.Parameters.AddWithValue("@state", state);
                    rows = cmd.ExecuteNonQuery();
                }
                conn.Close();
                return rows;
            }
                
            
        }
    }

    public class RemoveAddress : IRemove<Address>
    {
        public int Remove(Address address)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                int rows;
                using (SqlCommand cmd = con.CreateCommand())
                {
                    var getAddress = new GetAddress();
                    cmd.CommandText = "DELETE FROM [Address] WHERE (addressId = @addressId);";
                    cmd.Parameters.AddWithValue("@addressId", getAddress.GetId(address));
                    rows = cmd.ExecuteNonQuery();
                }
                con.Close();
                return rows;
            }
        }
    }

    public class RemoveCustomer : IRemove<Customer>
    {
        public int Remove(Customer customer)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                int rows;

                using (SqlCommand cmd = con.CreateCommand())
                {
                    var getCustomer = new GetCustomer();
                    cmd.CommandText = "DELETE FROM [Customer] WHERE (customerId = @customerId);";
                    cmd.Parameters.AddWithValue("@customerId", getCustomer.GetId(customer));
                    rows = cmd.ExecuteNonQuery();
                }
                con.Close();
                return rows;
            }
        }
    }

    public class RemoveSale : IRemove<Sale>
    {
        public int Remove(Sale sale)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                int rows;
            
                using (SqlCommand cmd = con.CreateCommand())
                {
                    var getSale = new GetSale();
                    cmd.CommandText = "DELETE FROM [Sale] WHERE (saleId = @saleId);";
                    cmd.Parameters.AddWithValue("@saleId", getSale.GetId(sale));
                    rows = cmd.ExecuteNonQuery();
                }
                con.Close();
                return rows;
            }
        }
    }

    public class RemoveProduct : IRemove<Product>
    {
        public int Remove(Product product)
        {
            using(SqlConnection con =DBTools.ConnectToDB())
            {
                con.Open();
                int rows;
            
                using (SqlCommand cmd = con.CreateCommand())
                {
                    var getProduct = new GetProduct();
                    cmd.CommandText = "DELETE FROM [Product] WHERE (productId = @productId);";
                    cmd.Parameters.AddWithValue("@productId", getProduct.GetId(product));
                    rows = cmd.ExecuteNonQuery();
                }
                con.Close();
                return rows;
            }
        }
    }

    public class RemoveCreditCard : IRemove<CreditCard>
    {
        public int Remove(CreditCard creditCard)
        {
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                int rows;
            
                using (SqlCommand cmd = con.CreateCommand())
                {
                    var getCC = new GetCreditCard();
                    cmd.CommandText = "DELETE FROM [CreditCard] WHERE (creditId = @creditId);";
                    cmd.Parameters.AddWithValue("@creditId", getCC.GetId(creditCard));
                    rows = cmd.ExecuteNonQuery();
                }
                con.Close();
                return rows;
            }
        }
    }
}
