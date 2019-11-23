using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.DomainModel
{
	public enum OrderStage
	{
		SuccessfullyMade = 1,
		Packaging,
		Delivering,
		DeliveredToDeliveryPoint,
		ReadyForDelivery,
		Issued,
		Cancelled = 0
	}
}
