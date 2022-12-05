

using Accessors.InsertIntoDB;
using Accessors.PullFromDB;
using Accessors.RemoveFromDB;
using DataContainers;
using HT.Components;
using Accessors.UpdateDB;

namespace Tests
{
    [TestClass]
    public class TestDBInserts
    {

        [TestMethod]
        public void AddCountryAlreadyInDataBase()
        {
                var x = new InsertCountry();
                
                try
                {
                    x.Insert("US");
                }catch(Exception ex)
                {
                    Assert.IsNotNull(ex.Message);
                }
        }

        [TestMethod]
        public void AddStateAlreadyInDataBase()
        {
                var x = new InsertState();
                try
                {
                    x.Insert("Nebraska");
                }catch(Exception ex)
                {
                    Assert.IsNotNull(ex.Message);
                }
        }

        [TestMethod]
        public void AddAddressAlreadyInDataBase()
        {
                Address address= new Address();
                address.City = "Spokane";
                address.Country = "US";
                address.State = "Missouri";
                address.ZipCode = "99260";
                address.Street = "660 Rowland Lane";

                var inAddress =  new InsertAddress();
                try
                {
                    inAddress.Insert(address);
                }catch(Exception ex)
                {
                    Assert.IsNotNull(ex.Message);
                }
        }

        [TestMethod]
        public void AddCustomerAlreadyInDataBase()
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

                try
                {
                    inCustomer.Insert(customer);
                } catch(Exception ex)
                {
                    Assert.IsNotNull(ex.Message);
                }
        }

        [TestMethod]
        public void AddCreditCardAlreadyInDataBase()
        {
                CreditCard creditCard= new CreditCard();
                creditCard.CVV = 933;
                creditCard.ExperationDate = "2023-08-11";
                creditCard.CreditNumber = 5417395333782837;
                creditCard.CreditName = "Millard''s Master Card";
                creditCard.CreditType = "mastercard";

                var inCard =  new InsertCreditCard();
                try
                {
                    inCard.Insert(creditCard);
                }catch(Exception ex)
                {
                    Assert.IsNotNull(ex.Message);
                }
            
        }

        [TestMethod]
        public void AddCountryNotInDataBase()
        {
                var inCountry = new InsertCountry();
                var remCountry = new RemoveCountry();
                Assert.IsNotNull(inCountry.Insert("DreamLand"));
                Assert.AreEqual(remCountry.Remove("DreamLand"), 1);
                
        }

        [TestMethod]
        public void AddStateNotInDataBase()
        {
                var inState = new InsertState();
                var remState = new RemoveState();
                Assert.IsNotNull(inState.Insert("DreamLand"));
                Assert.AreEqual(remState.Remove("DreamLand"), 1);
               
        }

        [TestMethod]
        public void AddAddressNotInDataBase()
        {
                var inAddress = new InsertAddress();
                var remAddress = new RemoveAddress();
                Address address= new Address();
                address.City = "Fake";
                address.Country = "Fake";
                address.State = "Fake";
                address.ZipCode = "9001";
                address.Street = "Fake A";

                Assert.IsNotNull(inAddress.Insert(address));
                Assert.AreEqual(remAddress.Remove(address), 1);
        }

        [TestMethod]
        public void AddCustomerNotInDataBase()
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

                Assert.IsNotNull(inCustomer.Insert(customer));
                Assert.AreEqual(remCustomer.Remove(customer), 1);
               
        }

        [TestMethod]
        public void AddSaleNotInDataBase()
        {
                var inSale = new InsertSale();
                var remSale = new RemoveSale();
                Sale sale= new Sale();
                sale.StartDate = DateTime.Parse("12/15/2022");
                sale.EndDate = DateTime.Parse("2022-12-31");
                sale.Discount = 1.0;
                sale.Category = "Fake";

                Assert.IsNotNull(inSale.Insert(sale));
                Assert.AreEqual(remSale.Remove(sale), 1);
                
        }

        [TestMethod]
        public void AddProductNotInDataBase()
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
                product.Image = "FakeImageURL";

                Assert.IsNotNull(inProduct.Insert(product));
                Assert.AreEqual(remProduct.Remove(product), 1);
        }

        [TestMethod]
        public void AddCreditCardNotInDataBase()
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

                Assert.IsNotNull(inCC.Insert(creditCard));
                Assert.IsTrue(inCC.ConnectCreditCardToCustomer(customer, creditCard));
                Assert.AreEqual(remCC.Remove(creditCard), 1);
                
        }
    }

    [TestClass]
    public class TestIDPulls
    {
        [TestMethod]
        public void PullStateIDFromDataBase()
        {
                var getSt = new GetState();
                
                Assert.IsNotNull(getSt.GetId("Nebraska"));
                
        }

        [TestMethod]
        public void PullCountryIDFromDataBase()
        {
            var getCountry = new GetCountry();

            Assert.IsNotNull(getCountry.GetId("US"));
        }

        [TestMethod]
        public void PullAddressIDFromDataBase()
        {
            
            var getAddress = new GetAddress();
            Address address= new Address();
            address.City = "Spokane";
            address.Country = "US";
            address.State = "Missouri";
            address.ZipCode = "99260";
            address.Street = "660 Rowland Lane";

      
            Assert.IsNotNull(getAddress.GetId(address));
        }

        [TestMethod]
        public void PullCustomerIDFromDataBase()
        {
            var getCustomerId = new GetCustomer();
            Customer customer = new Customer();

            customer.LastName = "Shrubsall";
            customer.FirstName = "Trudey";
            customer.Email = "tshrubsall2@sitemeter.com";

            Assert.IsNotNull(getCustomerId.GetId(customer));
                
        }

        [TestMethod]
        public void PullSaleIDFromDataBase()
        {
            var getSale = new GetSale();
            Sale sale= new Sale();
            sale.StartDate = DateTime.Parse("12/2/2022");
            sale.EndDate = DateTime.Parse("12/31/2022");
            sale.Category = "Tech";

            Assert.IsNotNull(getSale.GetId(sale));
             
        }

        [TestMethod]
        public void PullProductIDFromDataBase()
        {
            var getProduct = new GetProduct();
            Product product= new Product();
                
            product.SKU = "p3llq6";

            Assert.IsNotNull(getProduct.GetId(product));
              
        }

        [TestMethod]
        public void PullCreditCardFromDataBase()
        {
            var getCC = new GetCreditCard();
            CreditCard creditCard = new CreditCard();
                
            creditCard.CreditNumber = 4041597035849;

            Assert.IsNotNull(getCC.GetId(creditCard));
               
        }
    }

    [TestClass]
    public class TestDBPulls
    {
        [TestMethod]
        public void PullProductsOfOneCategory()
        {
            
                var getProds = new GetProduct();
                List<Product> products = new List<Product>();
                
                products = getProds.GetProductsBasedOnCategory("Tech");

                Assert.AreNotEqual(products.Count, 0);
            
        }

        [TestMethod]
        public void PullProductsFromSearchTerms()
        {
            
            var getProds = new GetProduct();
            List<Product> products = new List<Product>();

            products = getProds.GetProductsFromSearch("ten");
             

            Assert.AreNotEqual(products.Count, 0);
            
        }

        [TestMethod]
        public void PullProductsFromSale()
        {
            
            Sale sale = new Sale();
            sale.StartDate = DateTime.Parse("12/15/2022");
            sale.EndDate = DateTime.Parse("12/15/2022");
            sale.Discount = 0.4;
            sale.Category = "Tech";
            var getProds = new GetProduct();
            List<Product> products = new List<Product>();

            products = getProds.GetProductsFromSale(sale);

                
            Assert.AreNotEqual(products.Count, 0);
            
        }

        [TestMethod]
        public void PullCustomerByEmail()
        {
            var getCust = new GetCustomer();

            Customer customer = getCust.GetCustomerFromEmail("mblakeston@businessinsider.com");

            Assert.AreEqual(customer.FirstName, "Millard");
        }

        [TestMethod]
        public void PullAllCardsForOneCutomer()
        {
            var getCard = new GetCreditCard();
            var getCust = new GetCustomer();
            
            Customer customer = getCust.GetCustomerFromEmail("dellenbrook3@yahoo.com");

            getCard.GetAllCardsForCustomer(customer);

            Assert.AreEqual(customer.paymentMethods.Count, 3);
        }

        [TestMethod]
        public void PullSalesList()
        {
            List<Sale> sales = GetSale.GetSaleList();
            
            Assert.AreNotEqual(sales.Count, 0);
        }

        [TestMethod]
        public void PullCustomerCart()
        {
            Customer customer = new Customer();

            customer.LastName = "Shrubsall";
            customer.FirstName = "Trudey";
            customer.Email = "tshrubsall2@sitemeter.com";

            GetCart.GetCustomerCart(customer);

            Assert.AreEqual(customer.Cart.Count, 3);
            Assert.AreEqual(customer.Cart.Values.Sum(), 5);
        }
    }

    [TestClass]
    public class TestDBUpdates
    {
        [TestMethod]
        public void UpdateCustomerCartAddingAProductToCart()
        {
            Product product= new Product();
            product.Name = "Prada 55WS";
            product.Image = "/Users/kevinakerberg/git/CSCE361CapStoneG5/images/prada_55ws.png";
            product.Category = "Fashion";
            product.Price = 369.99;
            product.ManufacturerInfo = "EssilorLuxottica";
            product.Description = "Polarized universal fit sunglasses";
            product.Height = 2;
            product.Width = 7;
            product.Depth = 0.1;
            product.SKU = "ngadg8";
            
            var getCust = new GetCustomer();
            
            Customer customer = getCust.GetCustomerFromEmail("tshrubsall2@sitemeter.com");

            customer.Cart.Add(product, 12);

            int rows = UpdateCart.Update(customer);

            Assert.AreEqual(7, rows);

            customer.Cart.Remove(product);
            foreach(var item in customer.Cart)
            {
                Console.WriteLine(item.Key.Name);
            }
            rows = UpdateCart.Update(customer);

            Assert.AreEqual(7, rows);
        }
    }
}