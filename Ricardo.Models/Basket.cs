using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public delegate void BasketChanged(Ricardo.Models.Basket basket);
        public void AddMore(OrderItem orderItem, int quantity)
        {
            if (quantity > 0)
                orderItem.Quantity += quantity;
        }
        public static event BasketChanged OnBasketChanged;

        public static void RaiseBasketChanged(Ricardo.Models.Basket basket)
        {
            if (OnBasketChanged != null)
            {
                OnBasketChanged.Invoke(basket);
            }
        }
    }
}
