using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExamenEasyShop.Data;
using ExamenEasyShop.Configuration;
using ExamenEasyShop.CommandHandler;
using ExamenEasyShop.Commands;
using ExamenEasyShop.QueryHandler;
using ExamenEasyShop.DTOs;
using ExamenEasyShop.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ExamenEasyShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExamenEasyShopContext") ?? throw new InvalidOperationException("Connection string 'ExamenEasyShopContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommandHandler<Product>, UpdateProductCommandHandler>();
builder.Services.AddScoped<ICommandHandler<ProductDTO>, AddProductCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RemoveByIdCommand>, RemoveProductCommandHandler>();
builder.Services.AddScoped<IQueryHandler<Product, QueryByIdCommand>, ProductQueryHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
