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
			_orderStage = OrderStage.SuccessfullyMade;
			TotalPrice = CalculateTotalPrice();
		}

		private decimal CalculateTotalPrice()
		{
			return DicsountService.CalculatePriceWithDiscount(Cart.Customer, Cart.Products, PaymentType)
				+ Delivery.DeliveryCost;
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

		public OrderStage OrderStage
		{
			get
			{
				return _orderStage;
			}
			set
			{
				if (value == OrderStage.Cancelled)
				{
					if (_orderStage == OrderStage.Issued)
					{
						throw new ArgumentException();
					}

					_orderStage = value;
				}
				else if (_orderStage <= value || _orderStage + 1 != value)
				{
					throw new ArgumentException();
				}

				_orderStage = value;
			}
		}
	}
}
