using WarehouseApp.WarehouseApp.Application.DTOs;
using WarehouseApp.WarehouseApp.Application.Helpers;
using WarehouseApp.WarehouseApp.Application.Mappers;
using WarehouseApp.WarehouseApp.Application.Services.Items;
using WarehouseApp.WarehouseApp.Infrastructure.Repositories.Warehouses;

namespace WarehouseApp.WarehouseApp.Application.Services.Warehouses
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IItemService _itemService;
        private readonly WarehouseMapper _mapper;

        public WarehouseService(IWarehouseRepository warehouseRepository, IItemService itemRepository)
        {
            _warehouseRepository = warehouseRepository;
            _itemService = itemRepository;

            _mapper = new WarehouseMapper();
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllAsync()
        {
            var warehouses = await _warehouseRepository.GetAllAsync();

            var mappedWarehouses = new List<WarehouseDto>();
            foreach (var warehouse in warehouses)
            {
                mappedWarehouses.Add(_mapper.MapToWarehouseDto(warehouse));
            }

            return mappedWarehouses;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllWarehousesWithItemsAsync()
        {
            var warehouses = await GetAllAsync();
            var items = await _itemService.GetAllAsync();

            return WarehouseItemsHelper.GetWarehousesWithItems(warehouses.ToList(), items.ToList());
        }

        public async Task<WarehouseDto> AddAsync(WarehouseDto warehouse)
        {
            var mappedWarehouse = _mapper.MapWarehouseDto(warehouse);
            var savedWarehouse = await _warehouseRepository.AddAsync(mappedWarehouse);

            return _mapper.MapToWarehouseDto(savedWarehouse);
        }
    }
}
