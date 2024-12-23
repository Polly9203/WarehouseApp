namespace WarehouseApp.WarehouseApp.Application.DTOs
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public List<ItemDto> Items { get; set; } = new();
    }
}
