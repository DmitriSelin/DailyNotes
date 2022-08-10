using Microsoft.EntityFrameworkCore;

namespace DailyNotes.Infrastructure.Context
{
    public class DailyNotesDbContext : DbContext
    {
        public DailyNotesDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DailyNotesDb;Trusted_Connection=True;");
        }
    }
}