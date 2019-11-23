using ECommerceApp.Services;
using System;

namespace ECommerceApp.DomainModel
{
	//В реальности имеет кучу служебных полей связанных внетренней обработкой
	public class ConcreteProduct : EntityBase
	{
		private long _productId;
		private ProductBase _product;

		public ConcreteProduct(ProductBase product)
		{
			ProductId = LongIdGenerator.Increment();
			Product = product;
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

		public long ProductId
		{
			get
			{
				return _productId;
			}
			private set
			{
				if (FieldValidationService.ValidateNotNegativeNumber(value) == false)
				{
					throw new ArgumentException();
				}

				_productId = value;
			}
		}
	}
}
