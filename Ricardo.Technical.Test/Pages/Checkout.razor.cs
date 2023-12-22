using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Ricardo.Models;
using Ricardo.Plugins.Utility;
using Ricardo.Technical.Test.Utility;
using Ricardo.UseCases;
using Ricardo.UseCases.EmptyBasketUseCase;

namespace Ricardo.Technical.Test.Pages
{
	public partial class Checkout
	{
		[Inject]
		private ILocalStorageService localStorage { get; set; } = default!;
		[Inject] private Navigation NavManager { get; set; } = default!;
		[Inject] private SessionManager SessionManager { get; set; } = default!;
		[CascadingParameter] private Basket Basket { get; set; } = default!;
		protected CreateOrderUseCase CreateOrderUseCase { get; set; } = new CreateOrderUseCase();

		protected EmptyBasketUseCase EmptyBasketUseCase { get; set; } = new EmptyBasketUseCase();
        public async Task PlaceOrder()
		{
			var customer = SessionManager.Customer;
			if (customer == default!)
			{
				NavManager.NavigateTo("/signin");
				return;
			}
			try
			{
				var customerShoppingHistory =
				await localStorage.GetItemAsync<List<OrderItem>>($"Customer_{customer.Username}")??new List<OrderItem>();
				var order = CreateOrderUseCase.CreateOrder(Basket);
				OrderItemsUseCase orderItemUseCase = new OrderItemsUseCase(customer, Basket.Items.ToArray(), customerShoppingHistory);

				customer.Pay(order);
				await localStorage.SetItemAsync<List<OrderItem>>($"Customer_{customer.Username}",customerShoppingHistory);
				NavManager.NavigateTo("/orderConfirmed");
			}
			catch (Exception ex)
			{
				//Log Exception
			}
			finally
			{
                EmptyBasketUseCase.EmptyBasket(Basket);
                NavManager.NavigateTo("/");
            }
		
		}

	}
}
