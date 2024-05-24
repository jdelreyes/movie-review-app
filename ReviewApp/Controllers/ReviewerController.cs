using System.Net;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Dto.Reviewer;
using ReviewApp.Interfaces;

namespace ReviewApp.Controllers;

[ApiController]
[Route("/api/reviewers")]
public class ReviewerController : ControllerBase
{
    private readonly IReviewerRepository _reviewerRepository;

    public ReviewerController(IReviewerRepository reviewerRepository)
    {
        _reviewerRepository = reviewerRepository;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ReviewerDto>))]
    public IActionResult GetReviewers()
    {
        return Ok(_reviewerRepository.GetReviewers());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ReviewerDto))]
    public IActionResult GetReviewer(int id)
    {
        return Ok(_reviewerRepository.GetReviewer(id));
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ReviewerDto))]
    public IActionResult CreateReviewer([FromBody] CreateReviewerDto createReviewerDto)
    {
        ReviewerDto reviewerDto = _reviewerRepository.CreateReviewer(createReviewerDto);
        return Created("/api/reviewers" + reviewerDto.Id, reviewerDto);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public IActionResult UpdateReviewer(int id, [FromBody] UpdateReviewerDto updateReviewerDto)
    {
        return Ok(_reviewerRepository.UpdateReviewer(id, updateReviewerDto));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public IActionResult DeleteReviewer(int id)
    {
        _reviewerRepository.DeleteReviewer(id);
        return NoContent();
    }
}