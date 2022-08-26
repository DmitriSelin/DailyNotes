using MediatR;

namespace DailyNotes.Application.Notes.Commands
{
    public class CreateNoteCommand : IRequest
    {
        public string Name;
    }
}