using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class  UpdatePodcastMediaViewModel
{

    public Guid PodcastId { get; set; }

    public Guid MediaId { get; set; }
    public string FileName { get; set; }
}