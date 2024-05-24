using System.Net;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Controllers;

[ApiController]
[Route("/api/reviews")]
public class ReviewController: ControllerBase
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewController(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Review>))]
    public IActionResult GetReviews()
    {
        return Ok(_reviewRepository.GetReviews());
    }
}