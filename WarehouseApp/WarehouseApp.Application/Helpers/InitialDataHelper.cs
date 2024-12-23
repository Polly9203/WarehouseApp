using WarehouseApp.WarehouseApp.Application.DTOs;
using WarehouseApp.WarehouseApp.Application.Services.Items;
using WarehouseApp.WarehouseApp.Application.Services.Warehouses;

namespace WarehouseApp.WarehouseApp.Application.Helpers
{
    public static class InitialDataHelper
    {
        public static async Task SeedData(IWarehouseService warehouseService, IItemService itemService)
        {
            var warehouses = await warehouseService.GetAllAsync();

            if (!warehouses.Any())
            {
                var warehouse = new WarehouseDto
                {
                    Name = "Default Warehouse",
                    Address = "123 Warehouse St"
                };

                var savedWarehouse = await warehouseService.AddAsync(warehouse);

                for (int i = 1; i <= 5; i++)
                {
                    var item = new ItemDto
                    {
                        WarehouseId = savedWarehouse.Id,
                        Name = $"Item {i}",
                        Quantity = 1
                    };

                    await itemService.AddAsync(item);
                }
            }
        }
    }
}
