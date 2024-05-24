namespace ReviewApp.Dto.Review;

public class UpdateReviewDto
{
    public string Content { get; set; }
    public int MovieId { get; set; }
    public int ReviewerId { get; set; }
}