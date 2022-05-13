using Microsoft.EntityFrameworkCore;

namespace C1System;
public class C1SystemContext : DbContext
{
    public C1SystemContext(DbContextOptions<C1SystemContext> options) : base(options)
    {

    }

    // public DbSet<Slider> Sliders { get; set; }
    // public DbSet<Tag> Tags { get; set; }
    
    // public DbSet<Introduction> Introductions { get; set; }
    // public DbSet<CustomerSpeech> CustomerSpeechs { get; set; }

    public DbSet<Category> Categories { get; set; }
    // public DbSet<CategoryPackage> CategoryPackages { get; set; }
    // public DbSet<CategoryPackageItem>  CategoryPackageItems { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    // public DbSet<Project> Prosjects { get; set; }
    public DbSet<Podcast> Podcasts { get; set; }
    // public DbSet<Gender> Genders { get; set; }
    // public DbSet<City> Cities { get; set; }
    // public DbSet<Province> Provinces { get; set; }
    // public DbSet<Country> Countries { get; set; }
    // public DbSet<User> Users { get; set; }
    // public DbSet<UserRole> UserRoles { get; set; }
    // public DbSet<AccountType> AccountTypes { get; set; }
    // public DbSet<Blog> Blogs { get; set; }
    // public DbSet<CareerOpportunity> CareerOpportunities { get; set; }
    // public DbSet<Faq> Faqs { get; set; }
    // public DbSet<NewsLetter>  NewsLetters { get; set; }
    // public DbSet<DemoPortfolio>  DemoPortfolios { get; set; }
    // public DbSet<TechnologyPortfolio> TechnologyPortfolios  { get; set; }
    // public DbSet<Ticket> Tickets { get; set; }
    // public DbSet<Priority> Priorities { get; set; }
    // public DbSet<TicketStatus> TicketStatuses { get; set; }
}

