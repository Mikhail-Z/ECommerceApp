using ECommerceApp.Services;
using System;

namespace ECommerceApp.DomainModel
{
	public class Order : EntityBase
	{
		private Cart _cart;
		private Delivery _delivery;
		private decimal _totalPrice;
		private OrderStage _orderStage;

		public Order(
			Cart cart,
			PaymentType paymentType, 
			Delivery delivery)
		{
			Cart = cart;
			PaymentType = paymentType;
			Delivery = delivery;
			TotalPrice = DiscountService.CalculatePriceWithDiscount(cart.Customer, cart.CartItems) 
				+ delivery.DeliveryCost;
			_orderStage = OrderStage.SuccessfullyMade;
		}

		public Cart Cart
		{
			get
			{
				return _cart;
			}
			private set
			{
				if (FieldValidationService.ValidateNotNull(value) == false)
				{
					throw new ArgumentException();
				}

				_cart = value;
			}
		}

		public PaymentType PaymentType
		{
			get;
			set;
		}

		public Delivery Delivery
		{
			get
			{
				return _delivery;
			}
			set
			{
				if (FieldValidationService.ValidateNotNull(value) == false)
				{
					throw new ArgumentException();
				}
				_delivery = value;
			}
		}

		public decimal TotalPrice
		{
			get
			{
				return _totalPrice;
			}
			set
			{
				if (FieldValidationService.ValidateNotNegativeNumber(value) == false)
				{
					throw new ArgumentException();
				}

				_totalPrice = value;
			}
		}

		public void UpdateOrderStage()
		{
			if (_orderStage == OrderStage.Cancelled || _orderStage == OrderStage.Issued)
			{
				throw new ArgumentException();
			}

			_orderStage++;
		}

		public void CancelOrder()
		{
			if (_orderStage == OrderStage.Cancelled || _orderStage == OrderStage.Issued)
			{
				throw new ArgumentException();
			}

			_orderStage = OrderStage.Cancelled;
		}
	}
}
