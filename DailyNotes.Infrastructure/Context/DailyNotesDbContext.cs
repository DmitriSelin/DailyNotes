using DailyNotes.Application.Common.Interfaces.Persistence;
using DailyNotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyNotes.Infrastructure.Context
{
    public class DailyNotesDbContext : DbContext
    {
        public DailyNotesDbContext(DbContextOptions<DailyNotesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Note> Notes => Set<Note>();
    }
}