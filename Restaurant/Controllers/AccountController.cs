using Microsoft.AspNetCore.Mvc;
using Restaurant.Database.Interfaces;
using Restaurant.Database.Repositories;
using Restaurant.Database.ViewModels.Account;

namespace Restaurant.Controllers;

public class AccountController : Controller
{
    private readonly ILoginRegisterRepository _registerLoginRepository;

    public AccountController(ILoginRegisterRepository registerLoginRepository)
    {
        _registerLoginRepository = registerLoginRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        await _registerLoginRepository.SignUp(model);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        await _registerLoginRepository.SignIn(model);
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _registerLoginRepository.LogOut();
        return RedirectToAction("Index", "Home");
    }
}
