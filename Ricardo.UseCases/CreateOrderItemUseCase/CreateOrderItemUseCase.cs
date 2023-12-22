using Ricardo.Models;

namespace Ricardo.UseCases
{
	public class CreateOrderItemUseCase
	{
		public static OrderItem Create(Item item, int quantity)
		{
			return new OrderItem(item, quantity);
		}

	}
}
