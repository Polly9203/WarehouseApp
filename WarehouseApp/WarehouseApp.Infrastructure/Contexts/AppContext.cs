using Microsoft.EntityFrameworkCore;
using WarehouseApp.WarehouseApp.Domain.Entities;

namespace WarehouseApp.WarehouseApp.Infrastructure.Contexts
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}