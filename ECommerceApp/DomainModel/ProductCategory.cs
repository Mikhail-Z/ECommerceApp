using ECommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.DomainModel
{
	public class ProductCategory : EntityBase
	{
		private string _name;

		public ProductCategory(string name, ProductCategory parentProductCategory)
		{
			Name = name;
			ParentProductCategory = parentProductCategory;
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

		public ProductCategory ParentProductCategory { get; private set; }
	}
}
