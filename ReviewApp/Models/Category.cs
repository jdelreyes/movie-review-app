using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}