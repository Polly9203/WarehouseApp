using Microsoft.EntityFrameworkCore;
using WarehouseApp.WarehouseApp.Application.Helpers;
using WarehouseApp.WarehouseApp.Application.Services.Items;
using WarehouseApp.WarehouseApp.Application.Services.Warehouses;
using WarehouseApp.WarehouseApp.Infrastructure.Contexts;
using WarehouseApp.WarehouseApp.Infrastructure.Repositories.Items;
using WarehouseApp.WarehouseApp.Infrastructure.Repositories.Warehouses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<WarehouseApp.WarehouseApp.Infrastructure.Contexts.AppContext>(options =>
    options.UseInMemoryDatabase("WarehouseDb"));

builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var warehouseService = scope.ServiceProvider.GetRequiredService<IWarehouseService>();
    var itemService = scope.ServiceProvider.GetRequiredService<IItemService>();

    await InitialDataHelper.SeedData(warehouseService, itemService);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await app.RunAsync();
