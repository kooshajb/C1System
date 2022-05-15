using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class UpdatePodcastTagViewModel
{
    public Guid PodcastId { get; set; }

    [Display(Name = "عنوان پادکست")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string PodcastTitle { get; set; }

    public Guid TagPodcastId { get; set; }
    public Guid TagId { get; set; }
}