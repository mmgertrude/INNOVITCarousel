using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INNOVITCarousel.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Picture> pictures { get; set; }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PicturesCarousel>().ToTable("Picture");

        } */

    }
}
