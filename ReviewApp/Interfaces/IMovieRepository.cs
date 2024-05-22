using ReviewApp.Models;

namespace ReviewApp.Interfaces;

public interface IMovieRepository
{
    IEnumerable<Movie> GetMovies();
    Movie GetMovie(int id);
    Movie GetMovie(string title);
    Movie CreateMovie(Movie movie);
    bool MovieExists(int id);
    string GetMovieDirector(int id);
}