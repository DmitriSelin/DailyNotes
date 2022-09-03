﻿using DailyNotes.Application.Common.Interfaces.Persistence;
using MediatR;

namespace DailyNotes.Application.Notes.Queries.GetListNote
{
    public class GetListNotesQueryHandler : IRequestHandler<GetListNoteQuery, List<NoteVm>>
    {
        private readonly IDailyNotesDbContext _dbContext;

        public GetListNotesQueryHandler(IDailyNotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<NoteVm>> Handle(GetListNoteQuery request, CancellationToken cancellationToken)
        {
            var notes = _dbContext.Notes.Where(user => user.UserId == request.UserId).ToList();

            if (notes.Count == 0)
            {
                throw new Exception();
            }

            var noteVmList = new List<NoteVm>();

            foreach (var note in notes)
            {
                noteVmList.Add(new NoteVm(note.Id, note.Name));
            }

            return noteVmList;
        }
    }
}