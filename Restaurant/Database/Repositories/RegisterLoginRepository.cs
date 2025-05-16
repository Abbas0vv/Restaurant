using Microsoft.AspNetCore.Identity;
using Restaurant.Database.Interfaces;
using Restaurant.Database.Models.Account;
using Restaurant.Database.ViewModels.Account;

namespace Restaurant.Database.Repositories;

public class RegisterLoginRepository : ILoginRegisterRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public RegisterLoginRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> SignUp(RegisterViewModel model)
    {
        var user = new AppUser()
        {
            Name = model.Name,
            Surname = model.Surname,
            UserName = model.Username,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        return result.Succeeded;
    }

    public async Task SignIn(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.UsernameOrEmail) ?? await _userManager.FindByNameAsync(model.UsernameOrEmail);

       var result= await _signInManager.CheckPasswordSignInAsync(user, model.Password,false);
        if(result.Succeeded)
        {
            await _signInManager.SignInAsync(user, true);
        }
    }

    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }
}
