using C1System.Media;
using Microsoft.EntityFrameworkCore;

namespace C1System;
public class C1SystemContext : DbContext
{
    public C1SystemContext(DbContextOptions<C1SystemContext> options) : base(options) { }
    // public DbSet<BlogEntity> Blogs { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<BlogEntity> Blogs { get; set; }
    public DbSet<BlogCategoryEntity> BlogCategories { get; set; }
    public DbSet<CustomerSuccessEntity> CustomerSuccesses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<PortfolioEntity> Portfolios { get; set; }
    public DbSet<Category_PortfolioEntity> CategoryPortfolios { get; set; }
    public DbSet<Technology_PortfolioEntity> TechnologyPortfolios { get; set; }
    public DbSet<Tag_PodcastEntity> TagPodcasts { get; set; }
    public DbSet<Tag_BlogEntity> TagBlogs { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<PodcastEntity> Podcasts { get; set; }
    public DbSet<MediaEntity> Media { get; set; }
    public DbSet<NewsLetterEntity> NewsLetters { get; set; }
    public DbSet<TechnologyEntity> Technologies  { get; set; }
    public DbSet<ConsultingEntity> Consultings  { get; set; }
}