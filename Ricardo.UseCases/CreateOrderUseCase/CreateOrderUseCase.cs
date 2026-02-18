using Ricardo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.UseCases
{
    public class CreateOrderUseCase
    {
        public static Order CreateOrder(Basket basket)
        {
            return new Order(basket.Items.ToArray());
        }
    }

}
