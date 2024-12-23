namespace WarehouseApp.WarehouseApp.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int WarehouseId { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
