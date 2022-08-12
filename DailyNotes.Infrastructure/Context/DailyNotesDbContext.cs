using DailyNotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyNotes.Infrastructure.Context
{
    public class DailyNotesDbContext : DbContext
    {
        public DailyNotesDbContext() => Database.EnsureCreated();

        public DbSet<User> Users => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DIMITRI\SQLEXPRESS;Database=DailyNotesDb;Trusted_Connection=True;");
        }
    }
}