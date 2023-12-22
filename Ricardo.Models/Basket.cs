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
        public void AddMore(OrderItem orderItem, int quantity)
        {
            if (quantity > 0)
                orderItem.Quantity += quantity;
        }
    }
}
