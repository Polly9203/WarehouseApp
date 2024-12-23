using WarehouseApp.WarehouseApp.Application.DTOs;
using WarehouseApp.WarehouseApp.Application.Mappers;
using WarehouseApp.WarehouseApp.Infrastructure.Repositories.Items;

namespace WarehouseApp.WarehouseApp.Application.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly WarehouseMapper _mapper;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            _mapper = new WarehouseMapper();
        }

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = await _itemRepository.GetAllAsync();

            var mappedItems = new List<ItemDto>();
            foreach (var item in items)
            {
                mappedItems.Add(_mapper.MapToItemDto(item));
            }

            return mappedItems;
        }

        public async Task AddAsync(ItemDto item)
        {
            await _itemRepository.AddAsync(_mapper.MapItemDto(item));
        }

        public async Task<ItemDto> GetByIdAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            if (item is not null)
            {
                return _mapper.MapToItemDto(item);
            }

            return new ItemDto();
        }

        public async Task UpdateAsync(ItemDto item)
        {
            await _itemRepository.UpdateAsync(_mapper.MapItemDto(item));
        }

        public async Task<IEnumerable<ItemDto>> GetItemsByWarehouseIdAsync(int warehouseId)
        {
            var items = await _itemRepository.GetItemsByWarehouseIdAsync(warehouseId);

            var savedItems = new List<ItemDto>();
            foreach (var item in items)
            {
                savedItems.Add(_mapper.MapToItemDto(item));
            }
            return savedItems;
        }
    }
}
