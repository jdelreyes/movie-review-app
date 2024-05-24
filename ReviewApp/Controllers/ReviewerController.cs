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
    public IEnumerable<ReviewerDto> GetReviewers()
    {
        return _reviewerRepository.GetReviewers();
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ReviewerDto))]
    public ReviewerDto GetReviewer(int id)
    {
        return _reviewerRepository.GetReviewer(id);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ReviewerDto))]
    public ReviewerDto CreateReviewer([FromBody] CreateReviewerDto createReviewerDto)
    {
        return _reviewerRepository.CreateReviewer(createReviewerDto);
    }
}