using ECommerceApp.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Services
{
	public static class DeliveryService
	{
		public static decimal CalculateDeliveryCost(Customer customer, IReadOnlyCollection<ProductBase> products, DeliveryPoint deliveryPoint)
		{
			//TODO логика
			return new decimal(99);
		}
	}
}
