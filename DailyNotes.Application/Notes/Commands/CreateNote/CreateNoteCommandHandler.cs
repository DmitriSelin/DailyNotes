using DailyNotes.Application.Common.Interfaces.Persistence;
using DailyNotes.Domain.Entities;
using MediatR;

namespace DailyNotes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, CreateNoteResult>
    {
        private readonly INoteRepository _noteRepository;

        public CreateNoteCommandHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<CreateNoteResult> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var noteId = Guid.NewGuid();

            var note = new Note(noteId, request.Name, request.Text)
            {
                UserId = request.UserId
            };

            await _noteRepository.AddNoteAsync(note);

            return new CreateNoteResult(note);
        }
    }
}
