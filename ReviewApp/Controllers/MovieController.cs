using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Dto;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Controllers;

[ApiController]
[Route("/api/movies")]
public class MovieController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;

    public MovieController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<MovieDto>))]
    public IActionResult GetMovies()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(_movieRepository.GetMovies());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MovieDetailsDto))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public IActionResult GetMovie(int id)
    {
        if (!_movieRepository.MovieExists(id))
            return NotFound();

        var movie = _movieRepository.GetMovie(id);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(movie);
    }

    [HttpGet("title/{title}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MovieDetailsDto))]
    public IActionResult GetMovie(string title)
    {
        var movie = _movieRepository.GetMovie(title);

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(movie);
    }

    [HttpPost] // todo: finish
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(MovieDetailsDto))]
    public IActionResult CreateMovie([FromBody] CreateMovieDto createMovieDto)
    {
        MovieDetailsDto createdMovie = _movieRepository.CreateMovie(createMovieDto);
        return Created("/api/movies/" + createdMovie.Id, createdMovie);
    }

    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MovieDetailsDto))]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto updateMovieDto)
    {
        MovieDetailsDto movieDetailsDto = _movieRepository.UpdateMovie(id, updateMovieDto);
        return Ok(movieDetailsDto);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public IActionResult DeleteMovie(int id)
    {
        _movieRepository.DeleteMovie(id);
        return NoContent();
    }
}