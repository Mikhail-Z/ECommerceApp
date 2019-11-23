using ECommerceApp.Services;
using System;

namespace ECommerceApp.DomainModel
{
	public class Delivery : EntityBase
	{
		private string _address;
		private decimal _deliveryCost;
		private DateTime _deliveryDate;

		public Delivery(
			string address,
			decimal deliveryCost,
			DateTime deliveryDate,
			DeliveryType deliveryType)
		{
			DeliveryType = deliveryType;
			IsFinished = false;
			Address = address;
			PlannedDeliveryDate = deliveryDate;
			DeliveryCost = deliveryCost;
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

		public string Address
		{
			get
			{
				return _address;
			}
			private set
			{
				if (FieldValidationService.ValidateString(value) == false)
				{
					throw new ArgumentException();
				}

				_address = value;
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
