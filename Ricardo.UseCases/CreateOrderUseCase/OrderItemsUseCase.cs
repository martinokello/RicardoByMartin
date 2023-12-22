using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Ricardo.Models;
using Ricardo.Plugins.Inventory;
using Ricardo.Technical.Test.Errors;
using ILocalStorageService = Blazored.LocalStorage.ILocalStorageService;

namespace Ricardo.UseCases
{
	public class OrderItemsUseCase
    {
		[Inject]
		private ILocalStorageService storage { get; set; }
		private readonly List<OrderItem> _items = new();
		public int Total { get; }
        public OrderItemsUseCase(Customer customer,OrderItem[] items, List<OrderItem> customerShopHistory)
        {

			if (CheckItemsAreInStock(items))
            {
                Inventory.Goods.ForEach(it =>
                {
                    foreach (var oit in items)
                    {
                        if (it.Id == oit.Item.Id)
                        {
                            it.InventoryQuantity -= oit.Quantity;
                            break;
                        }
                    }
                });
                Total = items.Sum(p => p.Total);
                _items.AddRange(items);
			}

            customerShopHistory.AddRange(items);

		}

        public bool CheckItemsAreInStock(OrderItem[] items)
        {
            foreach (var item in items)
            {
                if (Inventory.IsOutOfStock(item))
                {
                    throw new InventoryFullfillmentException($"Item {item.Item.Name} is out of Stock");
                }
            }
            return true;
        }
    }
}
