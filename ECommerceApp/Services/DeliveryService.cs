using ECommerceApp.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Services
{
	public static class DeliveryService
	{
		private static IReadOnlyList<Delivery> _allDeliveryPoints;

		static DeliveryService()
		{
			_allDeliveryPoints = new List<Delivery>();
		}

		public static IReadOnlyList<Delivery> GetDeliveryPoints(string city)
		{
			return _allDeliveryPoints;
		}

		public static IReadOnlyList<Delivery> GetDeliveryPoints(string city, DeliveryType deliveryType)
		{
			return _allDeliveryPoints;
		}

		public static decimal CalculateDeliveryCost(Customer customer, IReadOnlyCollection<CartItem> cartItems)
		{
			//TODO логика
			return new decimal(99);
		}
	}
}
