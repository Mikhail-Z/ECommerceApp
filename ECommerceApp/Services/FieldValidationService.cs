using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ECommerceApp.Services
{
	public static class FieldValidationService
	{
		public const int MIN_STRING_LENGTH = 1;
		public const int MIN_EMAIL_LENGTH = 3;
		public const int MIN_USER_AGE = 18;
		public const int MIN_PASSWORD_LENGTH = 8;

		private static Regex _phoneRegex = new Regex(@"\+7 \d{3} \d{3} \d{2} \d{2}\Z");

		public static bool ValidateString(string s)
		{
			return String.IsNullOrWhiteSpace(s) == false && s.Length >= MIN_STRING_LENGTH;
		}

		public static bool ValidateFutureDateTime(DateTime dateTime)
		{
			return dateTime > DateTime.Now;
		}

		public static bool ValidateFutureDate(DateTime dateTime)
		{
			var currentDateTime = DateTime.Now;
			return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day)
				> new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day);
		}

		public static bool ValidatePastDate(DateTime dateTime)
		{
			var currentDateTime = DateTime.Now;
			return new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day)
				> new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
		}

		public static bool ValidatePastDateTime(DateTime dateTime)
		{
			return DateTime.Now >= dateTime;
		}

		public static bool ValidateUserAge(DateTime birthday)
		{
			return birthday.AddYears(MIN_USER_AGE) <= DateTime.Now;
		}

		public static bool ValidatePhone(string phone)
		{
			return _phoneRegex.IsMatch(phone);
		}

		public static bool ValidatePositiveNumber(decimal number)
		{
			return number > 0;
		}

		public static bool ValidateNotNegativeNumber(decimal number)
		{
			return number >= 0;
		}

		public static bool ValidateNotEmptyCollection<T>(ICollection<T> collection)
		{
			return collection.Count > 0;
		}

		public static bool ValidateEnumerable<T>(IEnumerable<T> enumerable)
		{
			int count = 0;
			foreach (var item in enumerable) count++;
			return count > 0;
		}

		public static bool ValidateNotNull(Object o)
		{
			return o != null;
		}

		public static bool ValidateEmail(string email)
		{
			return email.Length >= MIN_EMAIL_LENGTH && email.Contains("@");
		}

		public static bool ValidatePassword(string password)
		{
			return password.Length >= MIN_PASSWORD_LENGTH;
		}
	}
}
