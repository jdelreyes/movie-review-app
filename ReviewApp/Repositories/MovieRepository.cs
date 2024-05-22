using Microsoft.AspNetCore.Mvc;
using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repositories;

public class MovieRepository : IMovieRepository
{
    private DataContext _context;

    public MovieRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Movie> GetMovies()
    {
        return _context.Movies.ToList();
    }

    public Movie GetMovie(int id)
    {
        return _context.Movies.Where(m => m.Id == id).FirstOrDefault();
    }

    public Movie GetMovie(string title)
    {
        return _context.Movies.Where(m => m.Title == title).FirstOrDefault();
    }

    public Movie CreateMovie(Movie movie)
    {
        return _context.Movies.Add(movie).Entity;
    }

    public bool MovieExists(int id)
    {
        return _context.Movies.Any(movie => movie.Id == id);
    }

    public string GetMovieDirector(int id)
    {
        return _context.Movies.Where(movie => movie.Id == id).FirstOrDefault().Director;
    }
}