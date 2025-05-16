using Restaurant.Database.ViewModels.Account;

namespace Restaurant.Database.Interfaces;

public interface ILoginRegisterRepository
{
    public async Task<bool> SignUp(RegisterViewModel model)
    {
        return false;
    }
    public async Task SignIn(LoginViewModel model)
    {
        return;
    }
    public async Task LogOut()
    {
        return;
    }
}
