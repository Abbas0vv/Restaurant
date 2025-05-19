using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Database.ViewModels;

public class UpdateChefViewModel
{
    [MinLength(3)]
    public string Name { get; set; }
    [MinLength(3)]
    public string Surname { get; set; }
    [MinLength(5)]
    public string Designation { get; set; }
    [NotMapped]
    public IFormFile? File { get; set; }
}