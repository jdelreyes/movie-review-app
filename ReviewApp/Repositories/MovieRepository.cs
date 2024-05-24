using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Data;
using ReviewApp.Dto;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public MovieRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<MovieDto> GetMovies()
    {
        return _mapper.Map<IEnumerable<MovieDto>>(_context.Movies.ToList());
    }

    public MovieDetailsDto GetMovie(int id)
    {
        return _mapper.Map<MovieDetailsDto>(_context.Movies.Where(m => m.Id == id).FirstOrDefault());
    }

    public MovieDetailsDto GetMovie(string title)
    {
        return _mapper.Map<MovieDetailsDto>(_context.Movies.Where(m => m.Title == title).FirstOrDefault());
    }

    public MovieDetailsDto CreateMovie(CreateMovieDto createMovieDto)
    {
        // todo: finish the method 
        Movie movie = new Movie()
        {
            Description = createMovieDto.Description,
            Director = createMovieDto.Director,
            Genre = createMovieDto.Genre,
            Title = createMovieDto.Title
        };

        _context.Add(movie);
        _context.SaveChanges();

        return _mapper.Map<MovieDetailsDto>(movie);
    }

    public MovieDetailsDto UpdateMovie(int id, UpdateMovieDto updateMovieDto)
    {
        Movie movie = _context.Movies.Where(m => m.Id == id).FirstOrDefault();

        Movie updatedMovie = new Movie()
        {
            Id = movie.Id,
            Description = updateMovieDto.Description,
            Director = updateMovieDto.Director,
            Genre = updateMovieDto.Genre,
            Title = updateMovieDto.Title
        };

        _context.Add(updatedMovie);
        _context.SaveChanges();

        return _mapper.Map<MovieDetailsDto>(updatedMovie);
    }

    public MovieDetailsDto DeleteMovie(int id)
    {
        Movie movie = _context.Movies.Where(m => m.Id == id).FirstOrDefault();

        _context.Remove(movie);
        _context.SaveChanges();

        return _mapper.Map<MovieDetailsDto>(movie);
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