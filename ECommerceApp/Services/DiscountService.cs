using ECommerceApp.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Services
{
	public static class DiscountService
	{
		public static decimal CalculatePriceWithDiscount(
			Customer customer, IReadOnlyCollection<CartItem> cartItems)
		{
			//TODO логика с customer
			return cartItems.Sum(x => x.Product.Price);
		}
	}
}
