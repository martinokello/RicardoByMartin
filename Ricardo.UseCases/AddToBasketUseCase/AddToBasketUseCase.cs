using Ricardo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.UseCases
{
    public class AddToBasketUseCase
    {
        public void AddToBasket(Basket basket,OrderItem orderItem)
        {
            var existing = basket.Items.SingleOrDefault(i => i.Item.Id == orderItem.Item.Id);
            if (existing == default)
                basket.Items.Add(orderItem);
            else
                basket.AddMore(orderItem,orderItem.Quantity);
        }
    }
}
