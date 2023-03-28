using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiinessLayer
{
    public class Context : IdentityDbContext<AppUser, AppRole, Guid>
    {

        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutTwo> AboutTwos { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureMin> FeaturesMins { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<SubAbout> Subabouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O97PCTN\\SQLEXPRESS;Database=TravelCore;Trusted_Connection=True;TrustServerCertificate=True");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //internal Task<IEntity> FindAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
