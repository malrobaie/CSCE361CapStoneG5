/**
 * This class contains the methods necessary for working with a shopping
 * cart object in the online cart program
 */

using Accessors.PullFromDB;
using DataContainers;
namespace Engine
{
	public class CartTools
	{
		public double getCartTotal(String email) {
            double total = 0;

            var newCust = new GetCustomer();
            Customer customer = newCust.GetCustomerFromEmail(email);
            GetCart.GetCustomerCart(customer);

            foreach (var p in customer.Cart)
            {
                total += p.Value * p.Key.Price;
            }

            return total;
        }
	}
}

