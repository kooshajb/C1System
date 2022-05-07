
using C1System.DataLayar.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C1System.DataLayar.Entities.Geo;

namespace C1System.DataLayar.Context
{
    public class C1SystemContext : DbContext
    {
        public C1SystemContext(DbContextOptions<C1SystemContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Introduction> Introductions { get; set; }
        public DbSet<CustomerSpeech> CustomerSpeechs { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Country> Countries { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }

    }
}
