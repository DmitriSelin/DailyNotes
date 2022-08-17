namespace DailyNotes.Application.Services.Notes
{
    public interface INoteCreator
    {
        NoteResult CreateNewNote(string name, string text, DateTime creationTime);
    }
}