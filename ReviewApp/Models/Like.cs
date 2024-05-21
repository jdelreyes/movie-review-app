using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models;

public class Like
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int ReviewId { get; set; }
    public Review Review { get; set; }
}