using ECommerceApp.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Services
{
	public static class PaymentService
	{
		public static void MakePayment(Payment payment)
		{
			payment.UpdatePaymentStage();
			payment.UpdatePaymentStage();
		}
	}
}
