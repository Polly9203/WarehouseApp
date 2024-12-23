using Microsoft.EntityFrameworkCore;
using WarehouseApp.WarehouseApp.Domain.Entities;
using WarehouseApp.WarehouseApp.Infrastructure.Contexts;

namespace WarehouseApp.WarehouseApp.Infrastructure.Repositories.Warehouses
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly Contexts.AppContext _context;

        public WarehouseRepository(Contexts.AppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses.AsNoTracking().ToListAsync();
        }

        public async Task<Warehouse> AddAsync(Warehouse warehouse)
        {
            await _context.Warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();

            return warehouse;
        }

        public async Task UpdateAsync(Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);
            await _context.SaveChangesAsync();
        }
    }
}
