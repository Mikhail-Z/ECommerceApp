using ECommerceApp.Services;
using System;
using System.Collections.Generic;

namespace ECommerceApp.DomainModel
{
	public class Delivery : EntityBase
	{
		private DeliveryPoint _deliveryPoint;
		private decimal _deliveryCost;
		private DateTime _deliveryDate;

		public Delivery(
			DeliveryPoint deliveryPoint,
			decimal deliveryCost,
			DateTime deliveryDate,
			DeliveryType deliveryType)
		{
			DeliveryType = deliveryType;
			IsFinished = false;
			DeliveryPoint = deliveryPoint;
			PlannedDeliveryDate = deliveryDate;
			DeliveryCost = deliveryCost;
		}

		public static IList<DeliveryPoint> GetDeliveryPoints()
		{
			return new List<DeliveryPoint> 
			{
				new DeliveryPoint("Рязань, Рязанская обл., г. Рязань, ул. Новоселов, д. 49"),
				new DeliveryPoint("Рязань, Рязанская обл., г. Рязань, ул. Ленина, д. 50") 
			};
		}

		public decimal DeliveryCost
		{
			get
			{
				return _deliveryCost;
			}
			set
			{
				if (FieldValidationService.ValidateNotNegativeNumber(value) == false)
				{
					throw new ArgumentException();
				}

				_deliveryCost = value;
			}
		}

		public DateTime PlannedDeliveryDate
		{
			get
			{
				return _deliveryDate;
			}
			set
			{
				if (FieldValidationService.ValidateFutureDate(value) == false)
				{
					throw new ArgumentException();
				}

				_deliveryDate = value;
			}
		}

		private DateTime? ActualDeliveryDate
		{
			get; set;
		}

		public DeliveryType DeliveryType
		{
			get;
			private set;
		}

		public DeliveryPoint DeliveryPoint
		{
			get
			{
				return _deliveryPoint;
			}
			private set
			{
				if (FieldValidationService.ValidateNotNull(value) == false)
				{
					throw new ArgumentException();
				}

				_deliveryPoint = value;
			}
		}

		public bool IsFinished
		{
			get;
			private set;
		}

		public void FinishDelivery()
		{
			if (IsFinished == true)
			{
				throw new ArgumentException("Товар уже получен.");
			}

			IsFinished = true;
			ActualDeliveryDate = DateTime.Now;
		}

		public void UpdatePlannedDeliveryDate(DateTime plannedDeliveryDate)
		{
			PlannedDeliveryDate = plannedDeliveryDate;
		}
	}
}
