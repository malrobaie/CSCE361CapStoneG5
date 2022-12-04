using DataContainers;
namespace Tests
{
	[TestClass]
	public class TestCartTotals
	{
		[TestMethod]
		public void TestCartTotal1()
		{
			var cart = new Cart(); // assumes we have a data container for a cart
			cart.add(); // need methods for the cart to add and take away items from its list of products. Mohammad was working on this in the front end, but it seems like more of a back end thing
		}
	}
}