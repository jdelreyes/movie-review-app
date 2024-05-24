using ReviewApp.Dto;
using ReviewApp.Models;

namespace ReviewApp.Interfaces;

public interface IMovieRepository
{
    IEnumerable<MovieDto> GetMovies();
    MovieDetailsDto GetMovie(int id);
    MovieDetailsDto GetMovie(string title);
    MovieDetailsDto CreateMovie(CreateMovieDto createMovieDto);
    MovieDetailsDto UpdateMovie(int id, UpdateMovieDto updateMovieDto);
    MovieDetailsDto DeleteMovie(int id);
    bool MovieExists(int id);
    string GetMovieDirector(int id);
}