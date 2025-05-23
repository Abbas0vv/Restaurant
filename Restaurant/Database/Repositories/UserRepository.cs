using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Database.Interfaces;
using Restaurant.Database.Models.Account;
using Restaurant.Database.ViewModels.Account;
using Restaurant.Helpers.Enums;

namespace Restaurant.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task Register(RegisterViewModel model)
    {
        var count = await _userManager.Users.CountAsync();

        var user = new AppUser()
        {
            Name = model.Name,
            Surname = model.Surname,
            UserName = model.Username,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            if (count == 0)
                await _userManager.AddToRoleAsync(user, Role.Admin.ToString());
            else
                await _userManager.AddToRoleAsync(user, Role.User.ToString());

            await _signInManager.SignInAsync(user, true);
        }
    }

    public async Task Login(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.UsernameOrEmail) ?? await _userManager.FindByNameAsync(model.UsernameOrEmail);

        if (user is not null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
            }
        }
    }

    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task CreateRole()
    {
        foreach (var item in Enum.GetValues(typeof(Role)))
        {
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = item.ToString()
            });
        }
    }
}
