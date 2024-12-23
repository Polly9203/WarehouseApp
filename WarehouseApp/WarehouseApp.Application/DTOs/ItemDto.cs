namespace WarehouseApp.WarehouseApp.Application.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int WarehouseId { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
