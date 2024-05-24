using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Dto;

public class CreateMovieDto
{
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; }
    public string Genre { get; set; }
    public string Director { get; set; }
}