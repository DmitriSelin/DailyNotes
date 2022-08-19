using DailyNotes.Application.Common.Exceptions;
using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Application.Common.Interfaces.Persistence;
using DailyNotes.Application.Common.Persistence;
using DailyNotes.Application.Services.Notes;
using DailyNotes.Domain.Entities;

namespace DailyNotes.Infrastructure.Services
{
    public class NoteCreator : INoteCreator
    {
        private readonly IJwtTokenDecoder _jwtTokenDecoder;
        private readonly IUserRepository _userRepository;
        private readonly INoteRepository _noteRepository;

        public NoteCreator(IJwtTokenDecoder jwtTokenDecoder, IUserRepository userRepository, INoteRepository noteRepository)
        {
            _jwtTokenDecoder = jwtTokenDecoder;
            _userRepository = userRepository;
            _noteRepository = noteRepository;
        }

        public Note CreateNewNote(string name, string text, string token)
        {
            var jwtToken = _jwtTokenDecoder.Decode(token);

            var userId = Guid.Parse(jwtToken.Subject);

            User? user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                throw new UserException("This user does not exists");
            }

            var noteId = Guid.NewGuid();

            var note = new Note(noteId, name, text);

            _noteRepository.AddNote(note);

            return note;
        }
    }
}