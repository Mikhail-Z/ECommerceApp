using ECommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ECommerceApp.DomainModel
{
	public class Book : ProductBase
	{
		private static Regex _isbnRegex = new Regex(@"\A(978-)?\d-\d{6}-\d{2}-\d\Z");

		private ISet<Author> _authors;
		private PublishingHouse _publishingHouse;
		private int _issueYear;
		private int _pagesCount;
		private string _isbn;
		private string _description;

		public Book(
			string name,
			ISet<Author> authors,
			PublishingHouse publishingHouse,
			Language language,
			BookType bookType,
			BookCoverType bookCoverType,
			int pagesCount,
			string description,
			string isbn,
			int issueYear,
			decimal price,
			DateTime created,
			ProductCategory productCategory,
			bool isActive) : base(name, price, productCategory, created, isActive)
		{
			Authors = authors;
			ISBN = isbn;
			IssueYear = issueYear;
			Language = language;
			PublishingHouse = publishingHouse;
			PagesCount = pagesCount;
			Description = description;
			BookType = bookType;
			BookCoverType = bookCoverType;
		}

		public ISet<Author> Authors
		{
			get
			{
				return _authors;
			}
			private set
			{
				if (FieldValidationService.ValidateNotEmptyCollection(value) == false)
				{
					throw new ArgumentException();
				}

				_authors = value;
			}
		}

		public Language Language
		{
			get;
			private set;
		}

		public PublishingHouse PublishingHouse
		{
			get
			{
				return _publishingHouse;
			}
			private set
			{
				if (value == null)
				{
					throw new ArgumentException();
				}

				_publishingHouse = value;
			}
		}

		public int PagesCount
		{
			get
			{
				return _pagesCount;
			}
			private set
			{
				if (FieldValidationService.ValidatePositiveNumber(value) == false)
				{
					throw new ArgumentException();
				}

				_pagesCount = value;
			}
		}

		public string Description
		{
			get
			{
				return _description;
			}
			private set
			{
				if (FieldValidationService.ValidateString(value) == false)
				{
					throw new ArgumentException();
				}

				_description = value;
			}
		}

		public BookType BookType
		{
			get;
			private set;
		}

		public BookCoverType BookCoverType
		{
			get;
			private set;
		}

		public string ISBN
		{
			get
			{
				return _isbn;
			}
			private set
			{
				if (FieldValidationService.ValidateString(value) == false 
					|| _isbnRegex.IsMatch(value) == false)
				{
					throw new ArgumentException();
				}

				_isbn = value;
			}
		}

		public int IssueYear
		{
			get
			{
				return _issueYear;
			}
			set
			{
				if (FieldValidationService.ValidatePastDateTime(new DateTime(value, 1, 1)) == false)
				{
					throw new ArgumentException(); 
				}

				_issueYear = value;
			}
		}
	}
}
