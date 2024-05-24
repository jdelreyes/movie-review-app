using ReviewApp.Dto.Review;
using ReviewApp.Models;

namespace ReviewApp.Interfaces;

public interface IReviewRepository
{
    IEnumerable<ReviewDto> GetReviews();
    ReviewDto GetReview(int id);
    ReviewDto CreateReview(CreateReviewDto createReviewDto);
    ReviewDto UpdateReview(int id, UpdateReviewDto updateReviewDto);
    ReviewDto DeleteReview(int id);
}