using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Database;
using Restaurant.Database.Interfaces;
using Restaurant.Database.Models.Account;
using Restaurant.Database.Repositories;

namespace Restaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<RestaurantDbContext>(opt =>
                opt.UseSqlServer(connectionString));


            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<RestaurantDbContext>().AddDefaultTokenProviders();

            builder.Services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            builder.Services.AddRazorPages();


            builder.Services.AddScoped<IChefRepository,ChefRepository>();
            builder.Services.AddScoped<ILoginRegisterRepository, RegisterLoginRepository>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
