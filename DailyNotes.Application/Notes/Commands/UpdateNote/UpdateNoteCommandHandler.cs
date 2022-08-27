using DailyNotes.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DailyNotes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
    {
        private readonly IDailyNotesDbContext _dailyNotesDbContext;

        public UpdateNoteCommandHandler(IDailyNotesDbContext dailyNotesDbContext)
        {
            _dailyNotesDbContext = dailyNotesDbContext;   
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _dailyNotesDbContext.Notes
                .FirstOrDefaultAsync(entity => entity.Id == request.NoteId, cancellationToken);

            if(note == null || note.UserId != request.UserId)
            {
                throw new Exception("There are no note with this name");
            }

            note.Name = request.Name;
            note.Name = request.Name;

            await _dailyNotesDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}