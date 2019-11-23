using System;

namespace ECommerceApp.DomainModel
{
	public abstract class EntityBase
	{
		public EntityBase()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id
		{ 
			get; 
			private set; 
		}
	}
}
