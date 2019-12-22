using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.DomainModel
{
	public class DeliveryPoint : EntityBase
	{
		public DeliveryPoint(string address) : base()
		{
			Address = address;
		}

		public string Address { get; private set; }
	}
}
