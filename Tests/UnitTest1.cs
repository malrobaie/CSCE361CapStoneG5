

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
                    x.Insert("US", con);
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
                address.City = "Spokane";
                address.Country = "US";
                address.State = "Missouri";
                address.ZipCode = "99260";
                address.Street = "660 Rowland Lane";

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
                Customer customer = new Customer();

                address.City = "Lincoln";
                address.Country = "US";
                address.State = "Illinois";
                address.ZipCode = "68524";
                address.Street = "23 Lotheville Road";

                customer.Address = address;
                customer.LastName = "Shrubsall";
                customer.FirstName = "Trudey";
                customer.Email = "tshrubsall2@sitemeter.com";

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
        public void AddCreditCardAlreadyInDataBase()
        {
             using (SqlConnection con = DBTools.ConnectToDB())
            {
                CreditCard creditCard= new CreditCard();
                creditCard.CVV = 933;
                creditCard.ExperationDate = "2023-08-11";
                creditCard.CreditNumber = 5417395333782837;
                creditCard.CreditName = "Millard''s Master Card";
                creditCard.CreditType = "mastercard";

                var inCard =  new InsertCreditCard();
                con.Open();
                try
                {
                    inCard.Insert(creditCard, con);
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
                var inCountry = new InsertCountry();
                var remCountry = new RemoveCountry();
                con.Open();
                Assert.IsNotNull(inCountry.Insert("DreamLand", con));
                Assert.AreEqual(remCountry.Remove("DreamLand", con), 1);
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
                Assert.IsNotNull(inState.Insert("DreamLand", con));
                Assert.AreEqual(remState.Remove("DreamLand", con), 1);
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
                address.City = "Fake";
                address.Country = "Fake";
                address.State = "Fake";
                address.ZipCode = "9001";
                address.Street = "Fake A";

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
                address.City = "Fake";
                address.Country = "Fake";
                address.State = "Fake";
                address.ZipCode = "Fake";
                address.Street = "Fake Street";
                Customer customer = new Customer();
                customer.Address = address;
                customer.LastName = "Fake";
                customer.FirstName = "Fake";
                customer.Email = "Fake@Fake.com";

                con.Open();
                Assert.IsNotNull(inCustomer.Insert(customer, con));
                Assert.AreEqual(remCustomer.Remove(customer, con), 1);
                con.Close();
            }
        }

        [TestMethod]
        public void AddSaleNotInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var inSale = new InsertSale();
                var remSale = new RemoveSale();
                Sale sale= new Sale();
                sale.StartDate = "2022-12-05";
                sale.EndDate = "2022-12-31";
                sale.Discount = 1.0;
                sale.Category = "Fake";

                con.Open();
                Assert.IsNotNull(inSale.Insert(sale, con));
                Assert.AreEqual(remSale.Remove(sale, con), 1);
                con.Close();
            }
        }

        [TestMethod]
        public void AddProductNotInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var inProduct = new InsertProduct();
                var remProduct = new RemoveProduct();
                Product product= new Product();
                product.Category = "Fake";
                product.Depth = 9001;
                product.Width = 9001;
                product.Height = 9001;
                product.Description = "Fake Product";
                product.Price = 9001.00;
                product.ManufacturerInfo = "Fake Manufacturer";
                product.Name = "Fake Name";
                product.SKU = "FakeSKU9001";

                con.Open();
                Assert.IsNotNull(inProduct.Insert(product, con));
                Assert.AreEqual(remProduct.Remove(product, con), 1);
                con.Close();
            }
        }

        [TestMethod]
        public void AddCreditCardNotInDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var inCC = new InsertCreditCard();
                var remCC = new RemoveCreditCard();
                
                CreditCard creditCard = new CreditCard();
                Address address= new Address();
                Customer customer = new Customer();

                address.City = "Lincoln";
                address.Country = "US";
                address.State = "Illinois";
                address.ZipCode = "68524";
                address.Street = "23 Lotheville Road";

                customer.Address = address;
                customer.LastName = "Shrubsall";
                customer.FirstName = "Trudey";
                customer.Email = "tshrubsall2@sitemeter.com";

                creditCard.CVV = 123;
                creditCard.ExperationDate = "2030-10-10";
                creditCard.CreditNumber = 2222222222222222;
                creditCard.CreditName = "Fake";
                creditCard.CreditType = "Fake";

                con.Open();
                Assert.IsNotNull(inCC.Insert(creditCard, con));
                Assert.IsTrue(inCC.ConnectCreditCardToCustomer(customer, creditCard, con));
                Assert.AreEqual(remCC.Remove(creditCard, con), 1);
                con.Close();
            }
        }
    }

    [TestClass]
    public class TestIDPulls
    {
        [TestMethod]
        public void PullStateIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getSt = new GetState();
                con.Open();
                Assert.IsNotNull(getSt.GetId("Nebraska", con));
                con.Close();
            }
            
        }

        [TestMethod]
        public void PullCountryIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getCountry = new GetCountry();
                con.Open();
                Assert.IsNotNull(getCountry.GetId("US", con));
                con.Close();
            }
            
        }

        [TestMethod]
        public void PullAddressIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getAddress = new GetAddress();
                Address address= new Address();
                address.City = "Spokane";
                address.Country = "US";
                address.State = "Missouri";
                address.ZipCode = "99260";
                address.Street = "660 Rowland Lane";

                con.Open();
                Assert.IsNotNull(getAddress.GetId(address, con));
                con.Close();
            }
        }

        [TestMethod]
        public void PullCustomerIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getCustomerId = new GetCustomer();
                Customer customer = new Customer();
                Address address= new Address();

                address.City = "Lincoln";
                address.Country = "US";
                address.State = "Illinois";
                address.ZipCode = "68524";
                address.Street = "23 Lotheville Road";

                customer.Address = address;
                customer.LastName = "Shrubsall";
                customer.FirstName = "Trudey";
                customer.Email = "tshrubsall2@sitemeter.com";

                con.Open();
                Assert.IsNotNull(getCustomerId.GetId(customer, con));
                con.Close();
            }
        }

        [TestMethod]
        public void PullSaleIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getSale = new GetSale();
                Sale sale= new Sale();
                sale.StartDate = "2022-12-2";
                sale.EndDate = "2022-12-31";
                sale.Category = "Tech";

                con.Open();
                Assert.IsNotNull(getSale.GetId(sale, con));
                con.Close();
            }
        }

        [TestMethod]
        public void PullProductIDFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getProduct = new GetProduct();
                Product product= new Product();
                
                product.SKU = "p3llq6";

                con.Open();
                Assert.IsNotNull(getProduct.GetId(product, con));
                con.Close();
            }
        }

        [TestMethod]
        public void PullCreditCardFromDataBase()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getCC = new GetCreditCard();
                CreditCard creditCard = new CreditCard();
                
                creditCard.CreditNumber = 4041597035849;

                con.Open();
                Assert.IsNotNull(getCC.GetId(creditCard, con));
                con.Close();
            }
        }
    }

    [TestClass]
    public class TestDBPulls
    {
        [TestMethod]
        public void PullProductsOfOneCategory()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getProds = new GetProduct();
                List<Product> products = new List<Product>();
                con.Open();
                products = getProds.GetProductsBasedOnCategory("Tech", con);
                con.Close();

                Assert.AreNotEqual(products.Count, 0);
            }
        }

        [TestMethod]
        public void PullProductsFromSearchTerms()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getProds = new GetProduct();
                List<Product> products = new List<Product>();
                con.Open();
                products = getProds.GetProductsFromSearch("ten", con);
                con.Close();

                Assert.AreNotEqual(products.Count, 0);
            }
        }

        [TestMethod]
        public void PullProductsFromSale()
        {
            using (SqlConnection con = DBTools.ConnectToDB())
            {
                var getProds = new GetProduct();
                List<Product> products = new List<Product>();
                con.Open();
                products = getProds.GetProductsFromSearch("ten", con);
                con.Close();

                Assert.AreNotEqual(products.Count, 0);
            }
        }
    }
}