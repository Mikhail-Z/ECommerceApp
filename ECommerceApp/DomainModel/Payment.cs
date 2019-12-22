using ECommerceApp.Services;
using System;

namespace ECommerceApp.DomainModel
{
	public class Payment : EntityBase
	{
		private Order _order;
		private PaymentStage _paymentStage;

		public Payment(Order order)
		{
			PaymentStage = PaymentStage.NotStarted;
			Order = order;
		}

		public Order Order
		{
			get
			{
				return _order;
			}
			private set
			{
				if (FieldValidationService.ValidateNotNull(value) == false)
				{
					throw new ArgumentException();
				}

				_order = value;
			}
		}

		public PaymentStage PaymentStage
		{
			get
			{
				return _paymentStage;
			}
			set
			{
				if (_paymentStage >= value || _paymentStage + 1 != value)
				{
					throw new ArgumentException();
				}

				_paymentStage = value;
				
			}
		}
	}
}
