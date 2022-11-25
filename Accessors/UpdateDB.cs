

using System.Data.SqlClient;
using Tools;
using DataContainers;

namespace Accessors
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
                using (SqlCommand cmd = con.CreateCommand())
            {

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
}