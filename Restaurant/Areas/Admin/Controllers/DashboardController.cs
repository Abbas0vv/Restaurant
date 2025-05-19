using Microsoft.AspNetCore.Mvc;
using Restaurant.Database.Interfaces;
using Restaurant.Database.Repositories;
using Restaurant.Database.ViewModels;

namespace Restaurant.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly IChefRepository _chefRepository;

    public DashboardController(IChefRepository chefRepository)
    {
        _chefRepository = chefRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var chefs = _chefRepository.GetAll();
        return View(chefs);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateChefViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        _chefRepository.Insert(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var chef = _chefRepository.GetById(id);
        var viewModel = new UpdateChefViewModel()
        {
            Name = chef.Name,
            Surname = chef.Surname,
            Designation = chef.Designation,
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Update(int id, UpdateChefViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        _chefRepository.Update(id, model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _chefRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
