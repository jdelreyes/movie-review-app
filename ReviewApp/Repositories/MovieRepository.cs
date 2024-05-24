using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Data;
using ReviewApp.Dto;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repositories;

public class MovieRepository : IMovieRepository
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public MovieRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

    public Movie CreateMovie(CreateMovieDto createMovieDto)
    {
        // todo: finish the method 
        Movie movie = new Movie()
        {
            Desription = createMovieDto.Desription,
            Director = createMovieDto.Director,
            Genre = createMovieDto.Director,
            Title = createMovieDto.Title
        };

        _context.Add(movie);
        _context.SaveChanges();

        return movie;
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