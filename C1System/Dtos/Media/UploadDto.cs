namespace C1System.Dtos.Media;

public class UploadDto
{
    // public string? UserId { get; set; }
    public List<IFormFile> Files { get; set; }
    // public Guid? AdsId { get; set; }
    // public Guid? JobId { get; set; }
    // public Guid? LearPostIdnId { get; set; }
    // public Guid?  { get; set; }
    public Guid? PortfolioId { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? TechnologyId { get; set; }
    public Guid? PodcastId { get; set; }
    public Guid? BlogId { get; set; }
    public Guid? CustomerSuccessId { get; set; }
    // public Guid? TenderId { get; set; }
}