
using C1System.DataLayar.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.DataLayar.Context
{
    public class C1SystemContext : DbContext
    {
        public C1SystemContext(DbContextOptions<C1SystemContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CustomerSpeech> CustomerSpeechs { get; set; }
    }
}
