using ECommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ECommerceApp.DomainModel
{
	public class Cart : EntityBase
	{
		private ICollection<CartItem> _cartItems;
		private Customer _customer;

		public Cart(Customer customer)
		{
			_cartItems = new List<CartItem>();
			Customer = customer;
		}

		public IReadOnlyCollection<CartItem> CartItems
		{
			get
			{
				return _cartItems.ToImmutableList();
			}
		}

		public void AddCartItem(CartItem cartItem)
		{
			if (FieldValidationService.ValidateNotNull(cartItem) == false || _cartItems.Contains(cartItem))
			{
				throw new ArgumentException();
			}

			_cartItems.Add(cartItem);
		}

		public bool RemoveCartItem(CartItem cartItem)
		{
			if (FieldValidationService.ValidateNotNull(cartItem) == false)
			{
				throw new ArgumentException();
			}

			return _cartItems.Remove(cartItem);
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
