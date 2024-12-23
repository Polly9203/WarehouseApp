using WarehouseApp.WarehouseApp.Domain.Entities;

namespace WarehouseApp.WarehouseApp.Infrastructure.Repositories.Warehouses
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task<Warehouse> AddAsync(Warehouse warehouse);
        Task UpdateAsync(Warehouse warehouse);
    }
}
