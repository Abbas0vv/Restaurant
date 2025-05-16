namespace Restaurant.Database.Models;

public class Chef : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Designation { get; set; }
    public string ImageUrl { get; set; }
}
