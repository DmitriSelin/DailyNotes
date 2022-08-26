using DailyNotes.Application.Common.Interfaces.Persistence;
using DailyNotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyNotes.Infrastructure.Context
{
    public class DailyNotesDbContext : DbContext, IDailyNotesDbContext
    {
        public DailyNotesDbContext(DbContextOptions<DailyNotesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Note> Notes { get; set; } = null!;
    }
}