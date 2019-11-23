using ECommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.DomainModel
{
	public abstract class ProductBase : EntityBase
	{
		private string _name;
		private decimal _price;
		private DateTime _created;
		private DateTime _lastModified;
		private bool _isActive;
		private int _remainingAmount;

		public ProductBase(
			string name,
			decimal price,
			ProductCategory productCategory,
			DateTime created,
			bool isActive)
		{
			Name = name;
			Price = price;
			ProductCategory = productCategory;
			Created = created;
			LastModified = created;
			IsActive = isActive;
		}

		public string Name
		{
			get
			{
				return _name;
			}
			private set
			{
				if (FieldValidationService.ValidateString(value) == false)
				{
					throw new ArgumentException();
				}

				_name = value;
			}
		}

		public decimal Price
		{
			get
			{
				return _price;
			}
			set
			{
				if (FieldValidationService.ValidatePositiveNumber(value) == false)
				{
					throw new ArgumentException();
				}

				_price = value; ;
			}
		}

		public DateTime Created
		{
			get
			{
				return _created;
			}
			set
			{
				if (FieldValidationService.ValidatePastDateTime(value) == false)
				{
					throw new ArgumentException();
				}

				_created = value;
			}
		}

		public DateTime LastModified
		{
			get
			{
				return _lastModified;
			}
			set
			{
				if (FieldValidationService.ValidatePastDateTime(value) == false)
				{
					throw new ArgumentException();
				}

				_lastModified = value;
			}
		}

		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
				LastModified = DateTime.Now;
			}
		}

		public ProductCategory ProductCategory
		{
			get;
			private set;
		}

		public int RemainingCount
		{
			get
			{
				//TODO
				throw new NotImplementedException();
				return _remainingAmount;
			}
			set
			{
				//TODO
				throw new NotImplementedException();
				_remainingAmount = value;
			}
		}
	}
}
