

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
                con.Open();
                try
                {
                    InsertCountry.Insert("Japan", con);
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
                con.Open();
                try
                {
                    InsertState.Insert("Nebraska", con);
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
                address.Street = "700 A";

                con.Open();
                try
                {
                    InsertAddress.Insert(address, con);
                }catch(Exception ex)
                {
                    Assert.IsNotNull(ex.Message);
                }
                con.Close();
            }
        }


        [TestMethod]
        public void AddCountryNotInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                Assert.IsNotNull(InsertCountry.Insert("Fake", con));
                Assert.AreEqual(RemoveCountry.Remove("Fake", con), 1);
                con.Close();
            }
            
        }

        [TestMethod]
        public void AddStateNotInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                Assert.IsNotNull(InsertState.Insert("Fake", con));
                Assert.AreEqual(RemoveState.Remove("Fake", con), 1);
                con.Close();
            }
            
        }

        [TestMethod]
        public void AddAddressNotInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                Address address= new Address();
                address.City = "Lincoln";
                address.Country = "US";
                address.State = "Nebraska";
                address.ZipCode = "68418";
                address.Street = "700 A";

                con.Open();
                Assert.IsNotNull(InsertAddress.Insert(address, con));
                Assert.AreEqual(RemoveAddress.Remove(address, con), 1);
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
                con.Open();
                Assert.IsNotNull(GetStateId.Get("Nebraska", con));
                con.Close();
            }
            
        }

        [TestMethod]
        public void PullCountryIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                con.Open();
                Assert.IsNotNull(GetCountryId.Get("US", con));
                con.Close();
            }
            
        }

        [TestMethod]
        public void PullAddressIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                Address address= new Address();
                address.City = "Palmyra";
                address.Country = "US";
                address.State = "Nebraska";
                address.ZipCode = "68418";
                address.Street = "700 A";

                con.Open();
                Assert.IsNotNull(GetAddressId.Get(address, con));
                con.Close();
            }
            
        }
    }
}