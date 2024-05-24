using AutoMapper;
using ReviewApp.Data;
using ReviewApp.Dto.Review;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviewRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<ReviewDto> GetReviews()
    {
        return _mapper.Map<IEnumerable<ReviewDto>>(_context.Reviews);
    }

    public ReviewDto GetReview(int id)
    {
        return _mapper.Map<ReviewDto>(_context.Reviews.Where(r => r.Id == id).FirstOrDefault());
    }

    public ReviewDto CreateReview(CreateReviewDto createReviewDto)
    {
        Review review = _mapper.Map<Review>(createReviewDto);

        _context.Reviews.Add(review);
        _context.SaveChanges();

        return _mapper.Map<ReviewDto>(review);
    }

    public ReviewDto UpdateReview(int id, UpdateReviewDto updateReviewDto)
    {
        Review review = _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        Movie movie = _context.Movies.Where(m => m.Id == updateReviewDto.MovieId).FirstOrDefault();
        Reviewer reviewer = _context.Reviewers.Where(r => r.Id == updateReviewDto.ReviewerId).FirstOrDefault();

        Review updatedReview = new Review()
        {
            Id = review.Id,
            Reviewer = reviewer,
            Movie = movie,
            ReviewerId = reviewer.Id,
            MovieId = movie.Id
        };

        _context.Update(updateReviewDto);
        _context.SaveChanges();

        return _mapper.Map<ReviewDto>(updatedReview);
    }

    public ReviewDto DeleteReview(int id)
    {
        Review review = _context.Reviews.Where(r => r.Id == id).FirstOrDefault();

        _context.Remove(review);
        _context.SaveChanges();

        return _mapper.Map<ReviewDto>(review);
    }
}