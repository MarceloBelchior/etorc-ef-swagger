using System;
namespace torc.model
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public ICollection<Order>? Orders { get; set; }
	}
}

