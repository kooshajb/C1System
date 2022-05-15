
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("BookMark")]
public class BookMarkEntity : BaseEntity
{
    //todo - blog 
    //todo - podcast 
    //todo -portfolio

    public List<BlogEntity> Blogs { get; set; }
    public List<PodcastEntity> Podcasts { get; set; }
    public List<PortfolioEntity> Portfolios { get; set; }
}