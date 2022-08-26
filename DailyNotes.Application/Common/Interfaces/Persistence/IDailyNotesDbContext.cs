using DailyNotes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyNotes.Application.Common.Interfaces.Persistence
{
    public interface IDailyNotesDbContext
    {
        DbSet<Note> Notes { get; set; }

        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}