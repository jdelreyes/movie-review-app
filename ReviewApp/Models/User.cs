using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public ICollection<Review> Reviews { get; set; }
}