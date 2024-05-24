using ReviewApp.Models;

namespace ReviewApp.Dto.Reviewer;

public record ReviewerDto
{
    public int Id { get; init; }
    public string UserName { get; init; }
}