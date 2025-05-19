using Restaurant.Database.Models;
using Restaurant.Database.ViewModels;

namespace Restaurant.Database.Interfaces;

public interface IChefRepository
{
    public List<Chef> GetAll();
    public List<Chef> GetSome(int value);
    public Chef GetById(int id);
    public void Insert(CreateChefViewModel model);
    public void Update(int id, UpdateChefViewModel model);
    public void Delete(int id);
}
