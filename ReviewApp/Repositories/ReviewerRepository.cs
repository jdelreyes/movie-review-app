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
        return _mapper.Map<IEnumerable<ReviewerDto>>(_context.Reviewers.ToList());
    }

    public ReviewerDto GetReviewer(int id)
    {
        return _mapper.Map<ReviewerDto>(_context.Reviewers.Where(reviewer => reviewer.Id == id)
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
        Reviewer reviewer = _context.Reviewers.Where(r => r.Id == id).FirstOrDefault();
        Reviewer updatedReviewer =
            _context.Update(_mapper.Map<Reviewer>(updateReviewerDto)).Entity;

        _context.SaveChanges();

        return _mapper.Map<Reviewer, ReviewerDto>(updatedReviewer);
    }

    public ReviewerDto DeleteReviewer(int id)
    {
        Reviewer reviewer = _context.Reviewers.Where(r => r.Id == id).FirstOrDefault();
        
        _context.Reviewers.Remove(reviewer);
        _context.SaveChanges();

        return _mapper.Map<ReviewerDto>(reviewer);
    }
}