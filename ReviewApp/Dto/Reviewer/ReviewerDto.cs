using ReviewApp.Models;

namespace ReviewApp.Dto.Reviewer;

public record ReviewerDto
{
    public string UserName { get; init; }
    public IEnumerable<Review> Reviews { get; init; }
}