using DailyNotes.Application.Common.Exceptions;
using DailyNotes.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DailyNotes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly IDailyNotesDbContext _dailyNotesDbContext;

        public DeleteNoteCommandHandler(IDailyNotesDbContext dailyNotesDbContext)
        {
            _dailyNotesDbContext = dailyNotesDbContext;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _dailyNotesDbContext.Notes
                .FirstOrDefaultAsync(entity => entity.Id == request.NoteId);

            if (note == null || note.UserId != request.UserId)
            {
                throw new NoteException("There are no note with this id", "Can not delete this note",
                    (int)HttpStatusCode.NotAcceptable);
            }

            _dailyNotesDbContext.Notes.Remove(note);

            await _dailyNotesDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}