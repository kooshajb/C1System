using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Tag_Podcast")]
public class Tag_PodcastEntity
{
    [Key]
    public Guid TagPodcastId { get; set; }

    public Guid TagId { get; set; }
    public Guid PodcastId { get; set; }

    [ForeignKey("TagId")]
    public TagEntity Tag { get; set; }
    
    [ForeignKey("PodcastId")]
    public PodcastEntity Podcast { get; set; }
}