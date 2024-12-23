using WarehouseApp.WarehouseApp.Domain.Entities;

namespace WarehouseApp.WarehouseApp.Infrastructure.Repositories.Items
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item?> GetByIdAsync(int id);
        Task AddAsync(Item item);
        Task UpdateAsync(Item item);
        Task<IEnumerable<Item>> GetItemsByWarehouseIdAsync(int warehouseId);
    }
}
