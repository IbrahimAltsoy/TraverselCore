using Microsoft.EntityFrameworkCore;
using TraverselAPI.DAL.Entities;

namespace TraverselAPI.DAL.Context
{
    public class VisitorContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O97PCTN\\SQLEXPRESS;Database=TravelCoreAPI;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public DbSet<Visitor> Visitors { get; set; }//[Guid("8458EE11-B294-4367-A5BE-6E042B054355")]
    }
}
