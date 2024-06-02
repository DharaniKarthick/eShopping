using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using eShopping.Data;
using eShopping.Models;
using eShopping.Work.Managers;
using eShopping.Work.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepositoryImpl>();

            builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();
            builder.Services.AddTransient<IProductRepository, ProductRepositoryImpl>();

            builder.Services.AddScoped<IOrderRepository, OrderRepositoryImpl>();
            builder.Services.AddTransient<IOrderRepository, OrderRepositoryImpl>();

            builder.Services.AddScoped<CategoryManager>();
            builder.Services.AddScoped<ProductManager>();
            builder.Services.AddScoped<ShoppingCart>();
            builder.Services.AddScoped<OrderManager>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
