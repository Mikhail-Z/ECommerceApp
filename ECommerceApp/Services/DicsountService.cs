using ECommerceApp.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceApp.Services
{
	public static class DicsountService
	{
		public static decimal CalculatePriceWithDiscount(Customer customer, IReadOnlyCollection<ProductBase> products, PaymentType paymentType)
		{
			return products.AsEnumerable().Select(p => p.Price).Sum();
		}
	}
}
