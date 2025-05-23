using Microsoft.AspNetCore.Mvc;
using Restaurant.Database.Interfaces;
using Restaurant.Database.Repositories;
using Restaurant.Database.ViewModels.Account;

namespace Restaurant.Controllers;

public class AccountController : Controller
{
    private readonly IUserRepository _userRepository;
    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
        await _userRepository.Register(model);
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
        await _userRepository.Login(model);
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _userRepository.LogOut();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> CreateRole()
    {
        await _userRepository.CreateRole();
        return RedirectToAction("Index", "Home");
    }
}
