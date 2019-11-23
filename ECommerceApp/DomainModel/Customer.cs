using ECommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ECommerceApp.DomainModel
{
	public class Customer : UserBase
	{
		private string _firstName;
		private string _lastName;
		private DateTime? _birthday;
		private IList<ProductBase> _favoriteProducts;

		public Customer(
			string firstName, 
			string lastName,
			DateTime? birthday,
			Sex? sex,
			string phone,
			string email,
			string password) : base(email, password, phone)
		{
			FirstName = firstName;
			LastName = lastName;
			Birthday = birthday;
			Sex = sex;
		}

		public string FirstName
		{
			get
			{
				return _firstName;
			}
			private set
			{
				if (FieldValidationService.ValidateString(value) == false)
				{
					throw new ArgumentException("Имя должно быть непустой строкой", nameof(FirstName));
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
			private set
			{
				if (FieldValidationService.ValidateString(value) == false)
				{
					throw new ArgumentException("Имя должно быть непустой строкой", nameof(LastName));
				}

				_lastName = value;
			}
		}

		public IReadOnlyCollection<ProductBase> FavoriteProducts
		{
			get
			{
				return _favoriteProducts.ToImmutableList();
			}
		}

		public void AddFavoriteProduct(ProductBase product)
		{
			if (FieldValidationService.ValidateNotNull(product) == false 
				|| _favoriteProducts.Contains(product))
			{
				throw new ArgumentException();
			}

			_favoriteProducts.Add(product);
		}

		public bool RemoveFavoriteProduct(ProductBase product)
		{
			if (FieldValidationService.ValidateNotNull(product) == false)
			{
				throw new ArgumentException();
			}

			return _favoriteProducts.Remove(product);
		}

		public DateTime? Birthday
		{
			get
			{
				return _birthday;
			}
			private set
			{
				if (value != null && FieldValidationService.ValidateUserAge(value.Value) == false)
				{
					throw new ArgumentException(
						$"Ваш возраст должен быть как { FieldValidationService.MIN_USER_AGE } минимум лет");
				}

				_birthday = value;
			}
		}

		public Sex? Sex
		{
			get;
			private set;
		}

		public void UpdatePersonalData(
			string firstName, 
			string lastName, 
			Sex? sex,
			DateTime? birthday)
		{
			FirstName = firstName;
			LastName = lastName;
			Birthday = birthday;
			Sex = sex;
		}
	}
}
