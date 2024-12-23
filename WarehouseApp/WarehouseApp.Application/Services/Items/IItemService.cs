using WarehouseApp.WarehouseApp.Application.DTOs;

namespace WarehouseApp.WarehouseApp.Application.Services.Items
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();
        Task<ItemDto> GetByIdAsync(int id);
        Task AddAsync(ItemDto item);
        Task UpdateAsync(ItemDto item);
        Task<IEnumerable<ItemDto>> GetItemsByWarehouseIdAsync(int warehouseId);
    }
}
