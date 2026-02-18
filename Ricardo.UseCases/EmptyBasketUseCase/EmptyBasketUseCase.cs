using Ricardo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.UseCases.EmptyBasketUseCase
{
    public class EmptyBasketUseCase
    {
        public void EmptyBasket(Basket basket)
        {
            basket.Items.Clear();
        }
    }
}
