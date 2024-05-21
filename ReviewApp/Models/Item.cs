using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models;

public class Item
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public ICollection<Review> Reviews;
}