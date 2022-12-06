using Accessors.PullFromDB;
using DataContainers;
using System.Data.SqlClient;
using Tools;

namespace Accessors.UpdateDB
{
    public class UpdateCart
    {
        public static int Update(Customer customer)
        {
            int rows = 0;
            
            using(SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    var getCustId = new GetCustomer();
                    var getProdId = new GetProduct();
                    cmd.CommandText = "delete from CartProduct WHERE (customerId = @custId);";

                    cmd.Parameters.AddWithValue("@custId", getCustId.GetId(customer));

                    rows += cmd.ExecuteNonQuery();
                }

                foreach(Product item in customer.Cart.Keys)
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        var getCustId = new GetCustomer();
                        var getProdId = new GetProduct();
                        cmd.CommandText = "insert into CartProduct(quantity, customerId, productId) values (@quantity, @custId, @prodId);";

                        cmd.Parameters.AddWithValue("@custId", getCustId.GetId(customer));
                        cmd.Parameters.AddWithValue("@prodId", getProdId.GetId(item));
                        cmd.Parameters.AddWithValue("@quantity", customer.Cart.GetValueOrDefault(item));

                        rows += cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
            return rows;
        }
    }
}
