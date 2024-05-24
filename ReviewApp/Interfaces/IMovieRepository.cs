using ReviewApp.Dto;
using ReviewApp.Models;

namespace ReviewApp.Interfaces;

public interface IMovieRepository
{
    IEnumerable<Movie> GetMovies();
    Movie GetMovie(int id);
    Movie GetMovie(string title);
    Movie CreateMovie(CreateMovieDto createMovieDto);
    bool MovieExists(int id);
    string GetMovieDirector(int id);
}