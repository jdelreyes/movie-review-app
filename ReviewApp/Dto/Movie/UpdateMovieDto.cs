namespace ReviewApp.Dto;

public class UpdateMovieDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; }
    public string Genre { get; set; }
    public string Director { get; set; }
}