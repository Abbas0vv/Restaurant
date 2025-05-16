using Restaurant.Database.Interfaces;
using Restaurant.Database.Models;
using Restaurant.Database.ViewModels;
using Restaurant.Helpers.Extentions;

namespace Restaurant.Database.Repositories;

public class ChefRepository : IChefRepository
{
    private readonly RestaurantDbContext _context;
    private readonly IWebHostEnvironment _environment;
    private const string FOLDER_NAME = "uploads/chefs";

    public ChefRepository(RestaurantDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public List<Chef> GetAll()
    {
        return _context.Chefs.OrderBy(c => c.Id).ToList();
    }
    public List<Chef> GetSome(int value)
    {
        if (GetAll().Count < value) return GetAll();
        return _context.Chefs.OrderBy(c => c.Id).Take(value).ToList();
    }

    public Chef GetById(int id)
    {
        return _context.Chefs.FirstOrDefault(c => c.Id == id);
    }

    public void Insert(ChefViewModel model)
    {
        var chef = new Chef()
        {
            Name = model.Name,
            Surname = model.Surname,
            Designation = model.Designation,
            ImageUrl = model.File.CreateFile(_environment.WebRootPath, FOLDER_NAME)
        };

        _context.Chefs.Add(chef);
        _context.SaveChanges();
    }

    public void Update(int id, ChefViewModel model)
    {
        var chef = GetById(id);
        if (chef is null) return;

        chef.Name = model.Name;
        chef.Surname = model.Surname;
        chef.Designation = model.Designation;


        if (model.File is not null)
            chef.ImageUrl = model.File.UpdateFile(_environment.WebRootPath, FOLDER_NAME, chef.ImageUrl);

        _context.Update(chef);
        _context.SaveChanges();
    }
    public void Delete(int id)
    {
        var chef = GetById(id);
        if (chef is null) return;

        FileExtention.RemoveFile(_environment.WebRootPath, FOLDER_NAME, chef.ImageUrl);
        _context.Chefs.Remove(chef);
        _context.SaveChanges();
    }
}
