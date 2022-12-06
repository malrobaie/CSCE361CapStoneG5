

/**
 * This class contains the methods necessary for working with a shopping
 * cart object in the online cart program
 */
using DataContainers;
using Accessors.PullFromDB;

namespace Engine
{
	public class ProductTools
	{
		public void setSalePrice(Product product)
		{
			double newPrice = 0;
			double oldPrice = product.Price;
			double discount = 0;
			List<Sale> sales = GetSale.GetSaleList();
			DateTime date = DateTime.Today;

			if (product.Category.Equals("Tech")) {

				Sale sale = sales.FirstOrDefault(o => (o.Category == "Tech"));
				if(sale.StartDate.CompareTo(date) < 0 && sale.EndDate.CompareTo(date) >= 0)
				{
					discount = sale.Discount;
					newPrice = oldPrice - (oldPrice * discount);
				}
				
			}
			else if (product.Category.Equals("Trending")) {

				Sale sale = sales.FirstOrDefault(o => (o.Category == "Trending"));
				if(sale.StartDate.CompareTo(date) < 0 && sale.EndDate.CompareTo(date) >= 0)
				{
					discount = sale.Discount;
					newPrice = oldPrice - (oldPrice * discount);
				}
			}
			else if (product.Category.Equals("Fashion")) {

                Sale sale = sales.FirstOrDefault(o => (o.Category == "Fashion"));
				if(sale.StartDate.CompareTo(date) < 0 && sale.EndDate.CompareTo(date) >= 0)
				{
					discount = sale.Discount;
					newPrice = oldPrice - (oldPrice * discount);
				}

            }

			product.Price = newPrice; // update product price with sale price
		}
	}
}

