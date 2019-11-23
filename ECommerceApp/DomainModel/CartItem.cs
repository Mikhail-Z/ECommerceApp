using ECommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.DomainModel
{
	public class CartItem : EntityBase
	{
		private ProductBase _product;
		private int _count;

		public CartItem(ProductBase product, int count)
		{
			Product = product;
			Count = count;
		}

		public ProductBase Product
		{
			get
			{
				return _product;
			}
			private set
			{
				if (FieldValidationService.ValidateNotNull(value) == false)
				{
					throw new ArgumentException();
				}

				_product = value;
			}
		}

		public int Count
		{
			get
			{
				return _count;
			}
			private set
			{
				if (FieldValidationService.ValidatePositiveNumber(value) == false)
				{
					throw new ArgumentException();
				}

				_count = value;
			}
		}
	}
}
