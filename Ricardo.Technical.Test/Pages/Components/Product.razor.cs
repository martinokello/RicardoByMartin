using Microsoft.AspNetCore.Components;
using Ricardo.Models;
using Ricardo.UseCases;

namespace Ricardo.Technical.Test.Pages.Components
{
	public partial class Product
	{
		private int _quantity = 1;
		protected CreateOrderItemUseCase CreateOrderItemUseCase { get; set; }= new CreateOrderItemUseCase();
        [Parameter] public Item Item { get; set; } = default!;
		[Parameter] public EventCallback<OrderItem> OnItemAdded { get; set; }

		private void AddToBasket()
		{
			if (_quantity <= 0) return;
			OnItemAdded.InvokeAsync(CreateOrderItemUseCase.Create(Item, _quantity));
		}
	}
}
