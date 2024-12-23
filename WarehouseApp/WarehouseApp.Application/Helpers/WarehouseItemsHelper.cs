using WarehouseApp.WarehouseApp.Application.DTOs;

namespace WarehouseApp.WarehouseApp.Application.Helpers
{
    public static class WarehouseItemsHelper
    {
        public static List<WarehouseDto> GetWarehousesWithItems(List<WarehouseDto> warehouses, List<ItemDto> items)
        {
            foreach (var warehouse in warehouses)
            {
                var warehouseItems = items.Where(item => item.WarehouseId == warehouse.Id).ToList();
                warehouse.Items = warehouseItems;
            }

            return warehouses;
        }
    }
}
