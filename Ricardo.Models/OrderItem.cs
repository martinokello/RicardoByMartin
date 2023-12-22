namespace Ricardo.Models
{
	public class OrderItem
	{
		public Item Item { get; }
		public int Quantity { get; set; }
		public int Total => Item.Price * Quantity;
		public OrderItem(Item item, int quantity)
		{
			Item = item;
			Quantity = quantity;
		}

	}
}
