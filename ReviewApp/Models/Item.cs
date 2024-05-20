namespace ReviewApp.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; set; }
    public ICollection<Review> Reviews { get; set; }
}