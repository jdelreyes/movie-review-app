using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models;

public class Review
{
    [Key] public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int ReviewerId { get; set; }
    public User Reviewer { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
}