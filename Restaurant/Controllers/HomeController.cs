using Microsoft.AspNetCore.Mvc;
using Restaurant.Database.Interfaces;
using Restaurant.Database.Repositories;

namespace Restaurant.Controllers;

public class HomeController : Controller
{
    private readonly IChefRepository _chefRepository;

    public HomeController(IChefRepository chefRepository)
    {
        _chefRepository = chefRepository;
    }

    public IActionResult Index()
    {
        var chefs = _chefRepository.GetSome(4);
        return View(chefs);
    }
}
