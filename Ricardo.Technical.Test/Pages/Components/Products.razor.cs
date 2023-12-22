using Microsoft.AspNetCore.Components;
using Ricardo.Models;
using Ricardo.UseCases;

namespace Ricardo.Technical.Test.Pages.Components
{
    public partial class Products
    {
        [Parameter] public IEnumerable<Item> Goods { get; set; } = default!;
        [CascadingParameter] protected Basket Basket { get; set; } = default!;
        protected AddToBasketUseCase AddToBasketUseCase { get; set; }=new AddToBasketUseCase();
        [Parameter] public EventCallback<Item> OnItemAdded { get; set; } = default!;

        public void AddToBasket(OrderItem orderItem)
        {
            AddToBasketUseCase.AddToBasket(Basket,orderItem);
	        OnItemAdded.InvokeAsync(orderItem.Item);
        }
    }
}
