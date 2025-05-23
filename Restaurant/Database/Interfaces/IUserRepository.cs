using Restaurant.Database.ViewModels.Account;

namespace Restaurant.Database.Interfaces;

public interface IUserRepository
{
    Task Register(RegisterViewModel model);
    Task Login(LoginViewModel model);
    Task LogOut();
    Task CreateRole();
}
