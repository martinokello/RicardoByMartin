namespace Ricardo.Models
{
    public class Item : Product
    {
        public int Price { get; set; }
        public int InventoryQuantity { get; set; } = 0;
    }
}
