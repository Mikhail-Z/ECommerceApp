using ECommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ECommerceApp.DomainModel
{
	public class Cart : EntityBase
	{
		private ICollection<ProductBase> _cartItems;

		private Customer _customer;

		public Cart(Customer customer)
		{
			_cartItems = new List<ProductBase>();
			Customer = customer;
		}

		public IReadOnlyCollection<ProductBase> Products
		{
			get
			{
				return _cartItems.ToImmutableList();
			}
		}

		public void Add(ProductBase product)
		{
			if (FieldValidationService.ValidateNotNull(product) == false || _cartItems.Contains(product))
			{
				throw new ArgumentException();
			}

			_cartItems.Add(product);
		}

		public bool RemoveRoduct(ProductBase product)
		{
			if (FieldValidationService.ValidateNotNull(product) == false)
			{
				throw new ArgumentException();
			}

			return _cartItems.Remove(product);
		}

		public Customer Customer
		{
			get
			{
				return _customer;
			}
			private set
			{
				if (FieldValidationService.ValidateNotNull(value) == false)
				{
					throw new ArgumentException();
				}

				_customer = value;
			}
		}
	}
}
