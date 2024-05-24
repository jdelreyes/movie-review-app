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
    private readonly IMapper _mapper;

    public MovieController(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<MovieDto>))]
    public IActionResult GetMovies()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(_mapper.Map<List<MovieDto>>(_movieRepository.GetMovies()));
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
    public IActionResult CreateMovie([FromBody] CreateMovieDto createMovieDto)
    {
        Movie createdMovie = _movieRepository.CreateMovie(createMovieDto);
        return Created("api/movies/" + createdMovie.Id, createdMovie);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MovieDto))]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto updateMovieDto)
    {
        throw new NotImplementedException();
    }
    
    
}