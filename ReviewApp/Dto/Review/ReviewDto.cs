namespace ReviewApp.Dto.Review;

public class ReviewDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int ReviewerId { get; set; }
    public int MovieId { get; set; }
}