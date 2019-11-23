using ECommerceApp.DomainModel;
using ECommerceApp.Services;
using System;

namespace ECommerceApp
{
	public class PublishingHouse : EntityBase
	{
		private string _name;

		public PublishingHouse(string name)
		{
			Name = name;
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
					throw new ArgumentException("Название должно быть непустым", nameof(Name));
				}

				_name = value;
			}
		}
	}
}
