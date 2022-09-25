using DailyNotes.Application.Common.Exceptions;
using DailyNotes.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
                throw new NoteException("There are no note with this name", "Can not update this note",
                    (int)HttpStatusCode.NotAcceptable);
            }

            note.Name = request.Name;
            note.Text = request.Text;

            await _dailyNotesDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}