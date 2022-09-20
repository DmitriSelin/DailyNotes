namespace DailyNotes.Application.Common.Exceptions
{
    public class NoteException : Exception
    {
        public string? MessageForUser { get; }

        public int? StatusCode { get; init; }

        public NoteException() { }

        public NoteException(string message) : base(message) { }

        public NoteException(string message, Exception innerException) : base(message, innerException) { }

        public NoteException(string message, string messageForUser, int? statusCode) : base(message)
        {
            MessageForUser = messageForUser;
            StatusCode = statusCode;
        }
    }
}
