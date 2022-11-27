

using Accessors.InsertIntoDB;
using Accessors.PullFromDB;
using Accessors.RemoveFromDB;
using DataContainers;
using System.Data.SqlClient;
using Tools;

namespace Tests
{
    [TestClass]
    public class TestDBUpdates
    {

        [TestMethod]
        public void AddCountryAlreadyInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var x = new InsertCountry();
                con.Open();
                try
                {
                    x.Insert("Japan", con);
                }catch(Exception ex)
                {
                    Assert.IsNotNull(ex.Message);
                }
                con.Close();
            }
        }

        [TestMethod]
        public void AddStateAlreadyInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var x = new InsertState();
                con.Open();
                try
                {
                    x.Insert("Nebraska", con);
                }catch(Exception ex)
                {
                    Assert.IsNotNull(ex.Message);
                }
                con.Close();
            }
        }

        [TestMethod]
        public void AddAddressAlreadyInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                Address address= new Address();
                address.City = "Palmyra";
                address.Country = "US";
                address.State = "Nebraska";
                address.ZipCode = "68418";
                address.Street = "700 A Street";

                var inAddress =  new InsertAddress();
                con.Open();
                try
                {
                    inAddress.Insert(address, con);
                }catch(Exception ex)
                {
                    Assert.IsNotNull(ex.Message);
                }
                con.Close();
            }
        }

        [TestMethod]
        public void AddCustomerAlreadyInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var inCustomer = new InsertCustomer();
                Address address= new Address();
                address.City = "Palmyra";
                address.Country = "US";
                address.State = "Nebraska";
                address.ZipCode = "68418";
                address.Street = "700 A Street";
                Customer customer = new Customer();
                customer.Address = address;
                customer.LastName = "Church";
                customer.FirstName = "Jeffrey";

                con.Open();
                try
                {
                    inCustomer.Insert(customer, con);
                } catch(Exception ex)
                {
                    Assert.IsNotNull(ex.Message);
                }
            }
            

            
        }

        [TestMethod]
        public void AddCountryNotInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var inCountry = new InsertCountry();
                var remCountry = new RemoveCountry();
                con.Open();
                Assert.IsNotNull(inCountry.Insert("Fake", con));
                Assert.AreEqual(remCountry.Remove("Fake", con), 1);
                con.Close();
            }
            
        }

        [TestMethod]
        public void AddStateNotInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var inState = new InsertState();
                var remState = new RemoveState();
                con.Open();
                Assert.IsNotNull(inState.Insert("Fake", con));
                Assert.AreEqual(remState.Remove("Fake", con), 1);
                con.Close();
            }
            
        }

        [TestMethod]
        public void AddAddressNotInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var inAddress = new InsertAddress();
                var remAddress = new RemoveAddress();
                Address address= new Address();
                address.City = "Lincoln";
                address.Country = "US";
                address.State = "Nebraska";
                address.ZipCode = "68418";
                address.Street = "700 A";

                con.Open();
                Assert.IsNotNull(inAddress.Insert(address, con));
                Assert.AreEqual(remAddress.Remove(address, con), 1);
                con.Close();
            }
            
        }

        [TestMethod]
        public void AddCustomerNotInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var inCustomer = new InsertCustomer();
                var remCustomer = new RemoveCustomer();
                Address address= new Address();
                address.City = "Palmyra";
                address.Country = "US";
                address.State = "Nebraska";
                address.ZipCode = "68418";
                address.Street = "700 A Street";
                Customer customer = new Customer();
                customer.Address = address;
                customer.LastName = "Church";
                customer.FirstName = "Megan";

                con.Open();
                Assert.IsNotNull(inCustomer.Insert(customer, con));
                Assert.AreEqual(remCustomer.Remove(customer, con), 1);
                con.Close();
            }
        }
    }

    [TestClass]
    public class TestDBPulls
    {
        [TestMethod]
        public void PullStateIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getSt = new GetStateId();
                con.Open();
                Assert.IsNotNull(getSt.Get("Nebraska", con));
                con.Close();
            }
            
        }

        [TestMethod]
        public void PullCountryIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getCountry = new GetCountryId();
                con.Open();
                Assert.IsNotNull(getCountry.Get("US", con));
                con.Close();
            }
            
        }

        [TestMethod]
        public void PullAddressIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getAddress = new GetAddressId();
                Address address= new Address();
                address.City = "Palmyra";
                address.Country = "US";
                address.State = "Nebraska";
                address.ZipCode = "68418";
                address.Street = "700 A Street";

                con.Open();
                Assert.IsNotNull(getAddress.Get(address, con));
                con.Close();
            }
            
        }

        [TestMethod]
        public void PullCustomerIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getCustomerId = new GetCustomerId();
                Customer customer = new Customer();
                Address address= new Address();

                address.City = "Palmyra";
                address.Country = "US";
                address.State = "Nebraska";
                address.ZipCode = "68418";
                address.Street = "700 A Street";

                customer.Address = address;
                customer.LastName = "Church";
                customer.FirstName = "Jeffrey";

                con.Open();
                Assert.IsNotNull(getCustomerId.Get(customer, con));
                con.Close();
            }
        }
    }
}