using ECommerceApp.Services;
using System;

namespace ECommerceApp.DomainModel
{
	public class Payment : EntityBase
	{
		private Order _order;

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
			get;
			private set;
		}

		public void UpdatePaymentStage()
		{
			if (PaymentStage == PaymentStage.FinishedSuccessFully ||
				PaymentStage == PaymentStage.Failed)
			{
				PaymentStage++;
			}
		}
	}
}
