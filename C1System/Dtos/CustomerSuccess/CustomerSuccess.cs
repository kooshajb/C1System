public class GetCustomerSuccessDto
{
    public Guid CustomerSuccessId { get; set; }
    public string ManagerName { get; set; }
    public string ManagerSide { get; set; }
    public string CompanyName { get; set; }
    public string StartupName { get; set; }
    public string ActivityName { get; set; }
    public string? CompanyLogo { get; set; }
    public string ManagerSpeech { get; set; }
    public string Description { get; set; }
    public string? VideoFile { get; set; }
    public string? CoverVideoImage { get; set; }
    public string? VideoTitle { get; set; }
    public string? VideoSubTitle { get; set; }
    public string Media { get; set; }
}

public class AddUpdateCustomerSuccessDto
{
    public string ManagerName { get; set; }
    public string ManagerSide { get; set; }
    public string CompanyName { get; set; }
    public string StartupName { get; set; }
    public string ActivityName { get; set; }
    public string? CompanyLogo { get; set; }
    public string ManagerSpeech { get; set; }
    public string Description { get; set; }
    public string? VideoFile { get; set; }
    public string? CoverVideoImage { get; set; }
    public string? VideoTitle { get; set; }
    public string? VideoSubTitle { get; set; }
    public string Media { get; set; }
}