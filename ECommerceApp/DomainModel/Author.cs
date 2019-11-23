using ECommerceApp.Services;
using System;

namespace ECommerceApp.DomainModel
{
	public class Author : EntityBase
	{
		public string _firstName;
		public string _lastName;

		public Author(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				if (FieldValidationService.ValidateString(value) == false)
				{
					throw new NotImplementedException("Имя должно быть непустой строкой");
				}

				_firstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				if (FieldValidationService.ValidateString(value) == false)
				{
					throw new NotImplementedException("Имя должно быть непустой строкой");
				}

				_lastName = value;
			}
		}
	}
}
