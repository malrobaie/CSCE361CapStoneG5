using DataContainers;
using Engine;
using Accessors.PullFromDB;

namespace Tests
{
	[TestClass]
	public class TestCartTotals
	{
		[TestMethod]
		public void TestCartTotal1()
		{
			var newCust = new GetCustomer();
			Customer customer = newCust.GetCustomerFromEmail("tshrubsall2@sitemeter.com");
			GetCart.GetCustomerCart(customer);

			var cartTools = new CartTools();
			double total = cartTools.getCartTotal("tshrubsall2@sitemeter.com");
			double expected = 2524.95;

			Assert.Equals(total, expected);
		}

        [TestMethod]
        public void TestCartTotal2()
        {
            var newCust = new GetCustomer();
            Customer customer = newCust.GetCustomerFromEmail("mblakeston@businessinsider.com");
            GetCart.GetCustomerCart(customer);

            var cartTools = new CartTools();
            double total = cartTools.getCartTotal("mblakeston@businessinsider.com");
            double expected = 374.98;

            Assert.Equals(total, expected);
        }

        [TestMethod]
        public void TestCartTotal3()
        {
            var newCust = new GetCustomer();
            Customer customer = newCust.GetCustomerFromEmail("dellenbrook3@yahoo.com");
            GetCart.GetCustomerCart(customer);

            var cartTools = new CartTools();
            double total = cartTools.getCartTotal("dellenbrook3@yahoo.com");
            double expected = 369.99;

            Assert.Equals(total, expected);
        }
    }
}