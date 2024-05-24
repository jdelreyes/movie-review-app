using AutoMapper;
using ReviewApp.Data;
using ReviewApp.Dto.Reviewer;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repositories;

public class ReviewerRepository : IReviewerRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviewerRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<ReviewerDto> GetReviewers()
    {
        return _mapper.Map<IEnumerable<Reviewer>, IEnumerable<ReviewerDto>>(_context.Reviewers.ToList());
    }

    public ReviewerDto GetReviewer(int id)
    {
        return _mapper.Map<Reviewer, ReviewerDto>(_context.Reviewers.Where(reviewer => reviewer.Id == id)
            .FirstOrDefault());
    }

    public ReviewerDto CreateReviewer(CreateReviewerDto createReviewerDto)
    {
        Reviewer reviewer = new Reviewer()
        {
            UserName = createReviewerDto.UserName
        };

        _context.Reviewers.Add(reviewer);
        _context.SaveChanges();

        return _mapper.Map<Reviewer, ReviewerDto>(reviewer);
    }

    public ReviewerDto UpdateReviewer(int id, UpdateReviewerDto updateReviewerDto)
    {
        throw new NotImplementedException();
    }

    public ReviewerDto DeleteReviewer(int id)
    {
        throw new NotImplementedException();
    }
}