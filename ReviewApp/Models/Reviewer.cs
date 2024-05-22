using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models;

public class Reviewer
{
    [Key] public int Id { get; set; }
    [Required] public string UserName { get; set; }
    [Required] public IEnumerable<Review> Reviews { get; set; }
}