using WarehouseApp.WarehouseApp.Application.DTOs;
using WarehouseApp.WarehouseApp.Domain.Entities;

namespace WarehouseApp.WarehouseApp.Application.Mappers
{
    public class WarehouseMapper
    {
        #region Warehouse
        public Warehouse MapWarehouseDto(WarehouseDto warehouse)
        {
            return new Warehouse
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                Address = warehouse.Address,
            };
        }
        public WarehouseDto MapToWarehouseDto(Warehouse warehouse)
        {
            return new WarehouseDto
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                Address = warehouse.Address,
            };
        }
        #endregion

        #region Item
        public Item MapItemDto(ItemDto item)
        {
            return new Item
            {
                Id = item.Id,
                Name = item.Name,
                WarehouseId = item.WarehouseId,
                Quantity = item.Quantity
            };
        }
        public ItemDto MapToItemDto(Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                WarehouseId = item.WarehouseId,
                Quantity = item.Quantity
            };
        }
        #endregion
    }
}
