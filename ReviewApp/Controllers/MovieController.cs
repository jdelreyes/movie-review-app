using System.Net;
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
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Movie>))]
    public IActionResult GetMovies()
    {
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
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(MovieDto))]
    public IActionResult CreateMovie([FromBody] Movie movie)
    {
        Movie createdMovie = _movieRepository.CreateMovie(movie);
        return Created("api/movies/" + createdMovie.Id, createdMovie);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MovieDto))]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto updateMovieDto)
    {
        throw new NotImplementedException();
    }
}