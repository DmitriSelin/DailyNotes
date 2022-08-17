namespace DailyNotes.Application.Services.Notes
{
    public interface INoteCreator
    {
        void CreateNewNote(string name, string text, DateTime creationTime);
    }
}