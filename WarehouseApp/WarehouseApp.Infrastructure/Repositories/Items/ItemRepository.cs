using Microsoft.EntityFrameworkCore;
using WarehouseApp.WarehouseApp.Domain.Entities;
using WarehouseApp.WarehouseApp.Infrastructure.Contexts;

namespace WarehouseApp.WarehouseApp.Infrastructure.Repositories.Items
{
    public class ItemRepository : IItemRepository
    {
        private readonly Contexts.AppContext _context;

        public ItemRepository(Contexts.AppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.AsNoTracking().ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Item item)
        {
            var existingItem = _context.Items.Local.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                _context.Entry(existingItem).State = EntityState.Detached;
            }

            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsByWarehouseIdAsync(int warehouseId)
        {
            return await _context.Items
                .Where(i => i.WarehouseId == warehouseId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
