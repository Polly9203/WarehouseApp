using WarehouseApp.WarehouseApp.Application.DTOs;

namespace WarehouseApp.WarehouseApp.Application.Services.Warehouses
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllAsync();
        Task<WarehouseDto> AddAsync(WarehouseDto warehouse);
        Task<IEnumerable<WarehouseDto>> GetAllWarehousesWithItemsAsync();
    }
}
