
using Ricardo.Models;
using Ricardo.Plugins.Inventory;
using Ricardo.Plugins.Inventory.Interfaces;

namespace Ricardo.UseCases.RecordStocksNotSoldAnymoreUseCase
{
    public class RecordStockNotSoldAnymoreUseCase
    {
       public bool IsOutOfStock(OrderItem itemOrder)
       {
            return Inventory.IsOutOfStock(itemOrder);
       }
    }
}
