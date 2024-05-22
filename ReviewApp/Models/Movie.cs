using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Models;

public class Movie
{
    [Key] public int Id { get; set; }
    [Required] public string Title { get; set; }
    [Required] public string Desription { get; set; }
    public DateTime ReleaseDate { get; }
    public string Genre { get; set; }
    public string Director { get; set; }

    public Movie()
    {
        this.ReleaseDate = DateTime.Now;
    }
}