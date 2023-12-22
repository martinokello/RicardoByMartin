using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.Models
{
    public class Order
    {
        private OrderItem[] orderItems;
        public int Total { get; private set; }
        public Order(OrderItem[] orderItems)
        {
            this.orderItems = orderItems;
            Total = orderItems.Sum(p => p.Total);
        }
    }
}
