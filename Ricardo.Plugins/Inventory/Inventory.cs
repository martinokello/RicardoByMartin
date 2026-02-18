using Ricardo.Models;
using Ricardo.Plugins.Inventory.Interfaces;
using Ricardo.Technical.Test.Errors;

namespace Ricardo.Plugins.Inventory
{
    public class Inventory: IInventoryServices
    {
        public static  List<Item> Goods { get; set; } = new List<Item>();

        public Inventory()
        {
            if (Goods.Count > 0) return;

            //Data seeding
            Goods.Add(new Item { Id = 1, Name = "Dice Set", Image = "images/Dice set.webp", Price = 50, InventoryQuantity = 2 });
            Goods.Add(new Item { Id = 2, Name = "Dungeon Tiles", Image = "images/Dungeon tiles.jpg", Price = 100, InventoryQuantity = 2 });
            Goods.Add(new Item { Id = 3, Name = "Dice Tower", Image = "images/Dice tower.jpg", Price = 200, InventoryQuantity = 2 });
        }

        public IEnumerable<Item> AllStock()
        {
	        return Goods;
        }

        public static bool IsOutOfStock(OrderItem orderItem)
        {
            var item = Goods.FirstOrDefault(it =>  it.Id == orderItem.Item.Id);
            if (item?.InventoryQuantity == 0 || item?.InventoryQuantity < orderItem.Quantity)
            {
                return true;
            }
            return false;
        }
    }
}
