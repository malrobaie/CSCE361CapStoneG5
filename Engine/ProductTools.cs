/**
 * This class contains the methods necessary for working with a shopping
 * cart object in the online cart program
 */

using DataContainers;
namespace Engine
{
	public class ProductTools
	{
		public void setSalePrice(Product product)
		{
			double newPrice = 0;
			double oldPrice = product.Price;
			double discount = 0;

			if (product.Category.Equals("Tech")) {
				// have a list of sales and pull the one that matches the category and whose dates are valid
				// have to ask Jeff what he was thinking regarding pulling stuff out of the database to make into objects
				// Sale sale = get sale from list
				discount = sale.Discount;
				newPrice = oldPrice - (oldPrice * discount);
			}
			else if (product.Category.Equals("Trending")) {
				// Sale sale = get sale from list
				discount = sale.Discount;
                newPrice = oldPrice - (oldPrice * discount);
            }
			else if (product.Category.Equals("Fashion")) {
                // Sale sale = get sale from list
                discount = sale.Discount;
                newPrice = oldPrice - (oldPrice * discount);
            }

			product.Price = newPrice; // update product price with sale price
		}
	}
}

