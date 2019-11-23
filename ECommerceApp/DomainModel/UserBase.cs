using ECommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ECommerceApp.DomainModel
{
	public abstract class UserBase : EntityBase
	{
		private string _email;
		private string _password;
		private string _phone;

		public UserBase(string email, string password, string phone)
		{
			Email = email;
			Password = password;
			Phone = phone;
		}

		public string Email
		{
			get
			{
				return _email;
			}
			private set
			{
				if (FieldValidationService.ValidateEmail(value) == false)
				{
					throw new ArgumentException();
				}

				_email = value;
			}
		}

		private string Password
		{
			get
			{
				return _password;
			}
			set
			{
				if (FieldValidationService.ValidatePassword(value) == false)
				{
					throw new ArgumentException("Пароль должен быть как минимум 8 символов длиной");
				}

				_password = value;
			}
		}

		public string Phone
		{
			get
			{
				return _phone;
			}
			private set
			{
				if (FieldValidationService.ValidatePhone(value) == false)
				{
					throw new ArgumentException();
				}

				_phone = value;
			}
		}
	}
}
