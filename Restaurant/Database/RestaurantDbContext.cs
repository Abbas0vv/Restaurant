using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Database.Models;
using Restaurant.Database.Models.Account;

namespace Restaurant.Database;

public class RestaurantDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    public RestaurantDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Chef> Chefs { get; set; }
}
