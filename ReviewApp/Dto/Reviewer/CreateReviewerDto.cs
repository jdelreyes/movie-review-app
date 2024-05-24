using ReviewApp.Models;

namespace ReviewApp.Dto.Reviewer;

public record CreateReviewerDto
{
    public string UserName { get; init; }
}