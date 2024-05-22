using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models;

public class Review
{
    [Key] public int Id { get; set; }
    [Required] public string Content { get; set; }
    public Movie Movie { get; set; }
    public Reviewer Reviewer { get; set; }
}