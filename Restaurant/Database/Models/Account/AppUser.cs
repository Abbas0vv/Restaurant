using Microsoft.AspNetCore.Identity;

namespace Restaurant.Database.Models.Account;

public class AppUser : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
