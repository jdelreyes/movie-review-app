using AutoMapper;
using ReviewApp.Dto;
using ReviewApp.Dto.Reviewer;
using ReviewApp.Models;

namespace ReviewApp.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Movie, MovieDto>().ReverseMap();
        CreateMap<Movie, MovieDetailsDto>().ReverseMap();
        CreateMap<Movie, CreateMovieDto>().ReverseMap();
        CreateMap<Movie, UpdateMovieDto>().ReverseMap();
        CreateMap<Reviewer, ReviewerDto>().ReverseMap();
        CreateMap<Reviewer, CreateReviewerDto>().ReverseMap();
        CreateMap<Reviewer, UpdateReviewerDto>().ReverseMap();
    }
}