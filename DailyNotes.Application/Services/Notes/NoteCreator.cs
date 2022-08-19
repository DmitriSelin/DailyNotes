using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Application.Common.Persistence;
using DailyNotes.Application.Services.Notes;
using DailyNotes.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace DailyNotes.Infrastructure.Services
{
    public class NoteCreator : INoteCreator
    {
        private readonly IJwtTokenDecoder _jwtTokenDecoder;
        private readonly IUserRepository _userRepository;

        public NoteCreator(IJwtTokenDecoder jwtTokenDecoder, IUserRepository userRepository)
        {
            _jwtTokenDecoder = jwtTokenDecoder;
            _userRepository = userRepository;
        }

        public Note CreateNewNote(string name, string text, string token)
        {
            JwtSecurityToken jwtToken = _jwtTokenDecoder.Decode(token);

            var noteId = Guid.NewGuid();

            return new Note(noteId, name, text);
        }
    }
}