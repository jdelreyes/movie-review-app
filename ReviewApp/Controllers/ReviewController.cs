using System.Net;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Dto.Review;
using ReviewApp.Interfaces;

namespace ReviewApp.Controllers;

[ApiController]
[Route("/api/reviews")]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewController(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ReviewDto>))]
    public IActionResult GetReviews()
    {
        return Ok(_reviewRepository.GetReviews());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ReviewDto))]
    public IActionResult GetReview(int id)
    {
        return Ok(_reviewRepository.GetReview(id));
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ReviewDto))]
    public IActionResult CreateReview([FromBody] CreateReviewDto createReviewDto)
    {
        ReviewDto reviewDto = _reviewRepository.CreateReview(createReviewDto);

        return Created("/api/reviews/" + reviewDto.Id, reviewDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ReviewDto))]
    public IActionResult UpdateReview(int id, [FromBody] UpdateReviewDto updateReviewDto)
    {
        return Ok(_reviewRepository.UpdateReview(id, updateReviewDto));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public IActionResult DeleteReview(int id)
    {
        _reviewRepository.DeleteReview(id);
        return NoContent();
    }
}