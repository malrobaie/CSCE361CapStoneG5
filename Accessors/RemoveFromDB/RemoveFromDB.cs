using Accessors.PullFromDB;
using DataContainers;
using System.Data.SqlClient;
using System.Net;

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
                var getAddress = new GetAddress();
                cmd.CommandText = "DELETE FROM [Address] WHERE (addressId = @addressId);";
                cmd.Parameters.AddWithValue("@addressId", getAddress.GetId(address, con));
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
                var getCustomer = new GetCustomer();
                cmd.CommandText = "DELETE FROM [Customer] WHERE (customerId = @customerId);";
                cmd.Parameters.AddWithValue("@customerId", getCustomer.GetId(customer, con));
                return cmd.ExecuteNonQuery();
            }
            
        }
    }

    public class RemoveSale : IRemove<Sale>
    {
        public int Remove(Sale sale, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                var getSale = new GetSale();
                cmd.CommandText = "DELETE FROM [Sale] WHERE (saleId = @saleId);";
                cmd.Parameters.AddWithValue("@saleId", getSale.GetId(sale, con));
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public class RemoveProduct : IRemove<Product>
    {
        public int Remove(Product product, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                var getProduct = new GetProduct();
                cmd.CommandText = "DELETE FROM [Product] WHERE (productId = @productId);";
                cmd.Parameters.AddWithValue("@productId", getProduct.GetId(product, con));
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public class RemoveCreditCard : IRemove<CreditCard>
    {
        public int Remove(CreditCard creditCard, SqlConnection con)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                var getCC = new GetCreditCard();
                cmd.CommandText = "DELETE FROM [CreditCard] WHERE (creditId = @creditId);";
                cmd.Parameters.AddWithValue("@creditId", getCC.GetId(creditCard, con));
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
