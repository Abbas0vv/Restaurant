using System.ComponentModel.DataAnnotations;

namespace Restaurant.Database.ViewModels.Account;

public class LoginViewModel
{
    [Required]
    public string UsernameOrEmail { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
