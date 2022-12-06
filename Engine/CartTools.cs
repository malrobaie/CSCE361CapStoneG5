/**
 * This class contains the methods necessary for working with a shopping
 * cart object in the online cart program
 */

using DataContainers;
namespace Engine
{
	public class CartTools
	{
		public double? getCartTotal(Cart cart) {
            double total = 0;
			List<Product> products = cart.getProducts(); // have to ask how we are storing the cart data in C#, this assumes a cart will have a list of products that can be retrieved with a getter

			var productTools = new ProductTools();

			for(int i=0; i<products.Count; i++) {
                productTools.setSalePrice(products[i]);
				total += products[i].Price;
			}

			double tax = total * 0.08;
			total += tax;

            return total;
        }
	}
}

