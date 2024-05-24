using ReviewApp.Dto.Reviewer;

namespace ReviewApp.Interfaces;

public interface IReviewerRepository
{
    IEnumerable<ReviewerDto> GetReviewers();
    ReviewerDto GetReviewer(int id);
    ReviewerDto CreateReviewer(CreateReviewerDto createReviewerDto);
    ReviewerDto UpdateReviewer(int id, UpdateReviewerDto updateReviewerDto);
    ReviewerDto DeleteReviewer(int id);
}